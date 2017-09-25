using System;

namespace WeatherApp.Models
{
    public class DataListModel
    {
        public int no { get; set; }
        public DateTime time { get; set; }
        public object[] vals { get; set; }
    }
}
