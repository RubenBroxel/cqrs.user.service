namespace Cqrs.Users.Service.Application.Models.Response;

public class GetPostResponseModel
{
    public string NombreUsuario { get; set; } = null!;
    public string? CorreoElectronico { get; set; }
    public DateTime? FechaRegistro { get; set; }
}