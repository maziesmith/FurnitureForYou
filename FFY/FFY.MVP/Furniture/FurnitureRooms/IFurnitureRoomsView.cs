﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Furniture.ListProductsRooms
{
    public interface IFurnitureRoomsView : IView<FurnitureRoomsViewModel>
    {
        event EventHandler ListingFurnitureRooms;
    }
}
