using MovReminder.Data.Entities;

namespace MovReminder.Data.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetMoviesAsync();
        Task<List<Gender>> GetGendersAsync();
        Task<bool> CreateMovieAsync(Movie movie, Director director = null);
    }
}