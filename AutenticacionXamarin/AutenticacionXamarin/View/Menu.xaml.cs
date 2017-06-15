using AutenticacionXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutenticacionXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        MenuViewModel viewModel;

        public Menu()
        {
            InitializeComponent();

            viewModel = new MenuViewModel();
            viewModel.Navigation = Navigation;

            this.BindingContext = viewModel;
        }
    }
}
