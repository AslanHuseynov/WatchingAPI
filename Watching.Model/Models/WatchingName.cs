﻿namespace Watching.Model.Models
{
    public class WatchingName
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
