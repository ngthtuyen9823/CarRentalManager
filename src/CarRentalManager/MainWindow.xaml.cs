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

namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Car> items = new List<Car>();
            items.Add(new Car() {Ma = "CAR01", Hang = "Ford", Loai = "7 seats", Bienso = "MX8342", Giathue = 183223 });
            items.Add(new Car() { Ma = "CAR01", Hang = "Ford", Loai = "7 seats", Bienso = "MX8342", Giathue = 183223 });
            items.Add(new Car() { Ma = "CAR01", Hang = "Ford", Loai = "7 seats", Bienso = "MX8342", Giathue = 183223 });
            items.Add(new Car() { Ma = "CAR01", Hang = "Ford", Loai = "7 seats", Bienso = "MX8342", Giathue = 183223 });
            items.Add(new Car() { Ma = "CAR01", Hang = "Ford", Loai = "7 seats", Bienso = "MX8342", Giathue = 183223 });
            items.Add(new Car() { Ma = "CAR01", Hang = "Ford", Loai = "7 seats", Bienso = "MX8342", Giathue = 183223 });
            lvCarss.ItemsSource= items;
            lvCar.ItemsSource = items;

        }
    }
    public class Car
    {
        public string Ma { get; set; }    
        public string Hang { get; set; }
        public string Loai { get; set; }    
        public string Bienso { get; set; }
        public int Giathue { get; set; }    
        
    }
}
