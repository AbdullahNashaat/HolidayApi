using System.ComponentModel.DataAnnotations;

namespace HolidayApi.Model
{
    public class Holiday
    {
        [Key]
        public int Id { get; set; }

        public string GlobalId { get; set; }

        public string Name { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

    }
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        [Required]
        public string CalenderRegion { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; }
    }
}
