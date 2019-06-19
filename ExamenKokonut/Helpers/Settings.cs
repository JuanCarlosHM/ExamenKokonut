namespace ExamenKokonut.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;

    public static class Settings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current; 
            }
        }

        #region Atribbutes

        const string token = "Token";
        const string tokenType = "TokenType";

        const string userName = "Name";
        const string userLastName = "LastName";
        const string email = "Email";
        const string date = "Date";
 
        #endregion


        static readonly string stringDefault = string.Empty;


         public static string Token
        {
            get
            {
                return AppSettings.GetValueOrDefault(token, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(token, value);
            }
        }

        public static string TokenType
        {
            get
            {
                return AppSettings.GetValueOrDefault(tokenType, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(tokenType, value);
            }
        }



        public static string Name
        {
            get
            {
                return AppSettings.GetValueOrDefault(userName, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(userName, value);
            }
        }


        public static string LastName
        {
            get
            {
                return AppSettings.GetValueOrDefault(userLastName, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(userLastName, value);
            }
        }



        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault(email, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(email, value);
            }
        }


        public static string Date
        {
            get
            {
                return AppSettings.GetValueOrDefault(date, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(date, value);
            }
        }




    }
}
 