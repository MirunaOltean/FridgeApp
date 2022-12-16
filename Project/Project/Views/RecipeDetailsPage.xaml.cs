using Project.ViewModels;
using System.Threading.Tasks;
using System;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using Newtonsoft.Json;
using Project.Models;
using NavigationModel = Project.Models.NavigationModel;

namespace Project.Views
{
    /// <summary>
    /// Article with comments page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(Jason), nameof(jason))]
    public partial class RecipeDetailsPage : ContentPage
    {
        private string jason;
        private readonly RecipeDetailsPageViewModel recipeDetailsPageViewModel = new RecipeDetailsPageViewModel();
        public string Jason
        {
            get => jason;
            set
            {
                jason = value;
                string derulo = Uri.UnescapeDataString(value);
                recipeDetailsPageViewModel.SelectedItem = Task.Run(() => JsonConvert.DeserializeObject<Meal>(derulo)).Result;
               
            }
        }

        public RecipeDetailsPage(Meal selectedItem)
        {
            InitializeComponent();
            BindingContext = new RecipeDetailsPageViewModel();
            (BindingContext as RecipeDetailsPageViewModel).SelectedItem = selectedItem;
        }
    }
}