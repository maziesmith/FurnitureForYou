using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Data.Factories
{
    public interface IAddressesFactory
    {
        Address CreateAddress(string street, string city, string country);
    }
}
