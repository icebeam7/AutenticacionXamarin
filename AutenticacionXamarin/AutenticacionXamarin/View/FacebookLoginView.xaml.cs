using AutenticacionXamarin.Helpers;
using AutenticacionXamarin.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutenticacionXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FacebookLoginView : ContentPage
    {
        public FacebookLoginView()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (string.IsNullOrEmpty(Settings.FacebookToken) || string.IsNullOrEmpty(Settings.FacebookID))
                webview.Source = Constants.FacebookRequestURL;
            else
                await Navigation.PushAsync(new FacebookProfileView(Settings.FacebookToken));
        }

        private void webview_Navigated(object sender, WebNavigatedEventArgs e)
        {
            var accessToken = new FacebookService().GetFacebookAccessToken(e.Url);

            if (accessToken != "")
            {
                Navigation.PushAsync(new FacebookProfileView(accessToken));
            }
        }
    }
}
