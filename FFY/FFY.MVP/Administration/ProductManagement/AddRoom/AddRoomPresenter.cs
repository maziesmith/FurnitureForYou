using FFY.Data.Factories;
using FFY.MVP.Administration.ProductManagement.Utilities;
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
        private readonly IImageUploader imageUploader;

        private string imageFileName;

        public AddRoomPresenter(IAddRoomView view,
            IRoomFactory roomFactory,
            IRoomsService roomsService,
            IImageUploader imageUploader) : base(view)
        {
            if(roomsService == null)
            {
                throw new ArgumentNullException("Rooms service cannot be null.");
            }

            if (roomFactory == null)
            {
                throw new ArgumentNullException("Room factory cannot be null.");
            }

            if (imageUploader == null)
            {
                throw new ArgumentNullException("Image uploader cannot be null.");
            }

            this.roomsService = roomsService;
            this.roomFactory = roomFactory;
            this.imageUploader = imageUploader;
            this.View.AddingRoom += OnAddingRoom;
            this.View.UploadingImage += OnUploadingImage;
        }

        private void OnAddingRoom(object sender, AddRoomEventArgs e)
        {
            var room = this.roomFactory.CreateRoom(e.RoomName, this.imageFileName);

            this.roomsService.AddRoom(room);
        }

        private void OnUploadingImage(object sender, UploadImageEventArgs e)
        {
            this.imageFileName = this.imageUploader.Upload(e.Image, e.Server, e.ImageFileName, e.FolderName);
        }
    }
}
