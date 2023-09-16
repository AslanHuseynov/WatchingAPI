namespace Watching.Application.Dtos.WatchListDto
{
    public class CreateWatchListDto : BaseWatchListDto
    {
        public int ContentId { get; set; }
        public int UserId { get; set; }
    }
}
