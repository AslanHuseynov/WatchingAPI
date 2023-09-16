namespace Watching.Model.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int? WatchListId { get; set; }
        public WatchList WatchList { get; set; }
    }
}
