using Hotel.Models;

namespace Hotel.Repository
{
    public interface IServiceRepo
    {
        public Service GetProductById(int id);

        public List<Service> GetProducts();

        public List<Service> DataSource();
        public Service AddProduct(Service product);
        public Service UpdateProduct(Service product);
        public Service DeleteProduct(int id);
        public Service viewservice();
        public Service Food();
    }
}
