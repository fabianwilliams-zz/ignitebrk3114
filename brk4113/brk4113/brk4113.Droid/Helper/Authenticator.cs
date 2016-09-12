using System;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using brk4113.Helper;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;

[assembly: Dependency(typeof(brk4113.Droid.Helper.Authenticator))]
namespace brk4113.Droid.Helper
{
    public class Authenticator : IAuthenticator
    {
        public async Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, Uri returnUri)
        {
            var authContext = new AuthenticationContext(authority);
            if (authContext.TokenCache.ReadItems().Any())
                authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);
            var authResult = await authContext.AcquireTokenAsync(resource, clientId, returnUri, new PlatformParameters((Activity)Forms.Context));
            return authResult;
        }
    }
}