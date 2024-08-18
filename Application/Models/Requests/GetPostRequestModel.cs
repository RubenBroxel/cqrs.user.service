
using Cqrs.Users.Service.Application.Models.Response;
using MediatR;

namespace Cqrs.Users.Service.Application.Models.Request;

public class GetPostRequestModel : IRequest<GetPostResponseModel>
{
    public string NombreUsuario { get; set; } = null!;
    public string? CorreoElectronico { get; set; }
    public DateTime? FechaRegistro { get; set; }
}
