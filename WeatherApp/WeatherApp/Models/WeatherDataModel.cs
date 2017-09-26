namespace WeatherApp.Models
{
    public class WeatherDataModel
    {
        public HeadModel head { get; set; }
        public DataListModel[] data { get; set; }
        public bool more { get; set; }
    }
}