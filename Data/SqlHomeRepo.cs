using System;
using System.Collections.Generic;
using System.Linq;
using home.Models;

namespace home.Data
{
	public class SqlHomeRepo : IHomeRepo
	{
		private readonly HomeContext _context;

		public SqlHomeRepo(HomeContext context)
		{
			_context = context;
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

		public bool SaveChanges()
		{
			return (_context.SaveChanges() >= 0);
		}
	}
}