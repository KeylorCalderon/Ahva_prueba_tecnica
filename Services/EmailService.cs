namespace AhvaPrueba.Services
{
    //Es un placeholder, no envía correos reales todavía.
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public Task EnviarNotificacionBloqueoAsync(string correoDestino, string username)
        {
            //Acá iría el proveedor real
            _logger.LogInformation(
                "[EMAIL PLACEHOLDER] Se enviaría notificación de bloqueo de cuenta a {Correo} (usuario: {Username})",
                correoDestino, username);

            return Task.CompletedTask;
        }
    }
}