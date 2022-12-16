using Newtonsoft.Json;
using Project.Models;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace Project.DataService
{
    [Preserve(AllMembers = true)]
    public class RestaurantDataService
    {
        #region fields

        private static RestaurantDataService restaurantDataService;

        private RestaurantPageViewModel restaurantViewModel;

        #endregion

        #region Properties

        public static RestaurantDataService Instance => restaurantDataService ?? (restaurantDataService = new RestaurantDataService());

        public RestaurantPageViewModel RestaurantPageViewModel =>
            this.restaurantViewModel ??
            (this.restaurantViewModel = PopulateData<RestaurantPageViewModel>("navigation.json"));

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        private static T PopulateData<T>(string fileName)
        {
            var file = "Project.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            T data;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                data = (T)serializer.ReadObject(stream);
            }
            return data;
        }   
        #endregion
    }

}
