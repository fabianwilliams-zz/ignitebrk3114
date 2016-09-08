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

        public UserDetailandCalendar(UsersRequest cuRequest )
        {
            this.Title = cuRequest.Value[0].DisplayName;
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello" + Title }
                }
            };
        }
    }
}
