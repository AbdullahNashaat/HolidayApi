namespace HolidayApi.Model
{
    public class GoogleCalenderResponseModel
    {
        
             public List<Item> items { get; set; }

    }
    public class Item
    {
        public string id { get; set; }
        public String? summary { get; set; }
        public StartDate start { get; set; }
        public EndDate end { get; set; }
    }
    public class StartDate
    {
        public DateTime date { get; set; }
    }
    public class EndDate
    {
        public DateTime date { get; set; }
    }
}
