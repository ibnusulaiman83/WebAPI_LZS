using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace WebAPI_LZS.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? BookTitle { get; set; }
        public string? Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
