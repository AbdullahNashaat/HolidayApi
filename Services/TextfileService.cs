using HolidayApi.Model;

namespace HolidayApi.Services
{
    public class TextfileService
    {
        
        public static List<Country> GetContries()
        {
            string HolidayWord = " Holidays";
            string countyName;
            List<Country> countries = new List<Country>(); 
            string text = System.IO.File.ReadAllText(@"D:\Projects\C#\HolidayApi\Data\google-calendar-list.txt");
            string[] subsLine = text.Split('\n');
            foreach (string subline in subsLine)
            {
                string[] sub = subline.Split(',', '#');
                int len = sub[0].Length - HolidayWord.Length ;

                //s = s.Substring(0, s.Length - n);
                if (sub[0].Contains(HolidayWord))
   
                    countyName = sub[0].Substring(0, len);
             
                else
                    countyName = sub[0];
                //int len =  HolidayWord.Length;
                //string countyName = sub[0].Remove(len);
                Country country = new Country
                {
                    Name = countyName,
                    CalenderRegion = sub[1]
                };
                countries.Add(country);

            }
            return countries;

        }
    }
}
