using System.Collections.Generic;
using AutoMapper;
using home.DTOs;
using home.Repositories;
using home.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace home.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly UserRepo _repository;
		private readonly IMapper _mapper;

		public UsersController(UserRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		// GET api/users
		[HttpGet, Authorize]
		public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
		{
			IEnumerable<User> userItems = _repository.GetAllUsers();

			return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
		}

		// GET api/users/5
		[HttpGet("{id}", Name = "GetUserById"), Authorize]
		public ActionResult<UserReadDto> GetUserById(int id)
		{
			User user = _repository.GetUserById(id);
			if (user != null)
				return Ok(_mapper.Map<UserReadDto>(user));

			return NotFound();
		}
	}
}