using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovReminder.Data.Contexts;
using MovReminder.Data.Entities;
using MovReminder.Data.Repositories.Interfaces;
using MovReminder.Models;
using System.Runtime.CompilerServices;

namespace MovReminder.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MovreminderContext context;
        private readonly IMapper mapper;
        public UserRepository(MovreminderContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<User> GetUserAsyncById(int id)
        {
            var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(c => c.IdUser.Equals(id));

            if (user == null)
                throw new NullReferenceException("Usuário não encontrado");

            return user;
        }
        public async Task<User> GetUserAsyncByEmail(string email)
        {
            var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(c => c.Email.Equals(email));

            if (user == null)
                throw new NullReferenceException("Usuário não encontrado");

            return user;
        }

        public async Task<bool> CreateUserAsync(UserModel model)
        {
            await context.Users.AddAsync(mapper.Map<User>(model));
            await context.SaveChangesAsync();
            return true;
        }
    }
}
