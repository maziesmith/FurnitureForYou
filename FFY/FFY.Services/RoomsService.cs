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
    public class RoomsService : IRoomsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Room> roomsRepository;

        public RoomsService(IUnitOfWork unitOfWork,
            IGenericRepository<Room> roomsRepository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null");
            }

            if (roomsRepository == null)
            {
                throw new ArgumentNullException("Rooms repository cannot be null");
            }

            this.unitOfWork = unitOfWork;
            this.roomsRepository = roomsRepository;
        }

        public IEnumerable<Room> GetRooms()
        {
            return this.roomsRepository.GetAll();
        }

        public void AddRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException("Room cannot be null");
            }

            using (this.unitOfWork)
            {
                this.roomsRepository.Add(room);
                this.unitOfWork.Commit();
            }
        }
    }
}
