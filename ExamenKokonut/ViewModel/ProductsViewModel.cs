
namespace ExamenKokonut.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using ExamenKokonut.Model;
    using ExamenKokonut.Services;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {

        #region Services 
        private readonly APIService apiService; 
        #endregion

        #region Attributes
        private Products productResponse;
        private ObservableCollection<ProductItemViewModel> products;
        private bool isRefreshing; 
        #endregion

        #region Properties 
        public ObservableCollection<ProductItemViewModel> Products
        {
            get { return this.products; }
            set { SetValue(ref this.products, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        #endregion 


        #region Constructors 
        public ProductsViewModel()
        {
            this.apiService = new APIService();
            this.LoadProducts();
        }
        #endregion


        #region Methods
        private async void LoadProducts()
        {
            this.IsRefreshing = true;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSucces)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   connection.Message,
                   "Accept");
                return;
            }

            var response = await this.apiService.Get<Products>(
                "http://dev.estandares.kokonutstudio.com:8080",
                "/api",
                "/post/all");


            if (!response.IsSucces)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }


            this.productResponse = (Products)response.Result;
            this.Products = new ObservableCollection<ProductItemViewModel>(
            this.ToItemProductViewModel());
            this.IsRefreshing = false;
        }


        private IEnumerable<ProductItemViewModel> ToItemProductViewModel()
        {
              return this.productResponse.DataLog.DataData.Select(l =>
              {
                  return new ProductItemViewModel 
                  {
                      Body = l.Body,
                      Title = l.Title,
                      Slug = l.Slug,
                      //ImageUrl = l.ImageUrl

                  };
              });
        }
        #endregion

        // EL API No devuelve nada, no tiene sentido refrescar la pagina 

        //#region Commands
        //public ICommand RefreshCommand 
        //{
        //    get 
        //    {
        //        return new RelayCommand(LoadProducts);
                
        //    }
        //}
        //#endregion


    }
}
