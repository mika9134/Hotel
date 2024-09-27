using Hotel.Models;
using Microsoft.EntityFrameworkCore;


namespace Hotel.Repository
{
    public class HotelContext: DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
        { 
        }
        public DbSet<Room> Room { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<RoomServiceU> RoomServiceU { get; set; }
        public DbSet<AppUser> AdminLogin { get; set; }
        public DbSet<Room2> rooms2 { get; set; }
        public DbSet<RoomGallery> roomGalleries { get; set; }

    }
}
