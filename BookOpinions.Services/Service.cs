namespace BookOpinions.Services
{
    using BookOpinions.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Service
    {
        private BookOpinionsContext context;

        public Service()
        {
            this.context = new BookOpinionsContext();
        }

        protected BookOpinionsContext Context => this.context;
    }
}
