using System.ComponentModel.DataAnnotations;

namespace home.Models
{
    public class Link {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }
        
        [Required]
        public string Type { get; set; }
    }
}