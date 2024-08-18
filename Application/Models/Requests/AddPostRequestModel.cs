using Cqrs.Users.Service.Application.Models.Response;
using MediatR;

namespace Cqrs.Users.Service.Application.Models.Request;

public class AddPostRequestModel : IRequest<AddPostResponseModel>
{
    public string? NombreUsuario { get; set; }

    public string? Contrasena { get; set; }

    public string? CorreoElectronico { get; set; }

}
