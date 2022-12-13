using Microsoft.EntityFrameworkCore;
using MovReminder.Data.Contexts;
using MovReminder.Data.Entities;
using MovReminder.Data.Repositories.Interfaces;

namespace MovReminder.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private MovreminderContext context;
        public MovieRepository(MovreminderContext context)
        {
            this.context = context;
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            return await context.Movies.AsNoTracking().OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
            return await context.Genders.AsNoTracking().OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<bool> CreateMovieAsync(Movie movie, Director director = null)
        {
            if (director != null) {
                await context.Directors.AddAsync(director);
                await context.SaveChangesAsync();

                await context.Movies.AddAsync(movie);
                await context.SaveChangesAsync();
            }
            else
            {
                await context.Movies.AddAsync(movie);
                await context.SaveChangesAsync();
            }
        }
    }
}
