using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ComplGen
{
    public partial class MainPage : ContentPage
    {
        public class PickupText
        {
            public string id { get; set; }
            public string username { get; set; }
            public string tweet { get; set; }
            public string version { get; set; }
        }
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("http://pebble-pickup.herokuapp.com/tweets/random"))
                {
                    using (HttpContent content = response.Content)
                    {
                        var mycontent = await content.ReadAsStringAsync();
                        PickupText someText = JsonConvert.DeserializeObject<PickupText>(mycontent);
                        Console.WriteLine(someText.tweet);
                       await DisplayAlert("Compliment", someText.tweet, "Okay");
                    }
                }

            }
            

        }
    }
}
