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
using System.Security.AccessControl;

namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for StatisticView.xaml
    /// </summary>
    public partial class StatisticView : UserControl
    {
        readonly StatisticsService statisticsService = new StatisticsService();
        public Func<ChartPoint, string> PointLabel { get; set; }
        public ChartValues<double> Values { get; set; }

        public StatisticView()
        {
            InitializeComponent();
            TotalOrder.Text = statisticsService.getTotalOrder().ToString();
            TotalCar.Text = statisticsService.getTotalCar().ToString();
            TotalContract.Text = statisticsService.getTotalContract().ToString();
            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            drawChartByOnrentTimes();
            Values = new ChartValues<double>();
            drawChartByMonth();
            DataContext = this;
        }
        private void drawChartByBrokenTimes()
        {
            Dictionary<string, int> dictBrokenTimes = statisticsService.getDictBrokennTimes();
            drawPieChart(dictBrokenTimes);
        }
        private void drawChartByOnrentTimes()
        {
            Dictionary<string, int> dictOnrentTimes = statisticsService.getDictOnrentTimes();
            drawPieChart(dictOnrentTimes);
        }
        private void drawPieChart(Dictionary<string, int> dict)
        {
            try
            {
                var sortedDict = from entry in dict orderby entry.Value descending select entry;
                Piece1.Title = sortedDict.ElementAt(0).Key;
                Piece1.Values = new ChartValues<double> { sortedDict.ElementAt(0).Value };
                Piece2.Title = sortedDict.ElementAt(1).Key;
                Piece2.Values = new ChartValues<double> { sortedDict.ElementAt(1).Value };
                Piece3.Title = sortedDict.ElementAt(2).Key;
                Piece3.Values = new ChartValues<double> { sortedDict.ElementAt(2).Value };
                Piece4.Title = sortedDict.ElementAt(3).Key;
                Piece4.Values = new ChartValues<double> { sortedDict.ElementAt(3).Value };
            }
            catch{}
        }
        private void drawChartByPreciouse()
        {
            Dictionary<string, int> dictPreciouse = statisticsService.getDictTotalRevenueByPrecious();
            for (int i = 1; i <= 4; i++)
            {
                double x = dictPreciouse[$"{i}"] / (double)1000;
                Values.Add(x);
            }
        }
        private void drawChartByMonth()
        {
            Dictionary<string, int> dictMonth = statisticsService.getDictTotalRevenueByMonth();
            for (int i = 1; i <= 12; i++)
            {
                double x = dictMonth[$"{i}"] / (double)1000;
                Values.Add(x);
            }
        }
        private void drawChartByYear()
        {
           Dictionary<string, int> dictYear = statisticsService.getDictTotalRevenueByYear();
            for (int i = 2019; i <= 2023; i++)
            {
                double x = dictYear[$"{i}"] / (double)1000;
                Values.Add(x);
            }
        }
        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
        private void UpdateOnclick(object sender, RoutedEventArgs e)
        {
            Chart.Update(true);
        }
        private void btnMonth_Click(object sender, RoutedEventArgs e)
        {
            Values.Clear();
            btnMonth.IsChecked = true;
            drawChartByMonth();
        }
        private void btnYear_Click(object sender, RoutedEventArgs e)
        {
            Values.Clear();
            btnYear.IsChecked = true;
            drawChartByYear();
        }
        private void btnPreciouse_Click(object sender, RoutedEventArgs e)
        {
            Values.Clear();
            btnPreciouse.IsChecked = true;
            drawChartByPreciouse();
        }
        private void btnBroken_Click(object sender, RoutedEventArgs e)
        {
            btnBroken.IsChecked = true;
            drawChartByBrokenTimes();
        }
        private void btnOnrent_Click(object sender, RoutedEventArgs e)
        {
            btnOnrent.IsChecked = true;
            drawChartByOnrentTimes();
        }
    }
}
