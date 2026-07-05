using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using AhvaPrueba.Data;
using AhvaPrueba.Models.ViewModels;

namespace AhvaPrueba.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerfilController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ExtenderSesion()
        {
            return Json(new { success = true });
        }

        public async Task<IActionResult> Index()
        {
            var usuarioId = int.Parse(User.FindFirstValue("UsuarioId")!);

            var usuario = await _context.Usuarios
                .Include(u => u.TipoDocumento)
                .Include(u => u.Sexo)
                .Include(u => u.TipoContratacion)
                .FirstOrDefaultAsync(u => u.Id == usuarioId);

            if (usuario == null)
                return NotFound();

            var vm = new PerfilViewModel
            {
                Nombres = usuario.Nombres,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                Titulo = usuario.Titulo ?? "",
                Institucion = usuario.Institucion ?? "",
                FotoPerfilUrl = usuario.FotoPerfilUrl,
                TipoDocumento = usuario.TipoDocumento?.Nombre ?? "",
                NumeroDocumento = usuario.NumeroDocumento,
                FechaNacimiento = usuario.FechaNacimiento,
                Nacionalidad = usuario.Nacionalidad,
                Sexo = usuario.Sexo?.Nombre ?? "",
                CorreoPrincipal = usuario.CorreoPrincipal,
                CorreoSecundario = usuario.CorreoSecundario,
                TelefonoMovil = usuario.TelefonoMovil,
                TelefonoSecundario = usuario.TelefonoSecundario,
                TipoContratacion = usuario.TipoContratacion?.Nombre ?? "",
                FechaContratacion = usuario.FechaContratacion
            };

            return View(vm);
        }
    }
}