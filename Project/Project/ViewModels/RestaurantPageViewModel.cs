using Project.Models;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Project.ViewModels
{
    /// <summary>
    /// ViewModel for the Restaurant list .
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class RestaurantPageViewModel : BaseViewModel
    {
        #region Fields

        private Command<object> itemTappedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="RestaurantPageViewModel"/> class.
        /// </summary>
        public RestaurantPageViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command<object>(this.NavigateToNextPage));
            }
        }

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the Restaurant page.
        /// </summary>
        [DataMember(Name = "navigationList")]
        public ObservableCollection<Restaurant> NavigationList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the navigation list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            Restaurant restaurant = (Restaurant)selectedItem;
            if (Device.RuntimePlatform == Device.iOS)
            {
                 Launcher.OpenAsync("http://maps.apple.com/?q=" + restaurant.Description);
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                // open the maps app directly
                Launcher.OpenAsync("geo:0,0?q=" + restaurant.Description);
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                Launcher.OpenAsync("bingmaps:?where=" + restaurant.Description);
            }
        }

        #endregion
    }
}
