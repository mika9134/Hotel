using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Hotel.Models
{
    public class RoomServiceU
    {


        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public int RoomId { get; set; }
       
        //public int RoomNumber { get; set; }
        public string RoomDescription { get; set; }

        public decimal RoomPrice { get; set; }
        [NotMapped]
        public DateTime? checkin{ get; set; }
        public DateTime? checkout { get; set; }
        
        




    }



}
