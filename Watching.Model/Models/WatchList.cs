namespace Watching.Model.Models
{
    public class WatchList
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }

        public int WatchingNameId { get; set; }
        public int UserId { get; set; }
        public WatchingName WatchingName { get; set; }
        public User User { get; set; }

    }
}
