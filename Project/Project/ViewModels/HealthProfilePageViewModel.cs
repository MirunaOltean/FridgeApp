using Project.DataService;
using Project.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Project.ViewModels
{
    /// <summary>
    /// ViewModel for health profile page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class HealthProfilePageViewModel : BaseViewModel
    {
        #region Private Fields

        private Person person;
        private List<HealthProfileCardItem> cardItem;
        private Command<object> itemTappedCommand;

        #endregion

        #region Properties

        [DataMember(Name = "person")]
        public Person Person
        {
            get => person;
            set
            {
                this.SetProperty(ref person, value);
            }
        }

        [DataMember(Name = "cardItems")]
        public List<HealthProfileCardItem> CardItems
        {
            get => cardItem;
            set
            {
                this.SetProperty(ref cardItem, value);
            }
        }

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

        #endregion

        #region Methods


        /// <summary>
        /// Invoked when an item is selected from the health profile page.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        #endregion
    }
}