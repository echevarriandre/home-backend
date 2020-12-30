using System;
using home.Data;
using home.Models;
using System.Linq;
using System.Collections.Generic;

namespace home.Repositories
{
	public class UserRepo : BaseRepo
	{
		public UserRepo(HomeContext context) : base(context)
		{
		}

		public IEnumerable<User> GetAllUsers()
		{
			return _context.Users.ToList();
		}

		public User GetUserById(int id)
		{
			return _context.Users.FirstOrDefault(p => p.Id == id);
		}

		public User GetUserByUsername(string username)
		{
			return _context.Users.FirstOrDefault(p => p.Username == username);
		}
	}
}