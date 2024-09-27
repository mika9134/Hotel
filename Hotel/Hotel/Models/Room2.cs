
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Room2
    {
        public int Room2Id { get; set; }
        public string? RoomDescription { get; set; }
        public decimal RoomPrice { get; set;}
        [NotMapped]
        public IFormFile RoomImage { get; set; }
        public string? imagePath { get; set; }
        [NotMapped]
        public IFormFileCollection RoomGallerys { get; set; }

        //To make 1:n relationship
        public List<RoomGallery> roomGalleries { get; set; }

    }
}
