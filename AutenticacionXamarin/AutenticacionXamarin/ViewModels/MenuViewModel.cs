using System.Threading.Tasks;
using Xamarin.Forms;

namespace AutenticacionXamarin.ViewModels
{
    public class MenuViewModel
    {
        public Command FacebookLoginCommand { get; set; }

        public INavigation Navigation;

        public MenuViewModel()
        {
            FacebookLoginCommand = new Command(async () => await ExecuteFacebookLoginCommand(Navigation));
        }

        async Task ExecuteFacebookLoginCommand(INavigation navigation)
        {
            await navigation.PushAsync(new View.FacebookLoginView());
        }
    }
}
