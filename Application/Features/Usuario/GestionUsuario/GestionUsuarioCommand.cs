using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuario.GestionUsuario
{
    public class GestionUsuarioCommand : IRequest<UserResult>
    {
        public string? UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string? DNI { get; set; }
    }
}
