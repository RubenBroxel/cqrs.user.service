using System;
using System.Collections.Generic;

namespace Cqrs.Users.Service.Infraestructure;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string? CorreoElectronico { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
