namespace BookOpinions.Services
{
    using BookOpinions.Data;

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
