using System.Collections.Generic;
using home.Models;

namespace home.Data
{
	public interface IHomeRepo
	{
		bool SaveChanges();
		IEnumerable<Link> GetAllLinks();
		Link GetLinkById(int id);
		void CreateLink(Link link);
		Link UpdateLink(Link link);
		Link DeleteLink(Link link);
	}
}