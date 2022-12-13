using MovReminder.Data.Entities;
using MovReminder.Data.Repositories.Interfaces;
using MovReminder.Models;
using MovReminder.Services.Interfaces;

namespace MovReminder.Services
{
    public class GeneralService : IGeneralService
    {
        private readonly IUserRepository userRepository;
        private readonly IWatchedRepository watchedRepository;
        private readonly IDirectorRepository directorRepository;
        private readonly IMovieRepository movieRepository;
        public GeneralService(IUserRepository userRepository, IWatchedRepository watched, IDirectorRepository directorRepository, IMovieRepository movieRepository)
        {
            this.userRepository = userRepository;
            this.watchedRepository = watched;
            this.directorRepository = directorRepository;
            this.movieRepository = movieRepository;
        }

        public async Task<bool> CreateUserAsync(string username, string password, string email)
        {
            try
            {
                UserModel model = new() { Email = email, Password = password, Username = username };
                return await userRepository.CreateUserAsync(model);
            }
            catch
            {
                return false;
            }
        }
        public async Task<int> ValidateUserExistsAsync(string email)
        {
            try
            {
                var user = await userRepository.GetUserAsyncByEmail(email);
                return user.IdUser;
            }
            catch
            {
                return 0;
            }
        }
        public async Task<bool> ValidateCredentialsAsync(string email, string password)
        {
            try
            {
                var user = await userRepository.GetUserAsyncByEmail(email);

                if(user.Email.Equals(email) && user.Password.Equals(password))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<WatchedMovie>> GetWatchedMoviesAsyncById(int id)
        {
            try
            {
                return await watchedRepository.WatchedMoviesAsyncById(id);
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<Director>> GetDirectorsAsync()
        {
            try
            {
                return await directorRepository.GetDirectorsAsync();
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<Movie>> GetMoviesAsync()
        {
            try
            {
                return await movieRepository.GetMoviesAsync();
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> CreateWatchedMovieAsync(int idUser, int movieId, DateTime data, string feedback)
        {
            try
            {
                bool feed = false;
                if (!feedback.Equals("null"))
                {
                    if (feedback.Equals("true"))
                        feed = true;
                    else
                        feed = false;

                    WatchedMovie movie = new() { IdMovie = movieId, IdUser = idUser, Date = data.ToUniversalTime(), Liked = feed };
                    return await watchedRepository.CreateWatchedMovie(movie);
                }
                else
                {
                    WatchedMovie movie = new() { IdMovie = movieId, IdUser = idUser, Date = data };
                    return await watchedRepository.CreateWatchedMovie(movie);
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<Gender>> GetGendersAsync()
        {
            try
            {
                return await movieRepository.GetGendersAsync();
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> CreateMovieAsync(string movieName, string directorId, int genderId, DateTime data, int duration)
        {
            try
            {
                var director = await directorRepository.GetDirectorsAsync
            }
            catch
            {
                return false;
            }
        }
    }
}
