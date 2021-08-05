using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fuel
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public double summerconsumptionrate = 0.1444;
        public double winterconsumptionrate = 2.56;
        public double idleconsumptionrate = 1.02;        

        public AddWindow()
        {
            InitializeComponent();
        }        

        /// <summary>
        /// Сохранить введённые данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
        }

        /// <summary>
        /// Сохраняем данные
        /// </summary>
        private void SaveData()
        {
            int _mileagemorning = int.Parse(MileageMorning.Text);           //Здесь получаем данные из текстбоксов и конвертим в числовые
            double _fuelmorning = double.Parse(FuelMorning.Text);
            int _refueling = int.Parse(Refueling.Text);
            int _mileageperday = int.Parse(MileagePerDay.Text);
            int _idlehours = int.Parse(IdleHours.Text);
            double _idleconsumption = _idlehours * idleconsumptionrate;
            double _dailyconsumption;                                       //Расчёт дневного расхода в зависимости от выбранной нормы расхода (лето\зима)
            string consumptionrate = cmbbx_ConsumptionRate.Text;
            if (consumptionrate == "Летняя норма")
            {
                _dailyconsumption = _mileageperday * summerconsumptionrate;
            }
            else
            {
                _dailyconsumption = _mileageperday * winterconsumptionrate;
            }

            using (FuelDB db = new FuelDB())
            {
                Trip trip = new Trip
                {
                    Date = Date.SelectedDate.Value,                         //Проводим расчёты для расчётных данных и сохраняем в БД
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

        /// <summary>
        /// Сохранить данные и закрыть окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveExitButton_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
            Close();
        }
    }
}
