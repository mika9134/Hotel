using Hotel.Models;

namespace Hotel.Repository
{
    public interface IRoomServiceURepo
    {

        public RoomServiceU GetProductById(int id);

        public List<RoomServiceU> GetProducts();

        public List<RoomServiceU> DataSource();
        public RoomServiceU AddProduct(RoomServiceU product);
        public RoomServiceU UpdateProduct(RoomServiceU product);
        public RoomServiceU DeleteProduct(int id);
        public RoomServiceU viewservice();
        public RoomServiceU Food();

    }
}
