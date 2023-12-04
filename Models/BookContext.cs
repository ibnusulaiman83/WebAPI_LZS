using Microsoft.EntityFrameworkCore;

namespace WebAPI_LZS.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options):base(options) { }

        public DbSet<Book> Books { get; set; } = null!;

    }
}
