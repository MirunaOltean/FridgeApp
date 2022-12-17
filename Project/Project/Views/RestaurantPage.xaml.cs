using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Project.DataService;
using System.Net.Http;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using ZXing;
using Project.Models;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Xml.Linq;
using System.Linq;
using System;

namespace Project.Views
{
    /// <summary>
    /// Page to show the Restaurant page details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantPage : ContentPage
    {
        List<Restaurant> restaurants;
        public RestaurantPage()
        {
            Restaurants();
            this.InitializeComponent();
        }

        protected async void Restaurants()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            //await location.OpenMapsAsync();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://maps.googleapis.com/maps/api/place/nearbysearch/json?keyword=supermarket&location="+location.Latitude.ToString()+","+location.Longitude.ToString()+"&radius=10000&type=supermarket&key=AIzaSyBEAy46w4BOQFGKmfDHnr9cBH1hB6sau4o");
            try
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var json = (JObject)JsonConvert.DeserializeObject(responseBody);
                var results = json["results"];
                restaurants = new List<Restaurant>();
                for(int i=0;i<results.Count();i++)
                {
                    var result = results[i];
                    Restaurant restaurant = new Restaurant();
                    restaurant.RestaurantImage = result["icon"].ToString();
                    restaurant.Name = result["name"].ToString();
                    restaurant.Description = result["vicinity"].ToString();
                    restaurant.ItemRating = result["rating"].ToString();
                    restaurants.Add(restaurant);

                }

            }
            catch
            {

            }
            foreach (var item in restaurants)
            {
                RestaurantDataService.Instance.RestaurantPageViewModel.NavigationList.Add(item);
            }
            this.BindingContext = RestaurantDataService.Instance.RestaurantPageViewModel;
        }
    }
}