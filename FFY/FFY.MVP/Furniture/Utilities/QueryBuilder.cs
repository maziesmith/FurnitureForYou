using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Furniture.Utilities
{
    public class QueryBuilder : IQueryBuilder
    {
        public string BuildProductSearchQuery(string path, string search, string from, string to)
        {
            StringBuilder queryBuilder = new StringBuilder();

            queryBuilder.Append(path);

            if (!string.IsNullOrEmpty(search))
            {
                queryBuilder.Append($"?search={search}");

                if (!string.IsNullOrEmpty(from))
                {
                    queryBuilder.Append($"&from={from}");
                }

                if (!string.IsNullOrEmpty(to))
                {
                    queryBuilder.Append($"&to={to}");
                }
            }
            else if (!string.IsNullOrEmpty(from))
            {
                queryBuilder.Append($"?from={from}");

                if (!string.IsNullOrEmpty(to))
                {
                    queryBuilder.Append($"&to={to}");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(to))
                {
                    queryBuilder.Append($"?to={to}");
                }
            }

            return queryBuilder.ToString();
        }
    }
}
