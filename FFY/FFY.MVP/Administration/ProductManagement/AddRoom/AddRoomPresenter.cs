using FFY.Data.Factories;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.ProductManagement.AddRoom
{
    public class AddRoomPresenter : Presenter<IAddRoomView>
    {
        private readonly IRoomsService roomsService;
        private readonly IRoomFactory roomFactory;

        public AddRoomPresenter(IAddRoomView view,
            IRoomFactory roomFactory,
            IRoomsService roomsService) : base(view)
        {
            if(roomsService == null)
            {
                throw new ArgumentNullException("Rooms service cannot be null.");
            }

            if (roomFactory == null)
            {
                throw new ArgumentNullException("Room factory cannot be null.");
            }

            this.roomsService = roomsService;
            this.roomFactory = roomFactory;
            this.View.AddingRoom += OnAddingRoom;
        }

        private void OnAddingRoom(object sender, AddRoomEventArgs e)
        {
            var room = this.roomFactory.CreateRoom(e.RoomName);

            this.roomsService.AddRoom(room);
        }
    }
}
