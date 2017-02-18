using FFY.Models;
using FFY.MVP.Administration.ProductManagement.AddCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FFY.Web.Administration.ProductManagement
{
    [PresenterBinding(typeof(AddCategoryPresenter))]
    public partial class AddCategory : MvpPage<AddCategoryViewModel>, IAddCategoryView
    {
        private const string ExistingCategoryErrorMessage = "Category addition was unsuccessful. The category may already exist";
        public event EventHandler<AddCategoryEventArgs> AddingCategory;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddCategoryClick(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                var name = this.Name.Text;

                try
                {
                    this.AddingCategory?.Invoke(this, new AddCategoryEventArgs(name));
                }
                catch (Exception)
                {
                    this.ErrorMessage.Text = ExistingCategoryErrorMessage;
                }
            }
        }
    }
}