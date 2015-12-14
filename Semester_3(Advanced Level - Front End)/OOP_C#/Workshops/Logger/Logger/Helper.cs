namespace Logger
{
    using System.Collections.Specialized;
    using System.Configuration;

    public static class Helper
    {
        public static string GetAppSettings(string keyStr)
        {
            NameValueCollection section = ConfigurationManager.GetSection("myAppSettings") as NameValueCollection;

            return section[keyStr];
        }

    }
}