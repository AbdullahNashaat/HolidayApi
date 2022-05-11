using System.ComponentModel.DataAnnotations;

namespace HolidayApi.Model
{
    public class Holiday
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Country Country { get; set; }

    }
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        [Required]
        public string CalenderRegion { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; }
    }
}
