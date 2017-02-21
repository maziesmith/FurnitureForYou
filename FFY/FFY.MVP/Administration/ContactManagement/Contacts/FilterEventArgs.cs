using FFY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Administration.ContactManagement.Contacts
{
    public class FilterEventArgs : EventArgs
    {
        public FilterEventArgs(int statusType, string search)
        {
            this.StatusType = statusType;
            this.Search = search;
        }

        public string Search { get; set; }

        public int StatusType { get; set; }
    }
}
