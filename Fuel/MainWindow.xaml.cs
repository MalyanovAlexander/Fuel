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
        public ObservableCollection<Trip> Trips { get; } = new ObservableCollection<Trip>();

        public MainWindow()
        {
            InitializeComponent();
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
            //using (FuelDB db = new FuelDB())
            //{
            //    int id = TripsGrid.SelectedIndex;

            //    Trip trip = db.Trips
            //    .Where(o => o.Id == id)
            //    .FirstOrDefault();

            //    db.Trips.Remove(trip);
            //    db.SaveChanges();
            //    //ReloadTripsGrid();              //Сразу обновим данные в TripsGrid
            //}     

            //using (FuelDB db = new FuelDB())
            //{
            //    if (TripsGrid.SelectedItems != null && TripsGrid.SelectedItems.Count > 0)
            //    {
            //        List<Trip> toRemove = TripsGrid.SelectedItems.Cast<Trip>().ToList();
            //        //Delete logic here
            //        //...remove items from EF and save

            //        //Once confirmed remove from items source
            //        ObservableCollection<Trip> items = TripsGrid.ItemsSource as ObservableCollection<Trip>;
            //        if (items != null)
            //        {
            //            foreach (var trip in toRemove)
            //            {
            //                TripsList.Remove(trip);
            //                db.SaveChanges();
            //            }
            //        }
            //    }
            //}            

            var trip = TripsGrid.SelectedItem;
            DeleteData((Trip)trip);
        }

        private void DeleteData(Trip trip)
        {
            FuelDB db = new FuelDB();
            if (db.Entry(trip).State == EntityState.Detached)
            {
                db.Trips.Attach(trip);
            }
            db.Trips.Remove(trip);

            db.SaveChanges();

        }

        private void TripsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {            
            //using (FuelDB db = new FuelDB())
            //{
            //    Trip trip = db.Trips
            //    .Where(o => o.Id == TripsGrid.SelectedIndex)
            //    .FirstOrDefault();

            //    MessageBox.Show(trip.MileageMorning.ToString());
            //}

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
