 namespace ExamenKokonut.ViewModel
{
    using System.Collections.Generic;
    using ExamenKokonut.Model;


    public class MainViewModel
    {

        #region properties 
        public string Token
        {
            get;
            set;
        }
        public string TokenType
        {
            get;
            set;
        }
        #endregion


        #region ViewModels
        public LogInViewModel LogIn 
        {
            get;
            set; 
        }

       public ProfileViewModel Profile
        {
            get;
            set;
        }

        public ProductsViewModel Products 
        {
            get;
            set;
        }

        public ProductViewModel Product
        {
            get;
            set;  
        }

        public List<ProductLocal> ProductL
        {
            get;
            set;
        }
    #endregion

    #region Constructors
    public MainViewModel()
        {
            instance = this;
            this.LogIn = new LogInViewModel();
            this.ProductL = new List<ProductLocal>();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance; 


        public static MainViewModel GetInstance()
        {
            if(instance == null) 
            {
                return new MainViewModel(); 
            }

            return instance;
        }
        #endregion

    } // end Class
}
