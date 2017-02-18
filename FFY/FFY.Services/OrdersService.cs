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
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Order> ordersRepository;

        public OrdersService(IUnitOfWork unitOfWork, IGenericRepository<Order> ordersRepository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null.");
            }

            if (ordersRepository == null)
            {
                throw new ArgumentNullException("Orders repository cannot be null.");
            }


            this.unitOfWork = unitOfWork;
            this.ordersRepository = ordersRepository;
        }

        public void AddOrder(Order product)
        {
            using (this.unitOfWork)
            {
                this.ordersRepository.Add(product);
                this.unitOfWork.Commit();
            }
        }
    }
}
