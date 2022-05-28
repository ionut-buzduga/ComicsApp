using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComicsApp.Models
{
    public class ComicsContext : IdentityDbContext<IdentityUser>

    {

        public ComicsContext(DbContextOptions<ComicsContext> options)

        : base(options)

        { }

      

        public DbSet<Comic>? Comics { get; set; }

        public DbSet<Author>? Authors { get; set; }

        public DbSet<Publisher>? Publishers   { get; set; }

        public DbSet<Comment>? Comments { get; set; }

        public DbSet<RatingComment>? RatingComments { get; set; }

        public DbSet<RatingComic>? RatingComics { get; set; }

       
    }

}
