using MovReminder.Data.Entities;

namespace MovReminder.Data.Repositories.Interfaces
{
    public interface IDirectorRepository
    {
        Task<List<Director>> GetDirectorsAsync();
    }
}