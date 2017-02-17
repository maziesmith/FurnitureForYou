using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Users.Profile
{
    public class ProfileByIdEventArgs : EventArgs
    {
        public ProfileByIdEventArgs(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}
