using AutoMapper;
using home.DTOs;
using home.Models;

namespace home.Profiles
{
	public class UsersProfile : Profile
	{
		public UsersProfile()
		{
			// Source -> Target
			CreateMap<User, UserReadDto>();
		}
	}
}