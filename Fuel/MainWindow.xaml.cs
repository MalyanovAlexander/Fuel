using Fuel.Services;
using Fuel.ViewModel;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        /// Удаляем строку в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (FuelDB db = new FuelDB())
            {
                int id = TripsGrid.SelectedIndex;

                Trip trip = db.Trips
                .Where(o => o.Id == id)
                .FirstOrDefault();

                db.Trips.Remove(trip);
                db.SaveChanges();
                //ReloadTripsGrid();              //Сразу обновим данные в TripsGrid
            }
        }

        private void TripsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            using (FuelDB db = new FuelDB())
            {
                Trip trip = db.Trips
                .Where(o => o.Id == TripsGrid.SelectedIndex)
                .FirstOrDefault();

                MessageBox.Show(trip.MileageMorning.ToString());
            }

            //FuelDB db = new FuelDB();

            //Trip trip = db.Trips
            //    .Where(o => o.Id == TripsGrid.SelectedIndex)
            //    .FirstOrDefault();

            //MessageBox.Show(trip.MileageMorning.ToString());

            //AddWindow addWindow = new AddWindow(trip);

            //addWindow.Owner = this;

            //////addWindow.MileageMorning.Text = TripsGrid.Sele;

            //addWindow.Show();
        }
    }
}
