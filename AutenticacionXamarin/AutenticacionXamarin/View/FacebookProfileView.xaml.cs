using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AutenticacionXamarin.ViewModels;

namespace AutenticacionXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FacebookProfileView : ContentPage
    {
        FacebookProfileViewModel viewModel;
        string token;

        public FacebookProfileView(string token)
        {
            InitializeComponent();

            viewModel = new FacebookProfileViewModel();
            this.BindingContext = viewModel;
            this.token = token;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.GetFacebookProfileAsync(token);
        }

        private async void GenerarNuevoToken_Clicked(object sender, EventArgs e)
        {
            if (await new Services.FacebookService().DeleteToken(Helpers.Settings.FacebookID, Helpers.Settings.FacebookToken))
            {
                Helpers.Settings.FacebookID = string.Empty;
                Helpers.Settings.FacebookToken = string.Empty;
                await Navigation.PopToRootAsync();
            }
        }
    }
}
