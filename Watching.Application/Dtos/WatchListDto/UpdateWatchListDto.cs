﻿namespace Watching.Application.Dtos.WatchListDto
{
    public class UpdateWatchListDto : BaseWatchListDto
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }
    }
}
