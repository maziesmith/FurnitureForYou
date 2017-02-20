using FFY.Models;
using System;

namespace FFY.MVP.Administration.ProductManagement.AddCategory
{
    public class AddCategoryEventArgs : EventArgs
    {
        public AddCategoryEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
