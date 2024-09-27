using Hotel.Models;

namespace Hotel.Repository
{
    public interface IRoomRepo
    {
       

        public List<Room> GetRoom();
        public Room GetRoomById(int id);

        public Room2 GetRoomById2(int id);

        public List<Room> GetRooms();

        public List<Room2> GetRoom2();

        public Room AddRoom(Room Room);
        public Room UpdateRoomService(Room URoom);
        public Room DeleteRoomService(int id);


        public Room2 AddRoom2(Room2 room);
        public List<RoomGallery> roomGalleries(int rid);
    }
}
