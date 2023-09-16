namespace Watching.Model.Models
{
    public class Content2WatchList
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public Content Content { get; set; }
        public int WatchListId { get; set; }
        public WatchList WatchList { get; set; }
        public bool IsTagged { get; set; }


    }
}
