using System.ComponentModel.DataAnnotations;

namespace SecureItem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Passwors { get; set; }
    }
}
