using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.UserManagement.UserDetailed
{
    public class GetUserByIdEventArgs : EventArgs
    {
        public GetUserByIdEventArgs(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}
