namespace ExamenKokonut.ViewModel
{
    using System;
    using System.Linq;
    using System.Windows.Input;
    using ExamenKokonut.Model;
    using ExamenKokonut.Services;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;


    public class ProductViewModel : BaseViewModel
    {

        #region DataServices
        private DataService dataService;
        #endregion


        #region atributes 
        private string buttonColor;

        private MainViewModel mainViewModel;

        #endregion

        #region Properties
        public ProductItemViewModel Product
        {
            get;
            set;
        }

    
        public ProductLocal ProductL
        {
            get;
            set;
        }

        public Color ButtonColor { get; set;} 
  

        #endregion

        #region Commands
        public ICommand FabButtonCommand
        {
            get { return new RelayCommand(SaveFavoritesToDB); }
        }

        #endregion

        #region Methods
        private async void SaveFavoritesToDB()
        {


            mainViewModel = MainViewModel.GetInstance();

            this.ProductL.Title = Product.Title;
            this.ProductL.Body = Product.Body;
            this.ProductL.ProductID = Product.IdPost;


            if (mainViewModel.ProductL.Count() > 0)
            {
                bool containsItem = mainViewModel.ProductL.Any(item => item.Title == this.Product.Title);

                if (!containsItem)
                {
                    await this.dataService.DeleteAllProducts();
                    mainViewModel.ProductL.Add(this.ProductL);
                    this.SaveIntoDB();
                }
            }
            else
            {
                mainViewModel.ProductL.Add(ProductL);
                this.SaveIntoDB();

            }


        }

        private async void SaveIntoDB()
        {

            await dataService.Insert(mainViewModel.ProductL);
        }

        #endregion

        #region Constructors 

        public ProductViewModel(ProductItemViewModel product)
        {
            this.Product = product;
            this.dataService = new DataService();
            this.ProductL = new ProductLocal();
            this.ButtonColor = Color.FromHex("#f7a902");
        }

        #endregion

    } // end Class 
}
