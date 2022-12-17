using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.Models;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
            zxing.OnScanResult += (result) => Device.BeginInvokeOnMainThread(async () => {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://api.barcodelookup.com/v3/products?barcode="+ result.Text + "&formatted=y&key=v95um7wenyhl6qakf38ov35paxpu1r");
                try
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var json = (JObject)JsonConvert.DeserializeObject(responseBody);
                    description.Text = json["products"][0]["title"].ToString();
                    text.Text = json["products"][0]["images"].First.ToString();
                    lblresult.Text = result.Text;
                }
                catch 
                {
                    lblresult.Text ="Something didn't work";
                }
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            zxing.IsScanning = true;
        }
        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;
            base.OnDisappearing();
        }
    }
}