using MovReminder.Data.Entities;

namespace MovReminder.Data.Repositories.Interfaces
{
    public interface IWatchedRepository
    {
        Task<List<WatchedMovie>> WatchedMoviesAsyncById(int id);
        Task<bool> CreateWatchedMovie(WatchedMovie movie);
    }
}