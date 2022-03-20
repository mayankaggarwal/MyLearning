using Microsoft.EntityFrameworkCore;

namespace bookstore.bookstoreDB
{
    public class BookstoreDbContext:DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
            :base(options){}

        public DbSet<Models.Bookstore> Bookstores {get;set;}
    }
}