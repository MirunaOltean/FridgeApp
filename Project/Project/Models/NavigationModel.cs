using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace Project.Models
{
    /// <summary>
    /// Model for the Navigation List and Tile with Cards page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class NavigationModel
    {
        #region Field

        private string itemImage;

        #endregion

        #region Properties

        [DataMember(Name = "itemName")]
        public string ItemName { get; set; }

        [DataMember(Name = "itemDescription")]
        public string ItemDescription { get; set; }

        [DataMember(Name = "itemImage")]
        public string ItemImage
        {
            get
            {
                return App.ImageServerPath + this.itemImage;
            }

            set
            {
                this.itemImage = value;
            }
        }

        [DataMember(Name = "itemRating")]
        public double ItemRating { get; set; }

        #endregion
    }
}