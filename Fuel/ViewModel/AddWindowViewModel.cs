using Fuel.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fuel.ViewModel
{
    public class AddWindowViewModel : ViewModelBase
    {
        private TripsDataProvider _TripsProvider;
        public string mileagemorning { get; set; }
        public string fuelmorning { get; set; }
        public string refueling { get; set; }
        public string mileageperday { get; set; }
        public string idlehours { get; set; }
        public string consumptionrate { get; set; }
        private double idleconsumptionrate = 1.02;
        private double summerconsumptionrate = 0.1444;
        private double winterconsumptionrate = 2.56;
        public DateTime date { get { return _date; } set { Set(ref _date, value); } }
        public DateTime _date = DateTime.Now;

        public Trip NewTrip { get; set; }

        public ObservableCollection<Trip> Trips { get; } = new ObservableCollection<Trip>();

        public AddWindowViewModel(TripsDataProvider TripsProvider)
        {
            _TripsProvider = TripsProvider;
            SaveDataCommand = new RelayCommand(OnSaveDataCommandExecute, CanSaveDataCommandExecute);
        }

        #region Создать новую запись в БД                           

        public ICommand SaveDataCommand { get; }

        private bool CanSaveDataCommandExecute() => true;

        private void OnSaveDataCommandExecute()
        {
            SaveData();
        }

        private void SaveData()
        {
            using (FuelDB db = new FuelDB())
            {
                int _mileagemorning = int.Parse(mileagemorning);           //Здесь получаем данные из текстбоксов и конвертим в числовые
                double _fuelmorning = double.Parse(fuelmorning);
                int _refueling = int.Parse(refueling);
                int _mileageperday = int.Parse(mileageperday);
                int _idlehours = int.Parse(idlehours);
                double _idleconsumption = _idlehours * idleconsumptionrate;
                double _dailyconsumption;                                       //Расчёт дневного расхода в зависимости от выбранной нормы расхода (лето\зима)
                DateTime date = _date;
                if (consumptionrate == "Летняя норма")
                {
                    _dailyconsumption = _mileageperday * summerconsumptionrate;
                }
                else
                {
                    _dailyconsumption = _mileageperday * winterconsumptionrate;
                }

                Trip trip = new Trip
                {
                    Date = date,                         //Проводим расчёты для расчётных данных и сохраняем в БД
                    MileageMorning = _mileagemorning,
                    FuelMorning = _fuelmorning,
                    Refueling = _refueling,
                    MileagePerDay = _mileageperday,
                    MileageEvening = _mileagemorning + _mileageperday,
                    FuelEvening = _fuelmorning + _refueling - _dailyconsumption - _idleconsumption,
                    DailyConsumption = _dailyconsumption,
                    IdleHours = _idlehours,
                    IdleConsumption = _idleconsumption,
                    TotalConsumption = _dailyconsumption + _idleconsumption
                };
                db.Trips.Add(trip);
                db.SaveChanges();
                MainWindow.TripsCount();
            }
        }

        #endregion

    }
}