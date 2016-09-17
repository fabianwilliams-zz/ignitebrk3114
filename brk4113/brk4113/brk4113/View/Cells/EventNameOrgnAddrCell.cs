using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace brk4113.View.Cells
{
    public class EventNameOrgnAddrCell : ViewCell
    {
        public EventNameOrgnAddrCell()
        {

            var OrganizerNameLabel = new Label
            {

                Font = Font.SystemFontOfSize(NamedSize.Medium)
            };
            OrganizerNameLabel.SetBinding(Label.TextProperty, new Binding("subject"));

            var nameLayout = CreateNameLayout();

            var viewLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = { OrganizerNameLabel, nameLayout }
            };
            View = viewLayout;


        }

        static StackLayout CreateNameLayout()
        {


            var nameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            nameLabel.SetBinding(Label.TextProperty, "organizer.emailAddress.name");


            var emailaddrLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            emailaddrLabel.SetBinding(Label.TextProperty, "organizer.emailAddress.address");

            var nameLayout = new StackLayout()
            {
                //HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { nameLabel }
            };
            return nameLayout;
        }
    }
}
