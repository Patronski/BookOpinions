namespace BookOpinions.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Opinion
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        [Range(1,10)]
        public int Rating { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
