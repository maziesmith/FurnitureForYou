using FFY.Models;
using System;

namespace FFY.MVP.Administration.ProductManagement.AddCategory
{
    public class AddCategoryEventArgs : EventArgs
    {
        public AddCategoryEventArgs(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Category name cannot be null or empty.");
            }

            this.Name = name;
        }

        public string Name { get; set; }
    }
}
