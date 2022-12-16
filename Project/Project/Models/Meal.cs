using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Project.Models
{
    public class Meal
    {
        #region Field

        private string recipeImage;

        #endregion

        #region Properties

        [DataMember(Name = "idMeal")]
        public string IdMeal { get; set; }


        [DataMember(Name = "name")]
        public string Name { get; set; }


        [DataMember(Name = "drinkAlternate")]
        public object DrinkAlternate { get; set; }


        [DataMember(Name = "category")]
        public string Category { get; set; }


        [DataMember(Name = "area")]
        public string Area { get; set; }


        [DataMember(Name = "instructions")]
        public string Instructions { get; set; }


        [DataMember(Name = "mealThumb")]
        public string MealThumb { get; set; }


        [DataMember(Name = "tags")]
        public string Tags { get; set; }


        [DataMember(Name = "youtube")]
        public string Youtube { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Measures { get; set; }
        public string Source { get; set; }


        [DataMember(Name = "imageSource")]
        public string ImageSource
        {
            get => recipeImage;
            set
            {
                if (value != null)
                    recipeImage = value;
            }
        }

        public object CreativeCommonsConfirmed { get; set; }
        public object DateModified { get; set; }

        #endregion
    }
}
