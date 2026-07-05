using AhvaPrueba.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AhvaPrueba.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<TipoContratacion> TiposContratacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDocumento>().HasData(
                new TipoDocumento { Id = 1, Nombre = "Cédula de Identidad" },
                new TipoDocumento { Id = 2, Nombre = "Pasaporte" },
                new TipoDocumento { Id = 3, Nombre = "RIF" }
            );

            modelBuilder.Entity<Sexo>().HasData(
                new Sexo { Id = 1, Nombre = "Masculino" },
                new Sexo { Id = 2, Nombre = "Femenino" }
            );

            modelBuilder.Entity<TipoContratacion>().HasData(
                new TipoContratacion { Id = 1, Nombre = "Fijo" },
                new TipoContratacion { Id = 2, Nombre = "Temporal" },
                new TipoContratacion { Id = 3, Nombre = "Contratista" }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Username = "KeylorCalderon",
                    PasswordHash = "$2a$11$WN3E2qRBt2ve1J6Gdp5z1uxsy/CqBV/W.Sutldr0rmM0yLEYVePMG",
                    Nombres = "Keylor",
                    PrimerApellido = "Calderon",
                    SegundoApellido = "Vega",
                    TipoDocumentoId = 1,
                    NumeroDocumento = "V-12345678",
                    FechaNacimiento = new DateTime(1990, 5, 14),
                    Nacionalidad = "Costarricense",
                    SexoId = 1,
                    CorreoPrincipal = "keylor.calderon.dev@gmail.com",
                    CorreoSecundario = null,
                    TelefonoMovil = "506-12345678",
                    TelefonoSecundario = null,
                    TipoContratacionId = 1,
                    FechaContratacion = new DateTime(2020, 1, 10),
                    FotoPerfilUrl = "/images/default-profile.png",
                    Titulo = "Ingeniero de Sistemas",
                    Institucion = "Universidad de Costa Rica",
                    ContadorValidacionesFallidas = 0,
                    FechaBloqueo = null
                }
            );
        }
    }
}