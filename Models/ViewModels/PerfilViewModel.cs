namespace AhvaPrueba.Models.ViewModels
{
    public class PerfilViewModel
    {
        public string Nombres { get; set; } = string.Empty;
        public string PrimerApellido { get; set; } = string.Empty;
        public string? SegundoApellido { get; set; }
        public string NombreCompleto => $"{Nombres} {PrimerApellido} {SegundoApellido}".Trim();

        public string Titulo { get; set; } = string.Empty;
        public string Institucion { get; set; } = string.Empty;
        public string? FotoPerfilUrl { get; set; }

        public string TipoDocumento { get; set; } = string.Empty;
        public string NumeroDocumento { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }

        public string Nacionalidad { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string CorreoPrincipal { get; set; } = string.Empty;

        public string? CorreoSecundario { get; set; }
        public string TelefonoMovil { get; set; } = string.Empty;
        public string? TelefonoSecundario { get; set; }

        public string TipoContratacion { get; set; } = string.Empty;
        public DateTime FechaContratacion { get; set; }
    }
}