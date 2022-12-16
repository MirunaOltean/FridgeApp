using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace Project.Models
{
    /// <summary>
    /// Model for the Restaurant page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Restaurant
    {
        #region Field

        private string restaurantImage;

        #endregion

        #region Properties

        [DataMember(Name = "itemImage")]
        public string RestaurantImage
        {
            get
            {
                return App.ImageServerPath + this.restaurantImage;
            }

            set
            {
                this.restaurantImage = value;
            }
        }


        [DataMember(Name = "name")]
        public string Name { get; set; }


        [DataMember(Name = "description")]
        public string Description { get; set; }

  
        [DataMember(Name = "offer")]
        public string Offer { get; set; }


        [DataMember(Name = "itemRating")]
        public string ItemRating { get; set; }

        #endregion
    }
}
