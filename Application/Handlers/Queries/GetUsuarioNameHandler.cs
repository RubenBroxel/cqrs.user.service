using Cqrs.Users.Service.Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.Users.Service.Application.Handlers.Queries;

public class GetUsuarios
{
    //Command
    public record ByName(string name):IRequest<Response>;
    //Handler
    public class Handler : IRequestHandler<ByName, Response>
    {
        private readonly UsuariosCqrsContext _ctx;

        public Handler(UsuariosCqrsContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Handle(ByName request, CancellationToken cancellationToken)
        {
            var usuario = await _ctx.Usuarios.SingleOrDefaultAsync(u =>EF.Functions.Like( u.NombreUsuario, $"%{request.name}%"), cancellationToken);
            if (usuario == null)
            {
                throw new KeyNotFoundException($"no se encontró registro '{request.name}'.");
            }    
            return new Response(usuario);
        }
    }

    public record ByAll : IRequest<List<Response>>;

    public class ByAllHandler : IRequestHandler<ByAll, List<Response>>
    {
        private readonly UsuariosCqrsContext _ctx;

        public ByAllHandler(UsuariosCqrsContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Response>> Handle(ByAll request, CancellationToken cancellationToken)
        {
            var usuario = await _ctx.Usuarios.ToListAsync(cancellationToken);
            var response = usuario.Select(u => new Response(u)).ToList();
            return response;
        }
    }

    //Respuesta
    public record Response(Usuario usuario);
}