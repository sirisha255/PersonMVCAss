using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PersonMVCAss.Models.VIewModels
{
    public class CreatePersonViewModel
    {
        [Display(Name = "Person")]
        [Required]
        public string? Name { get; set; }
        [Required]

        public string? City { get; set; }
        [StringLength(80, MinimumLength = 1)]
        [Required]
        public int PhoneNumber { get; set; }

        public List<string> CityList
        {
            get
            {
                return new List<string>

                { "Malmo","Hesinborg","Amhult","Lund","vaxjo","gothenborg"};

            }
        }
    }
}
