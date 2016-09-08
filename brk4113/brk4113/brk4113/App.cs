using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;

namespace brk4113
{
    public class App : Application
    {
        public static string ClientId = "REDACTED";
        public static string LoginAuthority = "https://login.microsoftonline.com/fabiansworld.onmicrosoft.com";
        public static string ReturnUri = "http://ignite-brk3114-redirect";
        public static string GraphResourceUri = "https://graph.microsoft.com";
        public static AuthenticationResult AuthenticationResult = null;

        public App()
        {
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        }
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
