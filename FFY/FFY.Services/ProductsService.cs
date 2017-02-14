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
    public class ProductsService : IProductsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Product> productsRepository;
        private readonly IGenericRepository<Room> roomsRepository;
        private readonly IGenericRepository<Category> categoriesRepository;

        public ProductsService(IUnitOfWork unitOfWork, 
            IGenericRepository<Product> productsRepository,
            IGenericRepository<Room> roomsRepository,
            IGenericRepository<Category> categoriesRepository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null");
            }

            if (productsRepository == null)
            {
                throw new ArgumentNullException("Users repository cannot be null");
            }

            if (roomsRepository == null)
            {
                throw new ArgumentNullException("Rooms repository cannot be null");
            }

            if (categoriesRepository == null)
            {
                throw new ArgumentNullException("Categories repository cannot be null");
            }

            this.unitOfWork = unitOfWork;
            this.productsRepository = productsRepository;
            this.roomsRepository = roomsRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public void AddProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException("Product cannot be null");
            }

            using (this.unitOfWork)
            {
                this.productsRepository.Add(product);
                this.unitOfWork.Commit();
            }
        }

        public IEnumerable<Room> GetRooms()
        {
            return this.roomsRepository.GetAll();
        }

        public IEnumerable<Category> GetCategories()
        {
            return this.categoriesRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return this.productsRepository.GetById(id);
        }


    }
}
