using FFY.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IFFYContext context;
        public UnitOfWork(IFFYContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException("Context cannot be null.");
            }

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
