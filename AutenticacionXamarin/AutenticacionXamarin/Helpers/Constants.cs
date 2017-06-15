namespace AutenticacionXamarin.Helpers
{
    public static class Constants
    {
        public static string FacebookAppID = "1707741476198627";

        public static string FacebookRedirectURL = "https://www.facebook.com/connect/login_success.html";

        public static string FacebookRequestURL = $"https://www.facebook.com/dialog/oauth?client_id={FacebookAppID}&display=popup&response_type=token&redirect_uri={FacebookRedirectURL}";

        public static string FacebookProfileInfoURL = "https://graph.facebook.com/v2.9/me/?fields=name,picture,work,website,religion,location,locale,link,cover,age_range,birthday,devices,email,first_name,last_name,gender,hometown,is_verified,languages&access_token=";


    }
}
