using AutoMapper;
using MovReminder.Data.Entities;

namespace MovReminder.Models.Mappers.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<User, User>()
                .ForMember(src => src.IdUser, c => c.Ignore());
        }
    }
}
