using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutenticacionXamarin.Model;
using AutenticacionXamarin.Services;

namespace AutenticacionXamarin.ViewModels
{
    public class FacebookProfileViewModel : INotifyPropertyChanged
    {
        private FacebookProfile _facebookProfile;

        public FacebookProfile FacebookProfile
        {
            get { return _facebookProfile; }
            set
            {
                _facebookProfile = value;
                OnPropertyChanged();
            }
        }

        public async Task GetFacebookProfileAsync(string accessToken)
        {
            var service = new FacebookService();
            FacebookProfile = await service.GetFacebookProfileAsync(accessToken);
            Helpers.Settings.FacebookID = FacebookProfile.Id;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
