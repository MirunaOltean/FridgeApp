using Project.ViewModels;
using Project.Views;
using Project.Views.Templates;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Project
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(RecipeDetailsPage), typeof(RecipeDetailsPage));
        }


        /// <summary>
        /// Called when clicking on the LogOut button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Current.GoToAsync($"//{nameof(LogInPage)}");
        }
    }
}
