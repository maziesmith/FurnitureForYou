using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Home
{
    public class HomeEventArgs : EventArgs
    {
        public HomeEventArgs(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; set; }
    }
}
