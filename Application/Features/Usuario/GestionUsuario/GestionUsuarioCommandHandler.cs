using Application.Response;
using Data.Base;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuario.GestionUsuario
{
    public class GestionUsuarioCommandHandler : ConstruirToken, IRequestHandler<GestionUsuarioCommand, UserResult>
    {
        private readonly UserManager<Domain.Entities.Usuario> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPasswordHasher<Domain.Entities.Usuario> passwordHasher;
        private readonly IConfiguration configuration;

        public GestionUsuarioCommandHandler(UserManager<Domain.Entities.Usuario> userManager, IUnitOfWork unitOfWork,
            IPasswordHasher<Domain.Entities.Usuario> passwordHasher, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            this.passwordHasher = passwordHasher;
            this.configuration = configuration;
        }
        public async Task<UserResult> Handle(GestionUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existe = await userManager.Users.Where(x => x.Email == request.Email).AnyAsync();
                if (existe)
                {
                    return new UserResult { IsSuccess = false, Message = "Ya existe un usuario con el email" };
                }

                if (request.UsuarioId == null)
                {
                    var usuario = new Domain.Entities.Usuario
                    {
                        NombreCompleto = request.Nombres + " " + request.Apellidos,
                        Email = request.Email,
                        UserName = request.Email,
                        DNI = request.DNI,
                    };
                    var resultado = await userManager.CreateAsync(usuario, request.Password);

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
                            Message = "Usuario creado correctamente",
                            Nombres = usuario.NombreCompleto,
                            //roles = null, porque recien estamos creando al usuario
                            Token = token.Token,
                            UserName = usuario.UserName,
                            UserId = usuario.Id
                        };
                    }
                    else
                    {
                        return new UserResult { IsSuccess = false, Message = "No se pudo registrar al usuario." };

                    }
                }
                else
                {
                    var usuarioIden = await userManager.FindByIdAsync(request.UsuarioId);
                    if (usuarioIden == null)
                    {
                        return new UserResult { IsSuccess = false, Message = "No se encuentra al usuario" };
                    }

                    usuarioIden.NombreCompleto = request.Nombres + " " + request.Apellidos;
                    usuarioIden.PasswordHash = passwordHasher.HashPassword(usuarioIden, request.Password);//Actualizar contraseña
                    usuarioIden.Email = request.Email;

                    var resultadoUpdate = await userManager.UpdateAsync(usuarioIden);

                    if (resultadoUpdate.Succeeded)
                    {
                        var token = await ConstruccionDeToken(new Request.CredencialesUsuario
                        {
                            Email = request.Email,
                            Password = request.Password,
                        }, userManager, configuration);

                        return new UserResult
                        {
                            IsSuccess = true,
                            Message = "Usuario actualizado correctamente",
                            Nombres = usuarioIden.NombreCompleto,
                            //roles = null, porque recien estamos creando al usuario
                            Token = token.Token,
                            UserName = usuarioIden.UserName,
                            UserId = usuarioIden.Id
                        };
                    }
                    else
                    {
                        return new UserResult { IsSuccess = false, Message = "No se pudo registrar al usuario." };

                    }
                }
            }
            catch (Exception ex)
            {
                return new UserResult { IsSuccess = false, Message = "Ocurrio un error inesperado" };
            }
        }
    }
}
