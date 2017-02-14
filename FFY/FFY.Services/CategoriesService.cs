using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFY.Models;
using FFY.Data.Contracts;

namespace FFY.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Category> categoriesRepository;

        public CategoriesService(IUnitOfWork unitOfWork,
            IGenericRepository<Category> categoriesRepository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null");
            }

            if (categoriesRepository == null)
            {
                throw new ArgumentNullException("Categories repository cannot be null");
            }

            this.unitOfWork = unitOfWork;
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<Category> GetCategories()
        {
            return this.categoriesRepository.GetAll();
        }

        public void AddCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category cannot be null");
            }

            using (this.unitOfWork)
            {
                this.categoriesRepository.Add(category);
                this.unitOfWork.Commit();
            }
        }
    }
}
