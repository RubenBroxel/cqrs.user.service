
using Cqrs.Users.Service.Infraestructure;
using MediatR;

namespace Cqrs_Demo.Handlers.Commands;

/// <summary>
/// 
/// </summary>
public class InsertUsuario
{
    //Command
    public record Command(Usuario Usuario):IRequest<Response>;
    //Handler
    public class Handler : IRequestHandler<Command, Response>
    {
        private readonly UsuariosCqrsContext _ctx;

        public Handler(UsuariosCqrsContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            _ctx.Usuarios.Add(request.Usuario);
            await _ctx.SaveChangesAsync();
            return new Response(request.Usuario);
        }
    }

    //Respuesta
    public record Response(Usuario Producto);
}