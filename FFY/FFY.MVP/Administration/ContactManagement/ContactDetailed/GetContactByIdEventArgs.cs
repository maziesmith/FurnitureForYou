using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.ContactManagement.ContactDetailed
{
    public class GetContactByIdEventArgs : EventArgs
    {
        public GetContactByIdEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
