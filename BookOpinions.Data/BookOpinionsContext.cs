namespace BookOpinions.Data
{
    using BookOpinions.Models.EntityModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookOpinionsContext : IdentityDbContext<ApplicationUser>
    {
        public BookOpinionsContext()
            : base("data source=.;initial catalog=BookOpinions;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", throwIfV1Schema: false)
            //: base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Opinion> Opinions { get; set; }

        public static BookOpinionsContext Create()
        {
            return new BookOpinionsContext();
        }
    }
}