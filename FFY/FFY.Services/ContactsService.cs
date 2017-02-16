using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFY.Models;
using FFY.Data.Contracts;
using FFY.Services.Contracts;

namespace FFY.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Contact> contactsRepository;

        public ContactsService(IUnitOfWork unitOfWork,
            IGenericRepository<Contact> contactsRepository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null.");
            }

            if (contactsRepository == null)
            {
                throw new ArgumentNullException("Contacts repository cannot be null.");
            }

            this.unitOfWork = unitOfWork;
            this.contactsRepository = contactsRepository;
        }

        public void AddContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException("Contact cannot be null.");
            }

            using (this.unitOfWork)
            {
                this.contactsRepository.Add(contact);
                this.unitOfWork.Commit();
            }
        }

        public void ChangeStatus(int categoryId)
        {
            // TODO
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContacts()
        {
            return this.contactsRepository.GetAll();
        }
    }
}
