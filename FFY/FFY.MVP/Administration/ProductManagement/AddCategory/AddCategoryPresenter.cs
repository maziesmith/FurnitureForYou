using FFY.Data.Factories;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.ProductManagement.AddCategory
{
    public class AddCategoryPresenter : Presenter<IAddCategoryView>
    {
        private readonly ICategoriesService categoriesServices;
        private readonly ICategoryFactory categoryFactory;

        public AddCategoryPresenter(IAddCategoryView view,
            ICategoryFactory categoryFactory,
            ICategoriesService categoriesServices) : base(view)
        {
            if (categoriesServices == null)
            {
                throw new ArgumentNullException("Categories service cannot be null.");
            }
            
            if(categoryFactory == null)
            {
                throw new ArgumentNullException("Category factory cannot be null.");
            }

            this.categoriesServices = categoriesServices;
            this.categoryFactory = categoryFactory;
            this.View.AddingCategory += OnAddingCategory;
        }

        private void OnAddingCategory(object sender, AddCategoryEventArgs e)
        {
            var category = this.categoryFactory.CreateCategory(e.Name);

            this.categoriesServices.AddCategory(category);
        }
    }
}
