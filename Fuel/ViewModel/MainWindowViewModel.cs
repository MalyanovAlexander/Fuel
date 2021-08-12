using Fuel.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Заголовок основного окна

        private string _WindowTitle = "Путевка";

        public string WindowTitle
        {
            get => _WindowTitle;
            set => Set(ref _WindowTitle, value);
        }

        #endregion


        private TripsDataProvider _TripsProvider;

        public ObservableCollection<Trip> Trips { get; } = new ObservableCollection<Trip>();

        public MainWindowViewModel(TripsDataProvider TripsProvider)
        {
            _TripsProvider = TripsProvider;

            //RefreshData();
        }


        /// <summary>
        /// Обновить данные в таблице
        /// </summary>
        public void RefreshData()
        {
            ObservableCollection<Trip> trips = Trips;
            Trips.Clear();
            foreach (Trip trip in _TripsProvider.GetTrips())
                trips.Add(trip);

        }
    }
}
