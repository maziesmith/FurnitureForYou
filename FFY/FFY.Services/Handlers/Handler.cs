using FFY.Models;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services.Handlers
{
    public abstract class Handler : IHandler
    {
        private IHandler successor;

        public IEnumerable<Product> HandleProducts(IProductsService productsService,
            string path, 
            string room, 
            string category,
            string search,
            bool rangeProvided,
            int from,
            int to)
        {
            IEnumerable<Product> products = null;

            if (CanHandle(path, room, category, search, rangeProvided))
            {
                products = this.Handle(productsService, room, category, search, rangeProvided, from, to);
            }
            else if (this.successor != null)
            {
                products = this.successor.HandleProducts(productsService, path, room, category, search, rangeProvided, from, to);
            }

            return products;
        }

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        protected abstract bool CanHandle(string path, 
            string room, 
            string category, 
            string search, 
            bool rangeProvided);

        protected abstract IEnumerable<Product> Handle(IProductsService productsService, 
            string room, 
            string category, 
            string search, 
            bool rangeProvided,
            int from,
            int to);
    }
}
