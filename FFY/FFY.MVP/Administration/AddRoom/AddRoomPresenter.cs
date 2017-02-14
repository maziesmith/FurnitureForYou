using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Administration.AddRoom
{
    public class AddRoomPresenter : Presenter<IAddRoomView>
    {
        private readonly IRoomsService roomsService;
        public AddRoomPresenter(IAddRoomView view,
            IRoomsService roomsService) : base(view)
        {
            if(roomsService == null)
            {
                throw new ArgumentNullException("Rooms service cannot be null");
            }

            this.roomsService = roomsService;
            this.View.AddingRoom += OnAddingRoom;
        }

        private void OnAddingRoom(object sender, AddRoomEventArgs e)
        {
            this.roomsService.AddRoom(e.Room);
        }
    }
}
