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
    public class ByteImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = value as byte[];
            if (image == null)
                return null;
            return ImageSource.FromStream(() => new MemoryStream(image));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class UserDetailandCalendar : ContentPage
    {
        private byte[] tmpImage;
        private ListView listView;

        public Image userImage = new Image
        {
            Aspect = Aspect.AspectFit,
            BackgroundColor = Color.Gray
        };


        public UserDetailandCalendar(Model.Value cuRequest )
        {
            Title = cuRequest.DisplayName;

            listView = new ListView
            {

            };

            var UserNameLabel = new Label
            {
                FontAttributes = FontAttributes.Bold,
                Text = "Hello " + cuRequest.DisplayName,
                FontSize = 15
            };

 
            var picUrl = "https://graph.microsoft.com/beta/users/" + cuRequest.UserPrincipalName + "/photo/$value";
            //LoadImage(cuRequest);
            LoadCalendar(cuRequest);
            if (userImage.Source != null)
            {

            }
            else
            {
                userImage.Source = ImageSource.FromUri(new Uri("https://dm8cyuj6t42zr.cloudfront.net/wp-content/uploads/2015/05/09143949/SRM-14.png"));
            }

            Content = new StackLayout
            {
                Children = {
                   UserNameLabel, listView
                }
            };
        }

        private async void LoadImage(Model.Value cuRequest)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.AuthenticationResult.AccessToken);
            //var response = await client.GetStringAsync("https://graph.microsoft.com/beta/users");
            var response = await client.GetStringAsync("https://graph.microsoft.com/beta/users/" + cuRequest.UserPrincipalName + "/photo/$value");
            //var response = await client.GetStringAsync("https://graph.microsoft.com/beta/users/" + cuRequest.UserPrincipalName + "/photo");


            var assembly = typeof(ByteImageConverter).GetTypeInfo().Assembly;
            //var stream = assembly .GetManifestResourceStream("TestImage.c5qdlJqrb04.jpg");
            var stream = assembly.GetManifestResourceStream(response);
            using (var ms = new MemoryStream())
            {
                await stream.CopyToAsync(ms);
                byte[] myUserImge = ms.ToArray();
                userImage.Source = ImageSource.FromStream(() => new MemoryStream(myUserImge));
            }

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

        protected async override void OnAppearing()
        {
            base.OnAppearing();
        }



    }
}
