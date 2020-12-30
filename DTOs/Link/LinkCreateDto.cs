using System.ComponentModel.DataAnnotations;

namespace home.DTOs
{
	public class LinkCreateDto
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Url { get; set; }
		[Required]
		public string Type { get; set; }
	}
}