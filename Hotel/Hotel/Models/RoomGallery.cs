namespace Hotel.Models
{
    public class RoomGallery
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Room2Id { get; set; }
        public Room2 rooms { get; set; }
    }
}
