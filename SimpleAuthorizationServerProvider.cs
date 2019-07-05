using CursoAPI.DAO;
using CursoAPI.DTO;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CursoAPI
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            UsuariosDTO _usuario = new UsuariosDTO();


            try
            {
                _usuario = (new UsuariosDAO()).SelectUsuarioPorCredenciais(context.UserName, context.Password);
            }
            catch (Exception ex)
            {
                context.SetError("error", ex.InnerException.ToString());
            }

            if(_usuario == null)
            {
                context.SetError("Falha no login!", "Usuário ou senha inválidos. Caso não se lembre, entre em contato com o administrador!");
                return;
            }


            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("idusuario", _usuario.idusuario.ToString()));
            identity.AddClaim(new Claim("role", "user"));
            context.Validated(identity);

        }
    }
}