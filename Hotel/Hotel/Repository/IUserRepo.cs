using Hotel.Models;

namespace Hotel.Repository
{
    public interface IUserRepo
    {
        Task<Status> LoginAsync(SignInModel model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(SignUpModel model);
        Task<Status> CreateAdmin(SignUpModel signupmodel);
    }
}
