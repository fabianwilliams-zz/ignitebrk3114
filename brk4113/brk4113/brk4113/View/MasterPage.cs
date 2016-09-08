using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace brk4113.View
{
    public class MasterPage : TabbedPage
    {
        public MasterPage()
        {
            this.Children.Add(new UserListView() {Title = "Employees", Icon = "Icon-Small.png"});
            this.Children.Add(new CalendarListView() { Title = "Appointments", Icon = "Icon-Small.png" });
            this.Children.Add(new MailListView() { Title = "Emails", Icon = "Icon-Small.png" });
        }
    }
}
