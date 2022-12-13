using Microsoft.EntityFrameworkCore;
using MovReminder.Data.Contexts;
using MovReminder.Data.Entities;
using MovReminder.Data.Repositories.Interfaces;

namespace MovReminder.Data.Repositories
{
    public class WatchedRepository : IWatchedRepository
    {
        private readonly MovreminderContext context;
        public WatchedRepository(MovreminderContext context)
        {
            this.context = context;
        }

        public async Task<List<WatchedMovie>> WatchedMoviesAsyncById(int id)
        {
            return await context.WatchedMovies.AsNoTracking().Include(c => c.IdMovieNavigation).Where(c => c.IdUser.Equals(id)).ToListAsync();
        }

        public async Task<bool> CreateWatchedMovie(WatchedMovie movie)
        {
            await context.WatchedMovies.AddAsync(movie);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
