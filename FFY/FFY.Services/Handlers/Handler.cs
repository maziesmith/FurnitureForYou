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

        public IEnumerable<Product> HandleProducts(string path, string room, string category, IProductsService productsService)
        {
            IEnumerable<Product> products = null;

            if (CanHandle(path, room, category))
            {
                products = this.Handle(room, category, productsService);
            }
            else if (this.successor != null)
            {
                products = this.successor.HandleProducts(path, room, category, productsService);
            }

            return products;
        }

        public void SetSuccessor(IHandler successor)
        {
            this.successor = successor;
        }

        protected abstract bool CanHandle(string path, string room, string category);

        protected abstract IEnumerable<Product> Handle(string room, string category, IProductsService productsService);
    }
}
