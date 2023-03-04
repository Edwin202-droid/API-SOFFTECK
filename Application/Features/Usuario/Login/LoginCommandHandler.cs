using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuario.Login
{
    public class LoginCommandHandler : ConstruirToken, IRequestHandler<LoginCommand, UserResult>
    {
        private readonly UserManager<Domain.Entities.Usuario> userManager;
        private readonly SignInManager<Domain.Entities.Usuario> signInManager;
        private readonly IConfiguration configuration;

        public LoginCommandHandler(UserManager<Domain.Entities.Usuario> userManager,
            SignInManager<Domain.Entities.Usuario> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        public async Task<UserResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var usuario = await userManager.FindByEmailAsync(request.Email);
            if (usuario == null)
            {
                return new UserResult { IsSuccess = false, Message = "Usuario no registrado" };
            }
            var resultado = await signInManager.CheckPasswordSignInAsync(usuario, request.Password, false);
            if (resultado.Succeeded)
            {
                var token = await ConstruccionDeToken(new Request.CredencialesUsuario
                {
                    Email = request.Email,
                    Password = request.Password,
                }, userManager, configuration);

                return new UserResult
                {
                    IsSuccess = true,
                    Message = "Login correcto",
                    Nombres = usuario.NombreCompleto,
                    Token = token.Token,
                    UserName = usuario.UserName,
                    UserId = usuario.Id
                };
            }
            else
            {
                return new UserResult { IsSuccess = false, Message = "Login incorrecto" };
            }
        }
    }
}
