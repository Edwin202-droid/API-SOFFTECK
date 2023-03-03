using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuario.Login
{
    public class LoginCommand : MediatR.IRequest<UserResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
