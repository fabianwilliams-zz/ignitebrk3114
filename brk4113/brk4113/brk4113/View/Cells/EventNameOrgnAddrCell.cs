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

                Font = Font.SystemFontOfSize(NamedSize.Micro)
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
                Font = Font.SystemFontOfSize(NamedSize.Small),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            nameLabel.SetBinding(Label.TextProperty, "organizer.emailAddress.name");


            var emailaddrLabel = new Label
            {
                Font = Font.SystemFontOfSize(NamedSize.Micro),
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            emailaddrLabel.SetBinding(Label.TextProperty, "organizer.emailAddress.address");

            var nameLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { nameLabel, emailaddrLabel }
            };
            return nameLayout;
        }
    }
}
