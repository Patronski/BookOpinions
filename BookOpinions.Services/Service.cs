namespace BookOpinions.Services
{
    using BookOpinions.Data;

    public abstract class Service
    {
        private BookOpinionsContext context;
        protected BookOpinionsContext Context => this.context;

        public Service()
            :this(new BookOpinionsContext())
        {
        }

        public Service(BookOpinionsContext context)
        {
            this.context = context;
        }
    }
}
