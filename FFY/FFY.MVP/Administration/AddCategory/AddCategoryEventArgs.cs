using FFY.Models;
using System;

namespace FFY.MVP.Administration.AddCategory
{
    public class AddCategoryEventArgs : EventArgs
    {
        public AddCategoryEventArgs(Category category)
        {
            if(category == null)
            {
                throw new ArgumentNullException("Category cannot be null");
            }

            this.Category = category;
        }

        public Category Category { get; set; }
    }
}
