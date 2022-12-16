using Project.Models;
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
        private static RecipeDetailsPageViewModel recipeWithCommentsPageViewModel;

        private string recipeName;
        private string recipeImage;
        private string recipeSubImage;
        private string recipeAuthor;
        private string recipeDate;
        private string recipeContent;
        private string recipeReadingTime;
        private bool isFavourite;
        private bool isBookmarked;
        private ObservableCollection<Model> contentList;
        private string subTitle;
        private ObservableCollection<Review> reviews;

        private Command favouriteCommand;
        private Command bookmarkCommand;
        private Command relatedFeaturesCommand;
        private Command loadMoreCommand;
        private Command addNewCommentCommand;

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
                RecipeContent = SelectedItem.Instructions;
            }
        }


        /// <summary>
        /// Gets or sets the recipe image
        /// </summary>
        [DataMember(Name = "recipeImage")]
        public string RecipeImage
        {
            get
            {
                return App.ImageServerPath + this.recipeImage;
            }

            set
            {
                if (this.recipeImage != value)
                {
                    this.SetProperty(ref this.recipeImage, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the recipe sub image
        /// </summary>
        [DataMember(Name = "recipeSubImage")]
        public string RecipeSubImage
        {
            get
            {
                return App.ImageServerPath + this.recipeSubImage;
            }

            set
            {
                if (this.recipeSubImage != value)
                {
                    this.SetProperty(ref this.recipeSubImage, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the recipeAuthor
        /// </summary>
        [DataMember(Name = "recipeAuthor")]
        public string RecipeAuthor
        {
            get
            {
                return this.recipeAuthor;
            }

            set
            {
                if (this.recipeAuthor != value)
                {
                    this.SetProperty(ref this.recipeAuthor, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the recipe reading time
        /// </summary>
        [DataMember(Name = "recipeReadingTime")]
        public string RecipeReadingTime
        {
            get
            {
                return this.recipeReadingTime;
            }

            set
            {
                if (this.recipeReadingTime != value)
                {
                    this.SetProperty(ref this.recipeReadingTime, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the recipe date
        /// </summary>
        [DataMember(Name = "recipeDate")]
        public string RecipeDate
        {
            get
            {
                return this.recipeDate;
            }

            set
            {
                if (this.recipeDate != value)
                {
                    this.SetProperty(ref this.recipeDate, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the recipe content
        /// </summary>
        [DataMember(Name = "recipeContent")]
        public string RecipeContent
        {
            get
            {
                return this.recipeContent;
            }

            set
            {
                if (this.recipeContent != value)
                {
                    this.SetProperty(ref this.recipeContent, value);
                }
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

        /// <summary>
        /// Gets or sets the recipe sub title
        /// </summary>
        [DataMember(Name = "subTitle1")]
        public string SubTitle
        {
            get
            {
                return this.subTitle;
            }

            set
            {
                if (this.subTitle == value)
                {
                    return;
                }

                this.SetProperty(ref this.subTitle, value);
            }
        }

        /// <summary>
        /// Gets or sets the recipe reviews
        /// </summary>
        [DataMember(Name = "reviews")]
        public ObservableCollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }

            set
            {
                if (this.reviews == value)
                {
                    return;
                }

                this.SetProperty(ref this.reviews, value);
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

        /// <summary>
        /// Gets the command is executed when the related features item is clicked.
        /// </summary>
        public Command RelatedFeaturesCommand
        {
            get
            {
                return this.relatedFeaturesCommand ?? (this.relatedFeaturesCommand = new Command(this.RelatedFeaturesItemClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when the Show All button is clicked.
        /// </summary>
        public Command LoadMoreCommand
        {
            get
            {
                return this.loadMoreCommand ?? (this.loadMoreCommand = new Command(this.LoadMoreClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when the add new comment is clicked.
        /// </summary>
        public Command AddNewCommentCommand
        {
            get
            {
                return this.addNewCommentCommand ?? (this.addNewCommentCommand = new Command(this.AddNewCommentClicked));
            }
        }

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

        /// <summary>
        /// Invoked when the favourite button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void FavouriteButtonClicked(object obj)
        {
            if (obj != null && (obj is RecipeDetailsPageViewModel))
            {
                (obj as RecipeDetailsPageViewModel).IsFavourite = (obj as RecipeDetailsPageViewModel).IsFavourite ? false : true;
            }
        }

        private void RelatedFeaturesItemClicked(object obj)
        {
            // Do something
        }

        private void BookmarkButtonClicked(object obj)
        {
            if (obj != null && (obj is RecipeDetailsPageViewModel))
            {
                (obj as RecipeDetailsPageViewModel).IsBookmarked = (obj as RecipeDetailsPageViewModel).IsBookmarked ? false : true;
            }
        }

        /// <summary>
        /// Invoked when Load more button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoadMoreClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when Add new comment is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddNewCommentClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
