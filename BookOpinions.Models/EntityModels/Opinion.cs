namespace BookOpinions.Models.EntityModels
{
    using System;

    public class Opinion
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Book Book { get; set; }
    }
}
