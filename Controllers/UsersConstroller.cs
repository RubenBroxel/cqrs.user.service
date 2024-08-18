using Cqrs.Users.Service.Application.Handlers.Queries;
using Cqrs.Users.Service.Infraestructure;
using Cqrs_Demo.Handlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace Cqrs.Users.Service.Controllers;

[Route("api/Users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _sender;

    public UsersController(IMediator sender)
    {
        _sender = sender;  
    } 


    [HttpGet("pornombre")]
    public IActionResult GetUserByName([FromHeader]string nombre)
    {
        var response = _sender.Send(new GetUsuarios.ByName(nombre)).GetAwaiter().GetResult();
        var usuario = response.usuario;
        return Ok(usuario);
    }

    [HttpGet("todos")]
    public IActionResult GetUsers()
    {
        var response = _sender.Send(new GetUsuarios.ByAll()).GetAwaiter().GetResult();
        var usuario = response;
        return Ok(usuario);
    }


    [HttpPost("agregar")]
    public IActionResult AddUser([FromBody]Usuario usuario)
    {
        var response = _sender.Send(new InsertUsuario.Command(usuario)).GetAwaiter().GetResult();
        return Ok( CreatedAtRoute("GetUserName", new { Nuevo_Usuario = usuario.NombreUsuario }, response ));
    }
}