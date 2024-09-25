using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public string? ServiceDescription { get; set; }
        public int Servicequantity { get; set; }
        public decimal ServiceunitPrice { get; set; }
        [NotMapped]
        public IFormFile? ServiceImage { get; set; }
        public string? imagePath { get; set; }
    }
}
