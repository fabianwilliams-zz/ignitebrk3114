using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace brk4113.View.Cells
{
    public class EventOrgCell : ViewCell
    {
        public EventOrgCell()
        {
            var OrganizerNameLabel = new Label
            {

                Font = Font.SystemFontOfSize(NamedSize.Medium)
            };
            OrganizerNameLabel.SetBinding(Label.TextProperty, new Binding("organizer.emailAddress.name"));

            var OrganizerEmailAddr = new Label
            {
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                XAlign = TextAlignment.End,
                HorizontalOptions = LayoutOptions.FillAndExpand

            };
            OrganizerEmailAddr.SetBinding(Label.TextProperty, new Binding("organizer.emailAddress.address"));


            View = new StackLayout
            {
                Children = { OrganizerNameLabel, OrganizerEmailAddr },
                Orientation = StackOrientation.Horizontal

            };
        }
    }
}
