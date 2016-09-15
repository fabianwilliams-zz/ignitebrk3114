using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using brk4113.Model;
using Xamarin.Forms;

namespace brk4113.View
{
    public class MyEmailDetail : ContentPage
    {
        public MyEmailDetail( MailItem myMailItem)
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}
