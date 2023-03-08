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

namespace CarRentalManager.ViewModels
{
    class CardViewModels
    {
        readonly ResourceDictionary dictionary = Application.LoadComponent(new Uri("/CarRentalManager;component/Assets/icons.xaml", 
            UriKind.RelativeOrAbsolute)) as ResourceDictionary;
//        ResourceDictionary dictionary = new ResourceDictionary();
        ObservableCollection<CardModel> _course { get; set; }
        public ObservableCollection<CardModel> Courses
        {
            get { return _course; }
            set { _course = value; }
        }
        public CardViewModels()
        {
            _course = new ObservableCollection<CardModel>()
            {
                new CardModel()
                {
                    CarName = "VINFAST LUX A 2.0 2021",
                    Seats = "Tự lái",
                    Money = "1300K/ngày",
                    ImagePath = "/Assets/1.jpg",
                    TutorImagePath = "/assets/p3.jpg"
                },
                new CardModel()
                {
                    CarName = "MAZDA CX5 2020",
                    Seats = "Tự lái",
                    Money = "1050K/ngày",
                    ImagePath = "/assets/2.jpg",
                    TutorImagePath = "/assets/p2.jpg"
                },
                new CardModel()
                {
                    CarName = "TOYOTA RUSH 2019",
                    Seats = "Tự lái", 
                    Money = "900K/ngày",
                    ImagePath = "/assets/3.jpg",
                    TutorImagePath = "/assets/p3.jpg"
                },
                new CardModel()
                {
                    CarName = "MITSUBISHI ATTRAGE 2020", 
                    Seats = "Tự lái", 
                    Money = "700K/ngày",
                    ImagePath = "/assets/4.jpg",
                    TutorImagePath = "/assets/p4.jpg"
                },
                new CardModel()
                {
                    CarName = "TOYOTA INNOVA G 2016", 
                    Seats = "Tự lái", 
                    Money = "920K/ngày",
                    ImagePath = "/assets/5.jpg",
                    TutorImagePath = "/assets/p4.jpg"
                },
                new CardModel()
                {
                    CarName = "TOYOTA RUSH 2020",
                    Seats = "Có tài xế",
                    Money = "720K/8 tiếng",
                    ImagePath = "/assets/6.jpg",
                    TutorImagePath = "/assets/p5.jpg"
                },
                new CardModel()
                {
                    CarName = "MITSUBISHI XPANDER 2019", 
                    Seats = "Có tài xế", 
                    Money = "450K/6 tiếng",
                    ImagePath = "/assets/7.jpg",
                    TutorImagePath = "/assets/p5.jpg"
                },
                new CardModel()
                {
                    CarName = "MITSUBISHI ATTRAGE 2020",
                    Seats = "Tự lái",
                    Money = "650K/ngày",
                    ImagePath = "/assets/8.jpg",
                    TutorImagePath = "/assets/p4.jpg"
                },
                new CardModel()
                {
                    CarName = "MAZDA CX5 2020",
                    Seats = "5 chỗ",
                    Money = "1050K/ngày",
                    ImagePath = "/assets/3.jpg",
                    TutorImagePath = "/assets/p3.jpg"
                },
                new CardModel()
                {
                    CarName = "MAZDA CX5 2020",
                    Seats = "Tự lái",
                    Money = "1050K/ngày",
                    ImagePath = "/assets/2.jpg",
                    TutorImagePath = "/assets/p2.jpg"
                },
                new CardModel()
                {
                    CarName = "MITSUBISHI XPANDER 2019",
                    Seats = "Có tài xế",
                    Money = "450K/6 tiếng",
                    ImagePath = "/assets/7.jpg",
                    TutorImagePath = "/assets/p3.jpg"
                },
                new CardModel()
                {
                    CarName = "MITSUBISHI ATTRAGE 2020",
                    Seats = "Tự lái",
                    Money = "650K/ngày",
                    ImagePath = "/assets/6.jpg",
                    TutorImagePath = "/assets/p3.jpg"
                },
                new CardModel()
                {
                    CarName = "MITSUBISHI ATTRAGE 2020",
                    Seats = "Tự lái",
                    Money = "700K/ngày",
                    ImagePath = "/assets/4.jpg",
                    TutorImagePath = "/assets/p4.jpg"
                },
                new CardModel()
                {
                    CarName = "MITSUBISHI ATTRAGE 2020",
                    Seats = "Tự lái",
                    Money = "650K/ngày",
                    ImagePath = "/assets/8.jpg",
                    TutorImagePath = "/assets/p4.jpg"
                },
                new CardModel()
                {
                     CarName = "TOYOTA RUSH 2020",
                    Seats = "Có tài xế",
                    Money = "720K/8 tiếng",
                    ImagePath = "/assets/6.jpg",
                    TutorImagePath = "/assets/p5.jpg"
                },
                new CardModel()
                {
                    CarName = "MITSUBISHI ATTRAGE 2020", 
                    Seats = "Tự lái", Money = "650K/ngày", 
                    ImagePath = "/assets/8.jpg",
                    TutorImagePath = "/assets/p5.jpg"
                },
                new CardModel()
                {
                    CarName = "MITSUBISHI ATTRAGE 2020",
                    Seats = "Tự lái", Money = "650K/ngày",
                    ImagePath = "/assets/8.jpg",
                    TutorImagePath = "/assets/p4.jpg"
                },
                new CardModel()
                {
                    CarName = "VINFAST LUX A 2.0 2021",
                    Seats = "Tự lái",
                    Money = "1300K/ngày",
                    ImagePath = "/Assets/1.jpg",
                    TutorImagePath = "/assets/p5.jpg"
                },
                new CardModel()
                {
                    CarName = "MAZDA CX5 2020",
                    Seats = "Tự lái",
                    Money = "1050K/ngày",
                    ImagePath = "/assets/3.jpg",
                    TutorImagePath = "/assets/p5.jpg"
                },
                new CardModel()
                {
                    CarName = "TOYOTA INNOVA G 2016",
                    Seats = "Tự lái",
                    Money = "920K/ngày",
                    ImagePath = "/assets/5.jpg",
                    TutorImagePath = "/assets/p2.jpg"
                },
                new CardModel()
                {
                    CarName = "MITSUBISHI ATTRAGE 2020",
                    Seats = "Tự lái",
                    Money = "700K/ngày",
                    ImagePath = "/assets/4.jpg",
                    TutorImagePath = "/assets/p3.jpg"
                },
                new CardModel()
                {
                    CarName = "VINFAST LUX A 2.0 2021",
                    Seats = "Tự lái",
                    Money = "1300K/ngày",
                    ImagePath = "/Assets/1.jpg",
                    TutorImagePath = "/assets/p4.jpg"
                },
                new CardModel()
                {
                    CarName = "MAZDA CX5 2020",
                    Seats = "Tự lái",
                    Money = "1050K/ngày",
                    ImagePath = "/assets/2.jpg",
                    TutorImagePath = "/assets/p5.jpg"
                }
            };
        }
    }
}
