using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watching.Application.Dtos
{
    public class TagContent
    {
        public int WatchListId { get; set; }
        public int ContentId { get; set; }
        public bool IsTagged { get; set; }
    }
}
