using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace brk4113.View
{
    public class UserListView : ContentPage
    {
        public UserListView()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Placeholder User Page" }
                }
            };
        }
    }
}
