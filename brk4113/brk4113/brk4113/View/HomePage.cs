using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using brk4113.Helper;
using Xamarin.Forms;

namespace brk4113.View
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {

            Title = "Welcome to MS Ignite BRK 3114";

            //set up button for the login to Graph API
            var welcomeLabel = new Label
            {
                Text = "Login with your student or organization account please",
                FontSize = 13,
                FontFamily = "AvenirNext-DemiBold",
                TextColor = Color.Black
            };

            var submitButton = new Button
            {
                Text = "Login!",
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
                BorderWidth = 2,
                BorderColor = Color.White,
                BackgroundColor = Color.Black
            };

                submitButton.Clicked += (sender, e) => {
                RespondToButtonClick();
            };

            Content = new StackLayout()
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                BackgroundColor = Color.White,
                Children = {
                    welcomeLabel,
                    submitButton

                }
            };
        }

        public async void RespondToButtonClick()
        {

            Uri mUri = new Uri(App.ReturnUri);
            var data = await DependencyService.Get<IAuthenticator>()
               .Authenticate(App.LoginAuthority, App.GraphResourceUri, App.ClientId, mUri);
            App.AuthenticationResult = data;
            var userName = data.UserInfo.GivenName + " " + data.UserInfo.FamilyName;
            await DisplayAlert("Welcome", userName, "Ok", "Cancel");
            await Navigation.PushAsync(new MasterPage());
        }

    }
}
