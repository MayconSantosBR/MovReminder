using MovReminder.Data.Entities;
using MovReminder.Models;

namespace MovReminder.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsyncById(int id);
        Task<User> GetUserAsyncByEmail(string email);
        Task<bool> CreateUserAsync(UserModel model);
    }
}