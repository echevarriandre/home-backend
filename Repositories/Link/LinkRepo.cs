using System;
using home.Data;
using home.Models;
using System.Linq;
using System.Collections.Generic;

namespace home.Repositories
{
	public class LinkRepo : BaseRepo
	{
		public LinkRepo(HomeContext context) : base(context)
		{
		}

		public IEnumerable<Link> GetAllLinks()
		{
			return _context.Links.ToList();
		}

		public Link GetLinkById(int id)
		{
			return _context.Links.FirstOrDefault(p => p.Id == id);
		}

		public void CreateLink(Link link)
		{
			if (link == null)
				throw new ArgumentNullException(nameof(link));

			_context.Links.Add(link);
		}

		public Link UpdateLink(Link link)
		{
			_context.Links.Update(link);

			return link;
		}

		public Link DeleteLink(Link link)
		{
			if (link == null)
				throw new ArgumentNullException(nameof(link));

			_context.Links.Remove(link);
			return link;
		}
	}
}