using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public static List<Trip> TripsList;

        public MainWindow()
        {
            InitializeComponent();

            FuelDB db = new FuelDB();
            db.Trips.Load();
            TripsGrid.ItemsSource = db.Trips.Local.ToBindingList();

            TripsCount();
            ReloadTrips();
        }

        /// <summary>
        /// Считаем количество записей в базе
        /// </summary>
        public static void TripsCount()
        {
            using (FuelDB db = new FuelDB())
            {
                int trips_count = db.Trips.Count();
                MessageBox.Show(trips_count.ToString());
            }
        }

        /// <summary>
        /// Обновляем данные на главном окне
        /// </summary>
        private void ReloadTrips()
        {
            using (FuelDB db = new FuelDB())
            {
                TripsList = db.Trips.ToList();
                TripsGrid.ItemsSource = TripsList;
            }
        }

        /// <summary>
        /// Окно для добавления новой записи в базу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Owner = this;

            addWindow.Show();
        }

        /// <summary>
        /// Обновить данные в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadTrips();
        }
    }
}
