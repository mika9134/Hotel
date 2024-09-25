using Hotel.Models;
namespace Hotel.Repository
{
    public class RoomRepo : IRoomRepo
        {
            private readonly HotelContext _context;
            public RoomRepo(HotelContext context)
            {
                _context = context;
            }

           

        

            public List<Room> GetRoom()
            {
                return _context.Room.ToList<Room>();
            }




        public Room AddRoom(Room Room)
        {
            _context.Room.Add(Room);
            _context.SaveChanges();
            return Room;

        }


        public Room2 AddRoom2(Room2 room)
            {
            _context.rooms2.Add(room);
            _context.SaveChanges();
            return room;
            }

        public List<Room> DataSource()
        {
            return _context.Room.ToList();
        }


        public Room DeleteRoomService(int id)
            {
            Room? Room = _context.Room.Find(id);
            if (Room != null)
            {
                _ = _context.Room.Remove(Room);
                _context.SaveChanges();
            }

            return Room;
            }




        public Room GetRoomById(int id)
            {
                return _context.Room.Find(id);
            }


        public Room2 GetRoomById2(int id)
        {
            return _context.rooms2.Where(x => x.Room2Id == id).FirstOrDefault();
        }


        public List<Room> GetRooms()
        {
            return _context.Room.ToList();
        }

        public List<Room2> GetRoom2()
        {
            return _context.rooms2.ToList<Room2>();
        }



        public List<RoomGallery> roomGalleries(int rid)
        {
            return _context.roomGalleries.Where(x => x.Room2Id == rid).ToList();
        }

        public Room UpdateRoomService(Room URoom)
            {
                var modifiedGuest = _context.Room.Attach(URoom);
                modifiedGuest.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return URoom;
            }
        }
    }

