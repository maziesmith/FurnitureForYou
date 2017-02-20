using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using FFY.Models;
using FFY.Data.Contracts;

namespace FFY.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Category> categoriesRepository;
        private readonly IGenericRepository<Product> productsRepository;

        public CategoriesService(IUnitOfWork unitOfWork,
            IGenericRepository<Category> categoriesRepository,
            IGenericRepository<Product> productsRepository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null.");
            }

            if (categoriesRepository == null)
            {
                throw new ArgumentNullException("Categories repository cannot be null.");
            }

            if (productsRepository == null)
            {
                throw new ArgumentNullException("Products repository cannot be null.");
            }

            this.unitOfWork = unitOfWork;
            this.categoriesRepository = categoriesRepository;
            this.productsRepository = productsRepository;
        }

        public IEnumerable<Category> GetCategories()
        {
            return this.categoriesRepository.GetAll();
        }

        public void AddCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category cannot be null.");
            }

            using (this.unitOfWork)
            {
                this.categoriesRepository.Add(category);
                this.unitOfWork.Commit();
            }
        }

        public IEnumerable<Category> GetCategoriesByRoomSpecialFiltered(string room)
        {
            return this.productsRepository.GetAll(p => p.Room.Name.ToLower().Replace(@"\s+", "") == room, c => c.Category.Name, q => q.Category);
        }
    }
}
