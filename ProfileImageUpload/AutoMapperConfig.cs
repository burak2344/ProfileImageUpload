using AutoMapper;
using ProfileImageUpload.Entities;
using ProfileImageUpload.Models;

namespace ProfileImageUpload
{
    public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<User, UserModel>().ReverseMap();
			CreateMap<User, CreateUserModel>().ReverseMap();
			CreateMap<User, EditUserModel>().ReverseMap();
		}
	}
}
