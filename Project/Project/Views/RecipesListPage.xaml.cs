using Project.DataService;
using Project.Models;
using Project.ViewModels;
using Syncfusion.XForms.EffectsView;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesListPage : ContentPage
    {
        public RecipesListPage()
        {
            InitializeComponent();
            BindingContext = MealsDataService.Instance.RecipesListViewModel;
        }

        private void OnEffectsViewAnimationCompleted(object sender, EventArgs e)
        {
            var effectsView = sender as SfEffectsView;
            Meal selectedItem = effectsView.BindingContext as Meal;

            Navigation.PushAsync(new RecipeDetailsPage(selectedItem));
        }
    }
}