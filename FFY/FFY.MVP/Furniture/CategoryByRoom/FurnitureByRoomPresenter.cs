using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Furniture.CategoryByRoom
{
    public class CategoryByRoomPresenter : Presenter<ICategoryByRoomView>
    {
        private readonly ICategoriesService categoriesService;

        public CategoryByRoomPresenter(ICategoryByRoomView view,
            ICategoriesService categoriesService) : base(view)
        {
            if(categoriesService == null)
            {
                throw new ArgumentNullException("Products service cannot be null");
            }

            this.categoriesService = categoriesService;
            this.View.ListingCategoriesByRoom += OnListingCategoriesByRoom;
        }

        private void OnListingCategoriesByRoom(object sender, CategoryByRoomEventArgs e)
        {
            this.View.Model.Categories = this.categoriesService.GetCategoriesByRoomSpecialFiltered(e.RoomName);
        }
    }
}
