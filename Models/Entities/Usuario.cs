using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhvaPrueba.Models.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string PrimerApellido { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? SegundoApellido { get; set; }

        public int TipoDocumentoId { get; set; }
        [ForeignKey(nameof(TipoDocumentoId))]
        public TipoDocumento? TipoDocumento { get; set; }

        [Required, MaxLength(30)]
        public string NumeroDocumento { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required, MaxLength(50)]
        public string Nacionalidad { get; set; } = string.Empty;

        public int SexoId { get; set; }
        [ForeignKey(nameof(SexoId))]
        public Sexo? Sexo { get; set; }

        [Required, MaxLength(150), EmailAddress]
        public string CorreoPrincipal { get; set; } = string.Empty;

        [MaxLength(150), EmailAddress]
        public string? CorreoSecundario { get; set; }

        [Required, MaxLength(20)]
        public string TelefonoMovil { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? TelefonoSecundario { get; set; }

        public int TipoContratacionId { get; set; }
        [ForeignKey(nameof(TipoContratacionId))]
        public TipoContratacion? TipoContratacion { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaContratacion { get; set; }

        [MaxLength(255)]
        public string? FotoPerfilUrl { get; set; }

        [MaxLength(100)]
        public string? Titulo { get; set; }

        [MaxLength(100)]
        public string? Institucion { get; set; }

        // Control de seguridad
        public int ContadorValidacionesFallidas { get; set; } = 0;
        public DateTime? FechaBloqueo { get; set; }
    }
}