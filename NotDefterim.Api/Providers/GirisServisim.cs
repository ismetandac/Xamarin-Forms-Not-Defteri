using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using NotDefterim.Model;
using NotDefterim.Model.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace NotDefterim.Api.Providers
{
    public class GirisServisim : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {

            context.Validated();

            return Task.FromResult<object>(null);
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                // Kullanıcının access_token alabilmesi için gerekli validation işlemlerini yapıyoruz.
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                using (var db = new Veritabanim())
                {
                    var data = db.Kullanici.Where(x => x.Email == context.UserName && x.Sifre == context.Password).ToList();
                    if (data.Count == 1)
                    {
                        var user = data.FirstOrDefault();

                        identity.AddClaim(new Claim("sub", context.UserName));
                        identity.AddClaim(new Claim("UserName", user.Email));
                        identity.AddClaim(new Claim("id", user.ID.ToString()));
                        context.Validated(identity);
                    }
                    else
                    {
                        context.SetError("invalid_grant", "Kullanıcı adı veya şifre yanlış.");
                    }
                }
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", "Kullanıcı adı veya şifre yanlış.");
            }
        }
    }
}
