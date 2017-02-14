using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.AddCategory
{
    public class AddCategoryPresenter : Presenter<IAddCategoryView>
    {
        private readonly ICategoriesService categoriesServices;

        public AddCategoryPresenter(IAddCategoryView view,
            ICategoriesService categoriesServices) : base(view)
        {
            if (categoriesServices == null)
            {
                throw new ArgumentNullException("Categories service cannot be null");
            }

            this.categoriesServices = categoriesServices;
            this.View.AddingCategory += OnAddingCategory;
        }

        private void OnAddingCategory(object sender, AddCategoryEventArgs e)
        {
            this.categoriesServices.AddCategory(e.Category);
        }
    }
}
