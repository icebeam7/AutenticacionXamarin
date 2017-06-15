using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using AutenticacionXamarin.Model;
using AutenticacionXamarin.Helpers;
using Newtonsoft.Json.Linq;

namespace AutenticacionXamarin.Services
{
    public class FacebookService
    {
        public async Task<FacebookProfile> GetFacebookProfileAsync(string accessToken)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{Constants.FacebookProfileInfoURL}{accessToken}");
                var profile = JsonConvert.DeserializeObject<FacebookProfile>(json);
                return profile;
            }
        }

        public string GetFacebookAccessToken(string url)
        {
            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace($"{Constants.FacebookRedirectURL}#access_token=", "");

                if (Xamarin.Forms.Device.OS == TargetPlatform.WinPhone || Xamarin.Forms.Device.OS == TargetPlatform.Windows)
                    at = url.Replace("http://www.facebook.com/connect/login_success.html#access_token=", "");

                var accessToken = at.Remove(at.IndexOf("&expires_in="));
                Settings.FacebookToken = accessToken;
                return accessToken;
            }

            return string.Empty;
        }

        public async Task<bool> DeleteToken(string clientId, string accessToken)
        {
            var url = $"https://graph.facebook.com/{clientId}/permissions?access_token={accessToken}";

            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return bool.Parse(JObject.Parse(result)["success"].ToString());
                }
            }

            return false;
        }
    }
}