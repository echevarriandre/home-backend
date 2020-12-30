using System.ComponentModel.DataAnnotations;

namespace home.DTOs
{
	public class AuthDto
	{
		public string Username { get; set; }
		public string Token { get; set; }
	}
}