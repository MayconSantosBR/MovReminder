using AutoMapper;
using MovReminder.Models.Mappers.Profiles;

namespace MovReminder.Models.Mappers
{
    public class MapperService
    {
        public MapperService()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });

            configuration.CreateMapper();
        }
    }
}
