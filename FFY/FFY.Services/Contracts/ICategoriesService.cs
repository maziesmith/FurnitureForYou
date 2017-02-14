using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services.Contracts
{
    public interface ICategoriesService
    {
        IEnumerable<Category> GetCategories();

        void AddCategory(Category category);
    }
}
