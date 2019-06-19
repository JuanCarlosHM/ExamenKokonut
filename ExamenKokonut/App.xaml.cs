namespace ExamenKokonut
{
    using ExamenKokonut.Helpers;
    using ExamenKokonut.View;
    using ExamenKokonut.ViewModel;
    using Xamarin.Forms;
    using ExamenKokonut.Services;
    using ExamenKokonut.Model;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Settings.Token))
            {
                MainPage = new LogInPage();
            }
            else
            {
                var dataService = new DataService();
                //var favorites = dataService.GetAllProducts();

                
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
                mainViewModel.Products = new ProductsViewModel();
                mainViewModel.Profile = new ProfileViewModel(); 
                this.MainPage = new NavigationPage( new HomeTabbedPage());
                //mainViewModel.ProductL = favorites;
            }

        }

        #region LifeCycle

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        #endregion


    } // end Class 
}
