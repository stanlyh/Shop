namespace Shop.UIForms.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel instance; //apuntador a la misma clase

        public LoginViewModel Login { get; set; }

        public ProductsViewModel Products { get; set; }

        public MainViewModel()
        {
            instance = this;
        }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
    }
}
