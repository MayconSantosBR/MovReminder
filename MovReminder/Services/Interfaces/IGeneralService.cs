using MovReminder.Data.Entities;

namespace MovReminder.Services.Interfaces
{
    public interface IGeneralService
    {
        Task<bool> CreateUserAsync(string username, string password, string email);
        Task<int> ValidateUserExistsAsync(string email);
        Task<bool> ValidateCredentialsAsync(string email, string password);
        Task<List<WatchedMovie>> GetWatchedMoviesAsyncById(int id);
        Task<List<Director>> GetDirectorsAsync();
        Task<List<Movie>> GetMoviesAsync();
        Task<bool> CreateWatchedMovieAsync(int idUser, int movieId, DateTime data, string feedback);
        Task<List<Gender>> GetGendersAsync();
        Task<bool> CreateMovieAsync(string movieName, string directorId, int genderId, DateTime data, int duration);
    }
}