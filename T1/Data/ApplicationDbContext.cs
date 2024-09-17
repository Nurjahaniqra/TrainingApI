using Microsoft.EntityFrameworkCore;
using T1.Models.Domain;

namespace T1.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<Book> Books { get; set; }
	}
}
