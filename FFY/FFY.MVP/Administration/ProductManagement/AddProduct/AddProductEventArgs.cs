using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.ProductManagement.AddProduct
{
    public class AddProductEventArgs : EventArgs
    {
        public AddProductEventArgs(string name,
            decimal price,
            int discountPercentage,
            bool hasDiscount,
            string description,
            int categoryId,
            Category category,
            int roomId,
            Room room)
        {
            this.Name = name;
            this.Price = price;
            this.DiscountPercentage = discountPercentage;
            this.HasDiscount = hasDiscount;
            this.Description = description;
            this.CategoryId = categoryId;
            this.Category = category;
            this.RoomId = roomId;
            this.Room = room;
        }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public int DiscountPercentage { get; set; }

        public bool HasDiscount { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Room Room { get; set; }

        public int RoomId { get; set; }
    }
}
