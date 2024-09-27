using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        //public int RoomNumber { get; set; }
        public string RoomDescription { get; set; }

        public decimal RoomPrice { get; set; }
        [NotMapped]
        public IFormFile RoomImage { get; set; }
        
        public string imagePath { get; set; }
         
        

    }
}
