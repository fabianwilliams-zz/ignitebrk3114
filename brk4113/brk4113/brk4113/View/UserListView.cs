using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using brk4113.Model;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace brk4113.View
{
    public class UserListView : ContentPage
    {
        private ListView listView;
        public List<UsersRequest> Users { get; private set; }

        public UserListView()
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

                Navigation.PushAsync(new UserDetailandCalendar(e.SelectedItem as Value));
                //RespondToSelectedItemClick(); //For testing only. just want to see if the PushAsync works
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            var response = await client.GetStringAsync("https://graph.microsoft.com/beta/users");
            var result = JsonConvert.DeserializeObject<UsersRequest>(response);
            listView.ItemsSource = result.Value;
            var cell = new DataTemplate(typeof(TextCell));
            //this below will use the default cell properties but will customize it later
            cell.SetBinding(TextCell.TextProperty, "DisplayName");
            listView.ItemTemplate = cell;

        }

    }
}
