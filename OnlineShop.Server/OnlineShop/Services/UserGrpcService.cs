using OnlineShop.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    public interface IUserGrpcService
    {
        Task CreateUser(SignupRequest request);
        Task<Guid> Login(LoginRequest request);
    }

    public class UserGrpcService : IUserGrpcService
    {
        private readonly User.Grpc.User.UserClient _userClient;
        public UserGrpcService(User.Grpc.User.UserClient userClient)
        {
            _userClient = userClient;
        }

        public async Task CreateUser(SignupRequest request)
        {
            var userModel = new User.Grpc.UserModel()
            {
                Name = request.Name,
                Email = request.Email,
                LoggedOn = false
            };

            await _userClient.CreateUserAsync(new User.Grpc.CreateUserModel() { User = userModel, Password = request.Password });
        }

        public async Task<Guid> Login(LoginRequest request)
        {
            await _userClient.LoginAsync(new User.Grpc.LoginModel() { Email = request.Email, Password = request.Password });

            //successful login, get user by email
            var user = await _userClient.GetUserByEmailAsync(new User.Grpc.UserEmailModel() { Email = request.Email });

            if (user == null)
            {
                throw new ArgumentException($"Unable to find user with email: {request.Email}");
            }

            return Guid.Parse(user.Id);
        }
    }
}
