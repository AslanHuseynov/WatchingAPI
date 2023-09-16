﻿namespace Watching.Model.Models
{
    public class WatchList
    {
        public int Id { get; set; }
        public bool IsTagged { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}