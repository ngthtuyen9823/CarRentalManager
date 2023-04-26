using LiveCharts.Wpf;
using LiveCharts;
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
using LiveCharts.Wpf.Charts.Base;
using CarRentalManager.services;

namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for StatisticView.xaml
    /// </summary>
    public partial class StatisticView : UserControl
    {
        readonly StatisticsService statisticsService = new StatisticsService();
        public StatisticView()
        {
            InitializeComponent();
            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            Values = new ChartValues<double>();

            //Dictionary<string, int> dictYear = statisticsService.getDictTotalRevenueByYear();
            //for (int i = 2019; i <= 2023; i++)
            //{
            //    double x = dictYear[$"{i}"] / (double)1000;
            //    Values.Add(x);
            //}


            Dictionary<string, int> dictMonth = statisticsService.getDictTotalRevenueByMonth();
            for (int i = 1; i <= 12; i++)
            {
                double x = dictMonth[$"{i}"] / (double)10;
                Values.Add(x);
            }

            //Dictionary<string, int> dictPreciouse = statisticsService.getDictTotalRevenueByPrecious();
            //for (int i = 1; i <= 4; i++)
            //{
            //    double x = dictPreciouse[$"{i}"];
            //    Values.Add(x);
            //}
            DataContext = this;
        }
        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
        public ChartValues<double> Values { get; set; }

        private void UpdateOnclick(object sender, RoutedEventArgs e)
        {
            Chart.Update(true);
        }
        private void showData(object sender, RoutedEventArgs e)
        {
            // Vo ham nay coi cach lay list ra
            Dictionary<string, int> dictOnrentTimes = statisticsService.getDictOnrentTimes();
            Dictionary<string, int> dictBrokenTimes = statisticsService.getDictBrokennTimes();

            foreach (var dict in dictBrokenTimes)
            {
                MessageBox.Show($"Key: {dict.Key}, Value: {dict.Value}");
            }
            /*
            foreach (var dict in dictOnrentTimes)
            {
                object carId;
                bool hasValueId = dict.TryGetValue("carId", out carId);
                object brokenTimes;
                bool hasValueOnerent = dict.TryGetValue("brokenTimes", out brokenTimes);
                MessageBox.Show(brokenTimes.ToString());
            }*/
            //Piece1.Title = dictOnrentTimes
            //Piece1.Values = new ChartValues<double> { 10 };
            
            //foreach (var dict in dictOnrentTimes)
            //{
            //    object carId;
            //    bool hasValueId = dict.TryGetValue("carId", out carId);
            //    object brokenTimes;
            //    bool hasValueOnerent = dict.TryGetValue("brokenTimes", out brokenTimes);
            //    MessageBox.Show(brokenTimes.ToString());
            //}

            Dictionary<string, int> dictYear =  statisticsService.getDictTotalRevenueByYear();
            Dictionary<string, int> dictMonth =  statisticsService.getDictTotalRevenueByMonth();
            Dictionary<string, int> dictPreciouse =  statisticsService.getDictTotalRevenueByPrecious();
            
            //YEAR

            for (int i = 2019; i <= 2023; i++)
            {
                //MessageBox.Show(dictYear[$"{i}"].ToString());
                Values.Add(dictYear[$"{i}"]);
            }

            //MONTH
            /*for (int i = 1; i <= 12; i++)
            {
                MessageBox.Show(dictMonth[$"{i}"].ToString());
            }*/

            //PRECIOUSE
            /*for (int i = 1; i <= 4; i++)
            {
                MessageBox.Show(dictPreciouse[$"{i}"].ToString());
            }*/
        }
    
    
    
    }
}
