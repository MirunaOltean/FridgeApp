using Newtonsoft.Json;
using Project.Models;
using Project.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using NavigationModel = Project.Models.NavigationModel;

namespace Project.ViewModels
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class RecipesListViewModel : BaseViewModel
    {
        #region Fields

        private Command<object> itemTappedCommand;
        private NavigationModel navigationModel;

        #endregion

        #region Constructor
        public RecipesListViewModel()
        {
        }

        #endregion

        #region Properties

        [DataMember(Name = "meals")]
        public ObservableCollection<Meal> RecipesList { 
            get; 
            set; 
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
        /// Invoked when an item is selected from the navigation list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        #endregion
    }
}