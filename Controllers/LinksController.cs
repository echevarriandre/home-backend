using System.Collections.Generic;
using AutoMapper;
using home.DTOs;
using home.Repositories;
using home.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace home.Controllers
{
	[Route("links")]
	[ApiController]
	public class LinksController : ControllerBase
	{
		private readonly LinkRepo _repository;
		private readonly IMapper _mapper;

		public LinksController(LinkRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		// GET /links
		[HttpGet, Authorize]
		public ActionResult<IEnumerable<LinkReadDto>> GetAllLinks()
		{
			IEnumerable<Link> linkItems = _repository.GetAllLinks();

			return Ok(_mapper.Map<IEnumerable<LinkReadDto>>(linkItems));
		}

		// GET /links/5
		[HttpGet("{id:int}", Name = "GetLinkById"), Authorize]
		public ActionResult<LinkReadDto> GetLinkById(int id)
		{
			Link link = _repository.GetLinkById(id);
			if (link != null)
				return Ok(_mapper.Map<LinkReadDto>(link));

			return NotFound();
		}

		// POST /links
		[HttpPost, Authorize]
		public ActionResult<LinkReadDto> CreateLink(LinkCreateDto linkCreateDto)
		{
			Link linkModel = _mapper.Map<Link>(linkCreateDto);
			_repository.CreateLink(linkModel);
			_repository.SaveChanges();

			LinkReadDto linkReadDto = _mapper.Map<LinkReadDto>(linkModel);

			return CreatedAtRoute(nameof(GetLinkById), new { Id = linkReadDto.Id }, linkReadDto);
		}

		// PUT /links/{id}
		[HttpPut("{id:int}"), Authorize]
		public ActionResult<LinkReadDto> UpdateLink(int id, LinkUpdateDto linkUpdateDto)
		{
			Link dbLink = _repository.GetLinkById(id);
			if (dbLink == null)
				return NotFound();

			_mapper.Map(linkUpdateDto, dbLink);

			_repository.UpdateLink(dbLink);
			_repository.SaveChanges();

			return Ok(dbLink);
		}

		// DELETE /links/{id}
		[HttpDelete("{id:int}", Name = "DeleteLink"), Authorize]
		public ActionResult<LinkReadDto> DeleteLink(int id)
		{
			Link dbLink = _repository.GetLinkById(id);
			if (dbLink == null)
				return NotFound();

			_repository.DeleteLink(dbLink);
			_repository.SaveChanges();

			return Ok(_mapper.Map<LinkReadDto>(dbLink));
		}
	}
}