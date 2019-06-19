namespace ExamenKokonut.ViewModel
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using ExamenKokonut.Helpers;
    using ExamenKokonut.Model;
    using ExamenKokonut.Services;
    using ExamenKokonut.View;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    using System.Threading.Tasks;
    using System.Collections.ObjectModel;

    public class ProfileViewModel : BaseViewModel
    {

        #region DataServices
        private DataService dataService;
        #endregion

        #region Atributes 
        private string name;
        private string lastName;
        private string email;
        private string date;
        private MainViewModel mainViewModel; 

        private List<ProductLocal> favorites;
        #endregion

        #region Properties
        public string Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }

        }

        public string LastName
        {
            get { return this.lastName; }
            set { SetValue(ref this.lastName, value); }

        }

        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }

        }

        public string Date
        {
            get { return this.date; }
            set { SetValue(ref this.date, value); }

        }

        public List<ProductLocal> Favorites
        {
            get { return this.favorites; }
            set { SetValue(ref this.favorites, value); }
        }
        #endregion

        #region Commands
        public ICommand LogOutCommand
        {
            get { return new RelayCommand(LogOut); }
        }

        public ICommand Refresh
        {
            get { return new RelayCommand(RefreshFavorites); }
        }


        #endregion

        #region Methods

        private async void RefreshFavorites()
        {
            await this.loadDataFromDB();  
        }

        private async Task loadDataFromDB()
        {
            mainViewModel = MainViewModel.GetInstance();
            mainViewModel.ProductL = await this.dataService.GetAllProducts();
            Favorites = mainViewModel.ProductL;
        }

        private async void LogOut()
        {
            Settings.Token = string.Empty;
            Settings.TokenType = string.Empty;
            
            Settings.Name = string.Empty;
            Settings.LastName = string.Empty;
            Settings.Email = string.Empty;
            Settings.Date = string.Empty;

            mainViewModel = MainViewModel.GetInstance();

            mainViewModel.Token = string.Empty;
            mainViewModel.TokenType = string.Empty;

            mainViewModel.ProductL.Clear();
            await this.EmptyDataBase();
           


            Application.Current.MainPage = new LogInPage();
        }

        private async Task EmptyDataBase()
        {
            mainViewModel = MainViewModel.GetInstance();
            await dataService.DeleteAllProducts();
        }


        #endregion

        #region Constructors
        public ProfileViewModel()
        {
            this.name = Settings.Name;
            this.lastName = Settings.LastName;
            this.email = Settings.Email;
            this.date = Settings.Date;
            dataService = new DataService();
            this.RefreshFavorites();
        }
        #endregion

    }
}
