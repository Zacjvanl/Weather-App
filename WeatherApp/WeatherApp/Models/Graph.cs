using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services;

namespace WeatherApp.Models
{
    class Graph
    {
        private string Type = "";

        private WeatherDataValuesListModel weatherData = null;
        public Graph(string GraphType)
        {
            Type = GraphType;

        }

        private Exception WeatherDataException()
        {
            if(weatherData == null)
            {
                return WeatherDataException();
            }

            return null;
        }

        public ObservableCollection<ChartDataPoint> Hourly(WeatherDataValuesListModel weatherData)
        {
            ObservableCollection<ChartDataPoint> Data = new ObservableCollection<ChartDataPoint>();
            try
            {
                foreach(WeatherDataValuesModel item in weatherData.weatherDataValuesModel)
                {
                    if(item.Time_Stamp >= DateTime.Now.AddHours(4))
                    {
                        Data.Add(new ChartDataPoint(item.Time_Stamp, Convert.ToDouble(CorrespondingData(item))));
                    }
                }
                return Data;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ObservableCollection<ChartDataPoint> Daily(WeatherDataValuesListModel weatherData)
        {
            ObservableCollection<ChartDataPoint> Data = new ObservableCollection<ChartDataPoint>();
            try
            {
                foreach (WeatherDataValuesModel item in weatherData.weatherDataValuesModel)
                {
                    if (item.Time_Stamp >= DateTime.Now.AddHours(5).AddDays(-1))
                    {
                        Data.Add(new ChartDataPoint(item.Time_Stamp, Convert.ToDouble(CorrespondingData(item))));
                    }
                }
                return Data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ObservableCollection<ChartDataPoint> Weekly(WeatherDataValuesListModel weatherData)
        {
            ObservableCollection<ChartDataPoint> Data = new ObservableCollection<ChartDataPoint>();
            try
            {
                foreach (WeatherDataValuesModel item in weatherData.weatherDataValuesModel)
                {
                    if (item.Time_Stamp >= DateTime.Now.AddHours(5).AddDays(-7))
                    {
                        Data.Add(new ChartDataPoint(item.Time_Stamp, Convert.ToDouble(CorrespondingData(item))));
                    }
                }
                return Data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Object CorrespondingData(WeatherDataValuesModel item)
        {
            switch (Type)
            {
                case "Temperature":
                    return item.T2_Avg;
                case "Dew Point":
                    return item.RH2;
                case "Pressure":
                    return item.P_mb_Avg;
                case "Wind Speed":
                    return item.U2_Avg;
                case "Recent Precipitation":
                    return item.PPN_mm_Tot;
                default:
                    return item.Batt_Volt_Avg;
            }
        }
    }
}
