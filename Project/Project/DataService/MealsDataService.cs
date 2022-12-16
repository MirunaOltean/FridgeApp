using Newtonsoft.Json;
using Project.Models;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using Xamarin.Forms.Internals;
using static Xamarin.Essentials.Permissions;
using System.Security.Permissions;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project.DataService
{
    [Preserve(AllMembers = true)]
    internal class MealsDataService
    {
        #region Private Fields

        private static MealsDataService mealsDataService;

        private RecipesListViewModel recipesListViewModel;

        public string content = "";

        #endregion

        #region Properties
        public static MealsDataService Instance => mealsDataService ?? (mealsDataService = new MealsDataService());
        public RecipesListViewModel RecipesListViewModel =>  
            recipesListViewModel ??
            (recipesListViewModel = PopulateData<RecipesListViewModel>("meals.json"));

        #endregion

        #region Private Methods

        //private async Task ReadAPI()
        //{
        //    try
        //    {
        //        string URL = "https://www.themealdb.com/api/json/v1/1/search.php?f=a";

        //        HttpClient httpClient = new HttpClient();
        //        HttpResponseMessage response = await httpClient.GetAsync(new Uri(URL));

        //        if (response.IsSuccessStatusCode)
        //        {
        //            content = await response.Content.ReadAsStringAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.TraceWarning(ex.Message);
        //    }
        //}
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
