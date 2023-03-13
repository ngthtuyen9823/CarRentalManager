using CarRentalManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using CarRentalManager.modals;
using System.Security.Policy;
using System.Xml.Linq;
using CarRentalManager.enums;

namespace CarRentalManager.ViewModel
{
    class CardViewModels
    {
        readonly ResourceDictionary dictionary = Application.LoadComponent(new Uri("/CarRentalManager;component/Assets/icons.xaml", 
            UriKind.RelativeOrAbsolute)) as ResourceDictionary;
//        ResourceDictionary dictionary = new ResourceDictionary();
        ObservableCollection<Car> _course { get; set; }
        public ObservableCollection<Car> Courses
        {
            get { return _course; }
            set { _course = value; }
        }

        public CardViewModels()
        {

            _course = new ObservableCollection<Car>()
            {
                new Car(1, "VINFAST LUX A 2.0 2021", "VinFast", 2020, "white", 1300, ECarStatus.AVAILABLE, ECarType.CAR, EDrivingType.SELF_DRIVING, 4, "1234323", "/Assets/1.jpg", "/Assets/1.jpg"),

                new Car(2, "VINFAST LUX A 2.0 2021", "VinFast", 2020, "white", 1300, ECarStatus.AVAILABLE, ECarType.CAR, EDrivingType.SELF_DRIVING, 4, "1234323", "/Assets/1.jpg", "/Assets/2.jpg"),

            };
        }
    }
}
