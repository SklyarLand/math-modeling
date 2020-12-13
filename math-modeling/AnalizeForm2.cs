using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchCore;

namespace math_modeling
{
    public partial class AnalizeForm2 : Form
    {
        private string FileName = "searches_data.txt";
        public AnalizeForm2()
        {
            InitializeComponent();
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            RecordSearcher searcher = new RecordSearcher();
            searcher.RunRecord();
            File.WriteAllLines(FileName, searcher.dataArray.ToArray());
        }

        private void buttonOutput_Click(object sender, EventArgs e)
        {
            Dictionary<string, Dictionary<int, double[]>> data;
            try
            {
                data = getDataFromFile();
            }
            catch
            {
                return;
            }
            UpdateChartOption();
            var dataArray = data.ToArray();
            //каждый добавленный поиск сравнивается со всеми другими
            for (int i = 0; i < dataArray.Length; i++)
            {
                var searchKeyValue = dataArray[i];
                for (int j = i + 1; j < dataArray.Length; j++)
                {
                    var search2KeyValue = dataArray[j];

                    var graf = new System.Windows.Forms.DataVisualization.Charting.Series();
                    graf.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    graf.LegendText = String.Format("{0}/{1}", searchKeyValue.Key, search2KeyValue.Key);

                    var legend = new System.Windows.Forms.DataVisualization.Charting.Legend(graf.Legend);
                    legend.Alignment = StringAlignment.Far;

                    //цикл для каждого числа элементов
                    foreach (var countKeyValue in searchKeyValue.Value) 
                    {
                        var pointCount = countKeyValue.Key;

                        //если второй элемент содержит данные по данному количеству элементов
                        if (search2KeyValue.Value.ContainsKey(pointCount))
                        {
                            var data1 = searchKeyValue.Value[pointCount];
                            var data2 = search2KeyValue.Value[pointCount];
                            //находим k
                            var k = FindGeneralK(pointCount, data1, data2);
                            graf.Points.AddXY(k, pointCount);
                        }

                    }

                    ResultChart.Series.Add(graf);
                    ResultChart.Legends.Add(legend);
                }
            }
        }

        private Dictionary<string, Dictionary<int, double[]>> getDataFromFile()
        {
            var data = new Dictionary<string, Dictionary<int, double[]>>();
            using (StreamReader sr = new StreamReader(@FileName, Encoding.UTF8))
            {

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var strArray = line.Split(',');
                    string name = strArray[0];
                    double preprocessingTime = Double.Parse(strArray[1]);
                    double searchTime = Double.Parse(strArray[2]);
                    int countPoints = Int32.Parse(strArray[3]);
                    var timeArray = new[] { preprocessingTime, searchTime };
                    if (!data.ContainsKey(name))
                    {
                        data.Add(name, new Dictionary<int, double[]>());
                    }
                    data[name].Add(countPoints, timeArray);
                }
            }
            return data;
        }

        private void UpdateChartOption()
        {
            ResultChart.Series.Clear();
            ResultChart.Legends.Clear();
            ResultChart.ChartAreas[0] = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            ResultChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            ResultChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            ResultChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            ResultChart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            ResultChart.ChartAreas[0].CursorY.IsUserEnabled = true;
            ResultChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            ResultChart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            ResultChart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;

            ResultChart.ChartAreas[0].AxisX.Title = "k, кол.";
            ResultChart.ChartAreas[0].AxisY.Title = "n, кол.";
        }

        private int FindGeneralK(int count, double[] data1, double[] data2)
        {
            double[] lessTimeData;
            double[] longerTimeData;
            //проверяем какая сортировка быстрее при k=1
            if (data1[0] + data1[1] < data2[0] + data2[1]) 
            {
                lessTimeData = data1;
                longerTimeData = data2;
            }
            else
            {
                lessTimeData = data2;
                longerTimeData = data1;
            }
            
            int k = 1;
            double lessTimeForK;
            double longerTimeForK;
            int maxK = 1000000;//максимальное K для расчета

            do
            {
                k++;
                lessTimeForK = lessTimeData[0] + lessTimeData[1] * k;
                longerTimeForK = longerTimeData[0] + longerTimeData[1] * k;
            } while (lessTimeForK < longerTimeForK && k < maxK);
            //если k так и не найдено, значит один из алгоритмов всегда быстрее для данного количества элементов
            if (k == maxK)
            {
                return 0;
            }
            else
            {
                return k;
            }
                
        }

    }
}
