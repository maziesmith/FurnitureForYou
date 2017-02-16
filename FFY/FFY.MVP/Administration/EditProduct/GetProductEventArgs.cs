﻿using System;

namespace FFY.MVP.Administration.EditProduct
{
    public class GetProductEventArgs : EventArgs
    {
        public GetProductEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}