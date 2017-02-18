using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Data.Factories
{
    public interface IProductFactory
    {
        Product CreateProduct(string name,
            decimal price,
            int discountPercentage,
            bool hasDiscount,
            string description,
            int categoryId,
            Category category,
            int roomId,
            Room room,
            string imagePath,
            bool isDeleted = false);
    }
}
