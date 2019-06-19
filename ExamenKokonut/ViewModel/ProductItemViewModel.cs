namespace ExamenKokonut.ViewModel
{
    using ExamenKokonut.Model;
    using ExamenKokonut.View;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ProductItemViewModel : Products
    {
        public string Body { get; internal set; }
        public string Title { get; internal set; }
        public string Slug { get; internal set; }
        public Uri ImageUrl { get; internal set; }
        public int IdPost { get; internal set; }

        public ICommand SelectProductCommand 
        {
            get
            {
                return new RelayCommand(SelectProduct);
            }
        }

        private async void SelectProduct() 
        {
            MainViewModel.GetInstance().Product = new ProductViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new ProductPage());  
        }

        public ProductItemViewModel()
        {

        }
    } // end Class 
}
