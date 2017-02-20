using FFY.Models;
using System.Collections.Generic;

namespace FFY.Services.Contracts
{
    public interface ICategoriesService
    {
        IEnumerable<Category> GetCategories();

        void AddCategory(Category category);

        IEnumerable<Category> GetCategoriesByRoomSpecialFiltered(string roomName);
    }
}
