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
using VehicleParkingProject.ViewModel;

namespace VehicleParkingProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Floor1_Loaded(object sender, RoutedEventArgs e)
        {
            Floor1.DataContext = new ParkFloorViewModel(1);
        }

        private void Floor2_Loaded(object sender, RoutedEventArgs e)
        {
            Floor2.DataContext = new ParkFloorViewModel(2);
        }

        private void Floor3_Loaded(object sender, RoutedEventArgs e)
        {
            Floor3.DataContext = new ParkFloorViewModel(3);
        }
    }
}
