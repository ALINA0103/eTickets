using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [ForeignKey("StateId")]
        public int StateId { get; set; }
        public string CityName { get; set; }
        public virtual State State { get; set; }
    }
}
