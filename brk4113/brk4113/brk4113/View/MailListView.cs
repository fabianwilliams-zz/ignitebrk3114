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
    public class MailListView : ContentPage
    {
        private ListView listView;
        public List<MailItem> myMail { get; private set; }

        public MailListView()
        {
            listView = new ListView
            {

            };


            Content = new StackLayout
            {
                Children = {
                    listView
                }
            };

            listView.ItemSelected += (sender, e) =>
            {

                Navigation.PushAsync(new MyEmailDetail(e.SelectedItem as MailItem));
            };
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            var response = await client.GetStringAsync("https://graph.microsoft.com/beta/me/messages");
            var result = JsonConvert.DeserializeObject<MailResponse>(response);
            listView.ItemsSource = result.Value;
            var cell = new DataTemplate(typeof(TextCell));
            //this below will use the default cell properties but will customize it later
            cell.SetBinding(TextCell.TextProperty, "Subject");
            listView.ItemTemplate = cell;

        }
    }
}
