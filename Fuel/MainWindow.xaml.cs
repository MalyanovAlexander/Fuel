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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fuel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FuelDB db;
        public static List<Trip> TripsList;

        public MainWindow()
        {    
            InitializeComponent();

            TripsCount();
            ReloadTrips();
            
        }

        /// <summary>
        /// Считаем количество записей в базе
        /// </summary>
        public static void TripsCount()
        {
            using (var db = new FuelDB())
            {
                var trips_count = db.Trips.Count();
                MessageBox.Show(trips_count.ToString());
            }
        }

        /// <summary>
        /// Обновляем данные на главном окне
        /// </summary>
        private void ReloadTrips()
        {
            using (var db = new FuelDB())
            {
                TripsList = db.Trips.ToList();                
                TripsGrid.ItemsSource = TripsList;
            }            
        }

        /// <summary>
        /// Добавляем новую запись в базу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
