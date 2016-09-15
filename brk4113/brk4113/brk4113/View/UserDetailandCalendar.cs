using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using brk4113.Model;
using Xamarin.Forms;

namespace brk4113.View
{
    public class UserDetailandCalendar : ContentPage
    {

        public UserDetailandCalendar(Value cuRequest )
        {
            Title = cuRequest.DisplayName;

            var UserNameLabel = new Label
            {
                FontAttributes = FontAttributes.Bold,
                Text = cuRequest.DisplayName,
                FontSize = 15
            };

            var userImage = new Image
            {
                Aspect = Aspect.AspectFit,
                BackgroundColor = Color.Gray
            };

            var picUrl = "https://graph.windows.net/myorganization/users/" +cuRequest.UserPrincipalName + "/thumbnailPhoto?api-version";
            if (cuRequest.UserPrincipalName != null)
            {
                userImage.Source = ImageSource.FromUri(new Uri(picUrl));

            }
            else
            {
                //giftImage.Source = ImageSource.FromUri(new Uri("https://jailbreakbrewing.com/wp-content/uploads/2015/05/SRM-16"));
                userImage.Source = "infinite_xhalf.png";
            }

            Content = new StackLayout
            {
                Children = {
                    userImage, UserNameLabel
                }
            };
        }
    }
}
