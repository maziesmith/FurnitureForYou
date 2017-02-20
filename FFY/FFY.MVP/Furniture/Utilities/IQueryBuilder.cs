using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Furniture.Utilities
{
    public interface IQueryBuilder
    {
        string BuildProductSearchQuery(string path, string search, string from, string to);
    }
}
