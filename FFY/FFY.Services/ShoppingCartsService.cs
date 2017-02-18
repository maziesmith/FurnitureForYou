using FFY.Data.Contracts;
using FFY.Models;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services
{
    public class ShoppingCartsService : IShoppingCartsService
    {
                private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<ShoppingCart> shoppingCartRepository;


        public ShoppingCartsService(IUnitOfWork unitOfWork, IGenericRepository<ShoppingCart> shoppingCartRepository)
        {
            if(unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null.");
            }

            if(shoppingCartRepository == null)
            {
                throw new ArgumentNullException("Users repository cannot be null.");
            }

            this.unitOfWork = unitOfWork;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public void AssignShoppingCart(ShoppingCart shoppingCart)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException("Shopping cart cannot be null.");
            }

            using (this.unitOfWork)
            {
                this.shoppingCartRepository.Add(shoppingCart);
                this.unitOfWork.Commit();
            }
        }
    }
}
