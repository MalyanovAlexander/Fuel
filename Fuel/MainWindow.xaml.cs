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


/*В связи с изучением ASP.NET Core вынужден приостановить работу над данным проектом.
 * В планах по этому проекту:
 * Сделать защиту от sql-инъекций
 * Сделать окно добавления новой записи, описать логику расчётов (При добавлении записи автоматически обновлять datagrid в главном окне)
 * Редактирование записи
 * В случае отсутствия файлов БД на диске - создать их
 * Разобраться с системой установки программы
 * 
 * А пока что в рамках изучения ASP.NET Core буду пробовать перевести этот проект на веб.
 */

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

        
        
        
        
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addwindow = new AddWindow();
            addwindow.Owner = this;
            addwindow.Show();
        }
    }
}
