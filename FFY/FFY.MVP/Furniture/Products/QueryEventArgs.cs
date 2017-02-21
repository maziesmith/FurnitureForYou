using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Furniture.Products
{
    public class QueryEventArgs : EventArgs
    {
        public QueryEventArgs(string path, string search, string from, string to)
        {
            this.Path = path;
            this.Search = search;
            this.From = from;
            this.To = to;
        }

        public string Path { get; set; }

        public string Search { get; set; }

        public string From { get; set; }

        public string To { get; set; }
    }
}
