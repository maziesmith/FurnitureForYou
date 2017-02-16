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

        public ProductsService(IUnitOfWork unitOfWork, IGenericRepository<Product> productsRepository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null.");
            }

            if (productsRepository == null)
            {
                throw new ArgumentNullException("Products repository cannot be null.");
            }


            this.unitOfWork = unitOfWork;
            this.productsRepository = productsRepository;
        }

        public void AddProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException("Product cannot be null.");
            }

            using (this.unitOfWork)
            {
                this.productsRepository.Add(product);
                this.unitOfWork.Commit();
            }
        }

        public Product GetProductsById(int id)
        {
            return this.productsRepository.GetById(id);
        }

        public IEnumerable<Product> GetProductsByRoom(string roomName)
        {
            return this.productsRepository.GetAll(r => r.Room.Name == roomName);
        }

        public IEnumerable<Product> GetProductsByRoomSpecialFiltered(string roomNameFiltered)
        {
            return this.productsRepository.GetAll(r => r.Room.Name.ToLower().Replace(@"\s+", "") == roomNameFiltered);
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.productsRepository.GetAll();
        }
    }
}
