using Project.Models;
using Project.Views;
using Project.Views.Templates;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Model = Project.Models.Story;
using NavigationModel = Project.Models.NavigationModel;

namespace Project.ViewModels
{
    /// <summary>
    /// ViewModel for Recipe with comments page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    [DataContract]
    public class RecipeDetailsPageViewModel : BaseViewModel
    {
        #region Fields

        private Meal selectedItem;

        private bool isFavourite;
        private bool isBookmarked;
        private ObservableCollection<Model> contentList;

        private Command favouriteCommand;
        private Command bookmarkCommand;

        #endregion

        #region Constructor

        public RecipeDetailsPageViewModel()
        {
        }

        #endregion

        #region Public properties

        [DataMember(Name = "selectedItem")]
        public Meal SelectedItem
        {
            get => selectedItem;
            set 
            {
                this.SetProperty(ref selectedItem, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the recipe is favourite or not.
        /// </summary>
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }

            set
            {
                this.SetProperty(ref this.isFavourite, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the recipe is bookmarked or not.
        /// </summary>
        public bool IsBookmarked
        {
            get
            {
                return this.isBookmarked;
            }

            set
            {
                this.SetProperty(ref this.isBookmarked, value);
            }
        }

        /// <summary>
        /// Gets or sets the property has been bound with the list view which displays the recipes content list items.
        /// </summary>
        [DataMember(Name = "contentList")]
        public ObservableCollection<Model> ContentList
        {
            get
            {
                return this.contentList;
            }

            set
            {
                if (this.contentList == value)
                {
                    return;
                }

                this.SetProperty(ref this.contentList, value);
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command FavouriteCommand
        {
            get
            {
                return this.favouriteCommand ?? (this.favouriteCommand = new Command(this.FavouriteButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command is executed when the book mark button is clicked.
        /// </summary>
        public Command BookmarkCommand
        {
            get
            {
                return this.bookmarkCommand ?? (this.bookmarkCommand = new Command(this.BookmarkButtonClicked));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the favourite button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void FavouriteButtonClicked(object obj)
        {
            if (obj != null && (obj is RecipeDetailsPageViewModel))
            {
                (obj as RecipeDetailsPageViewModel).IsFavourite = !(obj as RecipeDetailsPageViewModel).IsFavourite;
            }
        }

        private void BookmarkButtonClicked(object obj)
        {
            if (obj != null && (obj is RecipeDetailsPageViewModel))
            {
                (obj as RecipeDetailsPageViewModel).IsBookmarked = !(obj as RecipeDetailsPageViewModel).IsBookmarked;
            }
        }
        #endregion
    }
}
