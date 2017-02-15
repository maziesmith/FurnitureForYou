﻿using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services.Contracts
{
    public interface IProductsService
    {
        Product GetProductById(int id);

        IEnumerable<Product> GetProductsByRoom(string roomName);

        IEnumerable<Product> GetProductsByRoomSpecialFiltered(string roomName);

        void AddProduct(Product product);

    }
}