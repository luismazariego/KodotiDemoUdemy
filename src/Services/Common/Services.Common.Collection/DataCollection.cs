using System.Collections.Generic;
using System.Linq;

namespace Services.Common.Collection
{
    public class DataCollection<T> 
    {
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }

        public bool HasItems
        {
            get => Items is not null && Items.Any();            
        }
    }
}
