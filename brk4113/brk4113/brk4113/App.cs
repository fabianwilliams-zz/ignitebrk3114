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
        //public static string ClientId = "88c9b486-32ea-469d-9104-d43ba85d0ec2";
        public static string ClientId = "d87b9be1-a4c8-4777-af9f-922c414f0e3d";
        public static string LoginAuthority = "https://login.microsoftonline.com/fabiansworld.onmicrosoft.com";
        //public static string ReturnUri = "http://ignite-brk3114-redirect";
        public static string ReturnUri = "http://www.fabiangwilliams.com/brk1123";
        public static string GraphResourceUri = "https://graph.microsoft.com";
        public static AuthenticationResult AuthenticationResult = null;

        public App()
        {

            // The root page of your application
            MainPage = new NavigationPage(new View.HomePage());
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
