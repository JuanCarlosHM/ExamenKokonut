namespace ExamenKokonut.ViewModel
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using ExamenKokonut.Helpers;
    using ExamenKokonut.Model;
    using ExamenKokonut.Services;
    using ExamenKokonut.View;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class LogInViewModel : BaseViewModel
    {
        #region APIServices 
        private readonly APIService apiService;
        private DataService dataService;

        #endregion


        #region Atributes 
        private string email;
        private string passowrd;
        private bool isEnable;


        private MainViewModel mainViewModel;

        private ProfileData profileResponse;
        #endregion


        #region Properties
        public bool IsEnable
        {
            get { return this.isEnable; }
            set { SetValue(ref this.isEnable, value); }
        }

        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.passowrd; }
            set { SetValue(ref this.passowrd, value); }
        }

     
        #endregion

        #region Commands
        public ICommand LogInCommand
        {
            get { return new RelayCommand(LogIn); }
        } 
        #endregion


        #region Methods 
        private async void LogIn()
        {
            this.IsEnable = false;

            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar tu Correo electronico",
                    "Aceptar");
                return; 
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar tu Contraseña",
                    "Aceptar");
                return;
            }

            this.IsEnable = false;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSucces)
            {
                this.IsEnable = false;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            var token = await this.apiService.GetToken(
                "http://dev.estandares.kokonutstudio.com:8080/api/login",
                "CrossPlatform1.0",
                "es_mx",
                "application/json",
                this.email,
                this.Password);

            if (token == null)
            {
                await Application.Current.MainPage.DisplayAlert(
                 "Error",
                 "Datos de acceso incorrectos",
                 "Aceptar");

                this.Password = string.Empty;
                this.IsEnable = true;
                return;

            }

            mainViewModel = MainViewModel.GetInstance();

            mainViewModel.Token = token.DataLog.AccessToken;
            mainViewModel.TokenType = token.DataLog.TokenType;

            Settings.Token = token.DataLog.AccessToken;
            Settings.TokenType = token.DataLog.TokenType;

            mainViewModel.Products = new ProductsViewModel();
    

            // Profile
            var responseProfile = await this.apiService.Get<ProfileData>(
                "http://dev.estandares.kokonutstudio.com:8080",
                "/api",
                "/user/profile",
                "CrossPlatform1.0",
                "es_mx",
                "application/json",
                Settings.Token);

            this.profileResponse = (ProfileData)responseProfile.Result;

            Settings.Name = profileResponse.DataLog.Name;
            Settings.LastName = profileResponse.DataLog.LastName;
            Settings.Email = profileResponse.DataLog.Email;
            Settings.Date = profileResponse.DataLog.CreatedAt.Date.ToString();

            this.IsEnable = true;
            Application.Current.MainPage = new NavigationPage(new HomeTabbedPage());


            this.Email = string.Empty;
            this.Password = string.Empty;

            
        }

     
        #endregion






        #region Constructors 
        public LogInViewModel()
        {
            this.IsEnable = true;
            this.apiService = new APIService();
            this.dataService = new DataService();
            //email = "android@kokonutstudio.com";
            //passowrd = "12345678";

        }
        #endregion

    } // end Class

}
