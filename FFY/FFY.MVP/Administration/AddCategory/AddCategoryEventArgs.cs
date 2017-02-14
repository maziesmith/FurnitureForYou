using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.AddCategory
{
    public class AddCategoryEventArgs : EventArgs
    {
        public AddCategoryEventArgs(Category category)
        {
            this.Category = category;
        }

        public Category Category { get; set; }
    }
}
