using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using Week05.Entities;
using Week05.MnbServiceReference;

namespace Week05
{
    public partial class Form1 : Form
    {
        BindingList<RateDate> Rates = new BindingList<RateDate>();
        BindingList<string> currencies = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetCurrenciesRequestBody
            {};
            var response = mnbService.GetCurrencies(request);
            var result = response.GetCurrenciesResult;
            Console.WriteLine(result);
            var xml = new XmlDocument();
            xml.LoadXml(result);
            foreach (XmlElement element in xml.DocumentElement)
            {
                foreach (XmlElement item in element)
                {
                    string currency;
                    currency = Convert.ToString(item.InnerText);
                    currencies.Add(currency);
                }
            }
            /*XmlNodeList crr = xml.GetElementsByTagName("Curr");
            foreach (XmlElement element in crr)
            {
                string currency;
                currency = Convert.ToString(element.InnerText);
                currencies.Add(currency);
            }*/
            RefreshData();
            comboBox1.DataSource = currencies;
        }

        private void RefreshData()
        {
            Rates.Clear();
            Feldolgozas();
            Megjelenites();
        }

        private void Megjelenites()
        {
            chartRateData.DataSource = Rates;
            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private void Feldolgozas()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody
            {
                currencyNames = (string)comboBox1.SelectedItem,
                startDate = dateTimePicker1.Value.ToString(),
                endDate = dateTimePicker2.Value.ToString()
            };
            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            dataGridView1.DataSource = Rates;
            var xml = new XmlDocument();
            xml.LoadXml(result);
            foreach (XmlElement element in xml.DocumentElement)
            {
                var peldany = new RateDate();
                Rates.Add(peldany);
                peldany.Date = Convert.ToDateTime(element.GetAttribute("date"));
                var child = (XmlElement)element.ChildNodes[0];
                if (child == null)
                    continue;
                peldany.currency = child.GetAttribute("curr");
                var unit = decimal.Parse(child.GetAttribute("unit"));
                var value = decimal.Parse(child.InnerText);
                if (unit != 0)
                    peldany.Value = value / unit;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
