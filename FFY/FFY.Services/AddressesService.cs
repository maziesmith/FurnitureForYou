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
    public class AddressesService : IAddressesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Address> addressesRepository;

        public AddressesService(IUnitOfWork unitOfWork,
            IGenericRepository<Address> addressesRepository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null.");
            }

            if (addressesRepository == null)
            {
                throw new ArgumentNullException("Addresses repository cannot be null.");
            }

            this.unitOfWork = unitOfWork;
            this.addressesRepository = addressesRepository;
        }

        public void Add(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException("Address cannot be null.");
            }

            using (this.unitOfWork)
            {
                this.addressesRepository.Add(address);
                this.unitOfWork.Commit();
            }
        }
    }
}
