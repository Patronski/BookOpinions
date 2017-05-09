namespace BookOpinions.Data
{
    using BookOpinions.Models.EntityModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class BookOpinionsContext : IdentityDbContext<ApplicationUser>
    {
        public BookOpinionsContext()
            //: base("data source=.;initial catalog=BookOpinions;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", throwIfV1Schema: false)
            : base("name=BookOpinions", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Book> Books { get; set; }
        public virtual IDbSet<Author> Authors { get; set; }
        public virtual IDbSet<Opinion> Opinions { get; set; }

        public static BookOpinionsContext Create()
        {
            return new BookOpinionsContext();
        }
    }
}