using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using AhvaPrueba.Data;
using AhvaPrueba.Models.ViewModels;

namespace AhvaPrueba.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const int MAX_INTENTOS = 5;
        private const int MINUTOS_BLOQUEO = 15;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login(bool expirada = false)
        {
            ViewBag.SesionExpirada = expirada;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Username == model.Username);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
                return View(model);
            }

            //Se verifica si la cuenta está o no bloqueada
            bool estaBloqueada = usuario.ContadorValidacionesFallidas >= MAX_INTENTOS
                && usuario.FechaBloqueo.HasValue
                && (DateTime.Now - usuario.FechaBloqueo.Value) < TimeSpan.FromMinutes(MINUTOS_BLOQUEO);

            if (estaBloqueada)
            {
                return RedirectToAction("Bloqueada");
            }

            //Si ya pasaron los 15 minutos se resetea aquí
            if (usuario.FechaBloqueo.HasValue
                && (DateTime.Now - usuario.FechaBloqueo.Value) >= TimeSpan.FromMinutes(MINUTOS_BLOQUEO))
            {
                usuario.ContadorValidacionesFallidas = 0;
                usuario.FechaBloqueo = null;
            }

            //Se verifican credenciales
            bool credencialesValidas = BCrypt.Net.BCrypt.Verify(model.Password, usuario.PasswordHash);

            if (!credencialesValidas)
            {
                usuario.ContadorValidacionesFallidas++;

                if (usuario.ContadorValidacionesFallidas >= MAX_INTENTOS)
                {
                    usuario.FechaBloqueo = DateTime.Now;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Bloqueada");
                }

                await _context.SaveChangesAsync();
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
                return View(model);
            }

            //Si el login es exitoso se hace reset del contador de validaciones fallidas
            usuario.ContadorValidacionesFallidas = 0;
            usuario.FechaBloqueo = null;
            await _context.SaveChangesAsync();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim("UsuarioId", usuario.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties { IsPersistent = false });

            return RedirectToAction("Index", "Perfil");
        }

        [HttpGet]
        public IActionResult Bloqueada()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        //Endpoint para extender sesión
        [HttpPost]
        public IActionResult ExtenderSesion()
        {
            //Estar autenticado y llamar a este endpoint ya renueva la cookie por el SlidingExpiration
            return Json(new { success = true });
        }
    }
}