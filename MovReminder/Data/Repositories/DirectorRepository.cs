using Microsoft.EntityFrameworkCore;
using MovReminder.Data.Contexts;
using MovReminder.Data.Entities;
using MovReminder.Data.Repositories.Interfaces;

namespace MovReminder.Data.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private MovreminderContext context;
        public DirectorRepository(MovreminderContext context)
        {
            this.context = context;
        }

        public async Task<List<Director>> GetDirectorsAsync()
        {
            return await context.Directors.AsNoTracking().OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Director> GetDirectorAsyncByName(string name)
        {
            //return await context.Directors.AsNoTracking().Where(c => c.Name.ToLower().Equals(name));
        }
    }
}
