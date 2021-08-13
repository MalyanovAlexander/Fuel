using Fuel.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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

        public Trip SelectedTrip{get; set;}

        //private var MWSelectedItem;

        public MainWindowViewModel(TripsDataProvider TripsProvider)
        {
            _TripsProvider = TripsProvider;
            RefreshData();

            RefreshDataCommand = new RelayCommand(OnResreshDataCommandExecute, CanRefreshDataCommandExecute);
            AddWindowCommand = new RelayCommand(OnAddWindowCommandExecute, CanAddWindowCommandExecute);
            DeleteDataCommand = new RelayCommand(OnDeleteDataCommandExecute, CanDeleteDataCommandExecute);

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

        private bool CanRefreshDataCommandExecute() => true;

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

        #region Открыть окно для добавления новой записи в базу

        public ICommand AddWindowCommand { get; }

        private bool CanAddWindowCommandExecute() => true;

        private void OnAddWindowCommandExecute()
        {
            AddWindowOpen();
        }

        /// <summary>
        /// Открыть окно для добавления новой записи в базу
        /// </summary>
        public void AddWindowOpen()
        {
            AddWindow addWindow = new AddWindow();            

            addWindow.Show();
        }

        #endregion

        #region Удалить строку в таблице

        public ICommand DeleteDataCommand { get;}

        private bool CanDeleteDataCommandExecute() => true;

        private void OnDeleteDataCommandExecute()
        {
            DeleteData(SelectedTrip);
            RefreshData();
        }

        /// <summary>
        /// Удаляем строку в таблице
        /// </summary>
        /// <param name="trip"></param>
        private void DeleteData(object trip)
        {
            if (trip != null)
            {
                using (FuelDB db = new FuelDB())
                {
                    if (db.Entry(trip).State == EntityState.Detached)
                    {
                        db.Trips.Attach((Trip)trip);
                    }
                    db.Trips.Remove((Trip)trip);

                    db.SaveChanges();
                };
            }
            else
            {
                MessageBox.Show("Нет данных для удаления!", "Ошибка!", MessageBoxButton.OK,  MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
