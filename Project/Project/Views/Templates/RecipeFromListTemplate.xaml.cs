using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Project.Views.Templates
{
    /// <summary>
    /// Navigation tile template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeFromListTemplate : Grid
    {
        public RecipeFromListTemplate()
        {
            this.InitializeComponent();
        }
    }
}