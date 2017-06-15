// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace AutenticacionXamarin.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string SettingsKey = "settings_key";
    private static readonly string SettingsDefault = string.Empty;

    private const string SettingsFacebookToken = "facebook_token";
    private static readonly string SettingsFacebookTokenDefault = string.Empty;

    private const string SettingsFacebookId = "facebook_id";
    private static readonly string SettingsFacebookIdDefault = string.Empty;

    #endregion
    
    public static string GeneralSettings
    {
      get { return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault); }
      set { AppSettings.AddOrUpdateValue<string>(SettingsKey, value); }
    }

    public static string FacebookToken
    {
        get { return AppSettings.GetValueOrDefault<string>(SettingsFacebookToken, SettingsFacebookTokenDefault); }
        set { AppSettings.AddOrUpdateValue<string>(SettingsFacebookToken, value); }
    }

    public static string FacebookID
    {
        get { return AppSettings.GetValueOrDefault<string>(SettingsFacebookId, SettingsFacebookIdDefault); }
        set { AppSettings.AddOrUpdateValue<string>(SettingsFacebookId, value); }
    }
  }
}