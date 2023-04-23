namespace Searcher.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Site { get; set; }
        public string ImageUrl { get; set; }
        public string SearchTerm { get; set; }
        public DateTime SearchDate { get; set; }

    }
}
