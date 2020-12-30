using System.ComponentModel.DataAnnotations;

namespace home.DTOs.Link
{
	public class LinkUpdateDto
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Url { get; set; }
		[Required]
		public string Type { get; set; }
	}
}