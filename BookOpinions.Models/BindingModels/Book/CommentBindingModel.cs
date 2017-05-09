namespace BookOpinions.Models.BindingModels.Book
{
    public class CommentBindingModel
    {
        public string Comment { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
    }
}
