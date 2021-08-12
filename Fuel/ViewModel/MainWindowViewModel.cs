using Fuel.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fuel.ViewModel
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private TripsDataProvider _TripsProvider;

        public ObservableCollection<Trip> Trips { get; } = new ObservableCollection<Trip>();

        public MainWindowViewModel(TripsDataProvider TripsProvider)
        {
            _TripsProvider = TripsProvider;
            RefreshData();

            RefreshDataCommand = new RelayCommand(OnResreshDataCommandExecute, CanRefreshdataCommandExecute);
        }

        #region Заголовок основного окна

        private string _WindowTitle = "Путевка";

        public string WindowTitle
        {
            get => _WindowTitle;
            set => Set(ref _WindowTitle, value);
        }

        #endregion

        #region Обновить данные в таблице

        public ICommand RefreshDataCommand { get; }

        private bool CanRefreshdataCommandExecute() => true;

        private void OnResreshDataCommandExecute()
        {
            RefreshData();
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

        #endregion
    }
}
