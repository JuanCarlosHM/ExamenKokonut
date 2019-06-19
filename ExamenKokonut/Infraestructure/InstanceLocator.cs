
namespace ExamenKokonut.Infraestructure
{
    using ExamenKokonut.ViewModel;


    //inicio de la clase 
    public class InstanceLocator
    {

        #region Properties 
        public MainViewModel Main
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public InstanceLocator() 
        {
            this.Main = new MainViewModel();         
        }
        #endregion

    } //End Class 
}
