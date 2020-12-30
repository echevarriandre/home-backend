using AutoMapper;
using home.DTOs;
using home.Models;

namespace home.Profiles
{
	public class LinksProfile : Profile
	{
		public LinksProfile()
		{
			// Source -> Target
			CreateMap<Link, LinkReadDto>();
			CreateMap<LinkCreateDto, Link>();
			CreateMap<LinkUpdateDto, Link>();
		}
	}
}