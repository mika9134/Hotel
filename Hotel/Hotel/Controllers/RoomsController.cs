
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;
using Hotel.Repository;


namespace Hotel.Controllers
{
    public class RoomsController : Controller 
    { 
      private readonly IRoomRepo iroomrepo;
    private readonly IWebHostEnvironment webHostEnvironment;



        private readonly HotelContext _context;

       
        public RoomsController(HotelContext context, IRoomRepo iroomrepo, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.iroomrepo = iroomrepo;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
              return _context.Room != null ? 
                          View(await _context.Room.ToListAsync()) :
                          Problem("Entity set 'HotelContext.Room'  is null.");
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        public IActionResult Adlogin()
        {

            SignUpModel model = new SignUpModel
            {
                Username = "admin",
                Email = "admin@gmail.com",
                FirstName = "John",
                LastName = "Doe",
                Password = "Admin@12345#"
            };
            if (User.IsInRole("admin"))
            {
                model.Role = "admin";
                return RedirectToAction("Create");
            }


            else
            {
                model.Role = "user";
            }

            return View();

           
        }





        public ViewResult GetRoomById(int id)
        {

            ViewBag.title = "Room detail information";
            Room r = iroomrepo.GetRoomById(id);
            return View(r);

        }
        public ViewResult GetAllRooms()
        {

            ViewBag.title = "All Rooms";
            List<Room> plist = iroomrepo.GetRooms();
            return View(plist);

        }


        // GET: Rooms/Create




        public IActionResult Create()
        {
            return View();
        }

      

        [HttpPost]
        public IActionResult Create(Room room)
        {

            //if (ModelState.IsValid) //checking the validity of the form data
            {
                if (room.RoomImage != null)
                {
                    string imgPath = "Room/Image/" + Guid.NewGuid().ToString() + "_" + room.RoomImage.FileName;
                    string serverPath = Path.Combine(webHostEnvironment.WebRootPath, imgPath);
                    room.RoomImage.CopyTo(new FileStream(serverPath, FileMode.Create));
                    room.imagePath = imgPath;

                }

                Room r = iroomrepo.AddRoom(room);
                return RedirectToAction("getAllRooms");
            }

        }


        [HttpGet]
        public ViewResult Create1()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create1(Room2 room)
        {
            if (room.RoomImage != null)
            {
                room.imagePath = UploadImage(room.RoomImage);
            }
            if (room.RoomGallerys != null)
            {
                room.roomGalleries = new List<RoomGallery>();
                foreach (var file in room.RoomGallerys)
                {
                    RoomGallery rg = new RoomGallery()
                    {
                        Name = file.Name,
                        Url = UploadImage(file)
                    };
                    room.roomGalleries.Add(rg);
                }
            }
           Room2 r = iroomrepo.AddRoom2(room);
            return RedirectToAction("getAllRooms2");
        }

        private string UploadImage(IFormFile file)
        {
            string imgPath = "Room/Image/" + Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverPath = Path.Combine(webHostEnvironment.WebRootPath, imgPath);
            file.CopyTo(new FileStream(serverPath, FileMode.Create));
            return "/" + imgPath;
        }


        public ViewResult getAllRoom2()
        {

            ViewBag.title = "Room Detail";
            List<Room2> plist = iroomrepo.GetRoom2();
            
            return View(plist);
        }


        public ViewResult GetRoomById2(int id)
        {

            ViewBag.title =" Room Detail";
           Room2 r = iroomrepo.GetRoomById2(id);
            r.roomGalleries = iroomrepo.roomGalleries(id);
          
            return View(r);
        }






        public IActionResult List()
        {
            ViewBag.title = "All Room List Page"; ;
            List<Room> plist = iroomrepo.GetRoom();
            return View(plist);
        }


        public IActionResult List2()
        {
            ViewBag.title = "All Room List Page"; ;
            List<Room2> plist = iroomrepo.GetRoom2();
            return View(plist);
        }










        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create1([Bind("RoomId,RoomDescription,RoomPrice,imagePath")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Room.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }





        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,RoomDescription,RoomPrice,imagePath")] Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Room == null)
            {
                return Problem("Entity set 'HotelContext.Room'  is null.");
            }
            var room = await _context.Room.FindAsync(id);
            if (room != null)
            {
                _context.Room.Remove(room);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
          return (_context.Room?.Any(e => e.RoomId == id)).GetValueOrDefault();
        }
    }
}
