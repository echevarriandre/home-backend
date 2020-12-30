using home.Data;

namespace home.Repositories
{
	public class BaseRepo
	{
		protected HomeContext _context;
		public BaseRepo(HomeContext context)
		{
			_context = context;
		}

		public bool SaveChanges()
		{
			return (_context.SaveChanges() >= 0);
		}
	}
}