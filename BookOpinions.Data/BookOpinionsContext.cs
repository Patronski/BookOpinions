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
            //: base("name=BookOpinionsContext")
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BookOpinionsContext Create()
        {
            return new BookOpinionsContext();
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}