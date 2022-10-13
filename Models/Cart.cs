using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Cart
    {
        
        
        [Key]
       
        public int CartId { get; set; }
     
        public int Movie_fk{ get; set; }
        public int User_fk { get; set; }

        public int Quantity { get; set; }
        

    }
}
