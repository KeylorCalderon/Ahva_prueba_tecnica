namespace AhvaPrueba.Services
{
    public interface IEmailService
    {
        Task EnviarNotificacionBloqueoAsync(string correoDestino, string username);
    }
}