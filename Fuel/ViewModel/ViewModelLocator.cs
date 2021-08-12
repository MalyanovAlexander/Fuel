using CommonServiceLocator;
using Fuel.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;


namespace Fuel.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            SimpleIoc services = SimpleIoc.Default;
            ServiceLocator.SetLocatorProvider(() => services);

            SimpleIoc.Default.Register<MainWindowViewModel>();

            services.Register<TripsDataProvider>();
            services.Register(() => new FuelDB());
        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}