using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.OrderManagement.OrderDetailed
{
    public class GetOrderByIdEventArgs : EventArgs
    {
        public GetOrderByIdEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
