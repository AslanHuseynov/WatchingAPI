namespace Watching.Application.Dtos.WatchListDto
{
    public class CreateWatchListDto : BaseWatchListDto
    {
        public int WatchingNameId { get; set; }
        public int UserId { get; set; }
    }
}
