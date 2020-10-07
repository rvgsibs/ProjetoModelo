using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using ProjetoModelo.Domain.Entities;
using ProjetoModelo.Domain.Interfaces.Repositories;
using ProjetoModelo.Infra.IoC.ContainerIoc;

namespace ProjetoModelo.API.Provider
{
    public class AuthorizationServerProvider: OAuthAuthorizationServerProvider
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthorizationServerProvider()
        {
            _usuarioRepository = SimpleInjectorContainer._container.GetInstance<IUsuarioRepository>();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                
                var usuario = new Usuario();

                var login = _usuarioRepository.Login(usuario);

                if (!login.Autorizado)
                {
                    context.SetError("invalid_grant", "Usuário/Senha inválidos");
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                List<string> roles = new List<string>();
                AuthenticationProperties properties = CreateProperties(context.UserName, roles);
                AuthenticationTicket ticket = new AuthenticationTicket(identity, properties);
                context.Validated(ticket);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        private static AuthenticationProperties CreateProperties(string user, List<string> roles)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                {"user_name", user },
                {"roles", string.Join(",", roles) }
            };

            return new AuthenticationProperties(data);
        }


    }
}