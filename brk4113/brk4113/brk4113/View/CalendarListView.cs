using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using brk4113.Model;
using Xamarin.Forms;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection;
using brk4113.Model.Event;
using brk4113.View.Cells;

namespace brk4113.View
{
    public class CalendarListView : ContentPage
    {
        private ListView listView;
        public CalendarListView()
        {
            listView = new ListView
            {

            };


            Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Spacing = 3,
                Orientation = StackOrientation.Vertical,

                Children = {
                    listView
                }
            };

            listView.ItemSelected += (sender, e) =>
            {

                Navigation.PushAsync(new MyCalendarDetail(e.SelectedItem as CalendarListView));
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            var response = await client.GetStringAsync("https://graph.microsoft.com/beta/me/events");
            var result = JsonConvert.DeserializeObject<RootObject>(response);
            listView.ItemsSource = result.value;
            var cell = new DataTemplate(typeof(TextCell));
            //this below will use the default cell properties but will customize it later
            cell.SetBinding(TextCell.TextProperty, "subject");
            //cell.SetBinding(TextCell.TextProperty, "organizer.emailAddress.address");
            listView.ItemTemplate = cell;
            //OK this below is a customized cell that will render more informaiton in 1 row in the List View
            //listView.ItemTemplate = new DataTemplate(typeof(EventOrgCell)); //this uses my customized cell to make 2 items in 1 row
            //listView.ItemTemplate = new DataTemplate(typeof(EventNameOrgnAddrCell)); //this uses my customized cell to make 2 items in 1 row


        }

        private async void LoadCalendar(Model.Value cuRequest)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            //var response = await client.GetStringAsync("https://graph.microsoft.com/beta/users");
            //var response = await client.GetStringAsync("https://graph.microsoft.com/beta/users/" + cuRequest.UserPrincipalName + "/events");
            var response = await client.GetStringAsync("https://graph.microsoft.com/beta/me/events");
            var result = JsonConvert.DeserializeObject<RootObject>(response);
            listView.ItemsSource = result.value;
            var cell = new DataTemplate(typeof(TextCell));
            //this below will use the default cell properties but will customize it later
            //cell.SetBinding(TextCell.TextProperty, "subject");
            //cell.SetBinding(TextCell.TextProperty, "organizer.emailAddress.address");
            //listView.ItemTemplate = cell;
            //OK this below is a customized cell that will render more informaiton in 1 row in the List View
            //listView.ItemTemplate = new DataTemplate(typeof(EventOrgCell)); //this uses my customized cell to make 2 items in 1 row
            listView.ItemTemplate = new DataTemplate(typeof(EventNameOrgnAddrCell)); //this uses my customized cell to make 2 items in 1 row
        }
    }
}
