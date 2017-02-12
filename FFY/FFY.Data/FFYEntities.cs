using FFY.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Data
{
    public class FFYEntities : IdentityDbContext<User>
    {

        public FFYEntities() : base("FurnitureForYouDb", throwIfV1Schema: false)
        {
        }

        //TODO: possibly remove later, currently extracting things from web
        public static FFYEntities Create()
        {
            return new FFYEntities();
        }
    }
}
