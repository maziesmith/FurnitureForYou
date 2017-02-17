using FFY.Order.Contracts;
using FFY.Order.Factories;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Order
{
    public class ShoppingCart : IShoppingCart
    {
        private ICollection<ICartProduct> cartProducts;
        private readonly ICartProductFactory cartProductFactory;
        private readonly IProductsService productsService;

        public ShoppingCart(ICartProductFactory cartProductFactory,
            IProductsService productsService)
        {
            if(cartProductFactory == null)
            {
                throw new ArgumentNullException("Cart product factory cannot be null");
            }

            if (productsService == null)
            {
                throw new ArgumentNullException("Products service cannot be null");
            }

            this.cartProductFactory = cartProductFactory;
            this.productsService = productsService;
            this.cartProducts = new List<ICartProduct>();
        }

        public ICollection<ICartProduct> CartProducts
        {
            get
            {
                return this.cartProducts;
            }
            private set
            {
                this.cartProducts = value;
            }
        }

        public void Add(int quantity, int productId)
        {
            var currentCartProduct = this.cartProducts.FirstOrDefault(p => p.Product.Id == productId);

            if(currentCartProduct == null)
            {
                var product = this.productsService.GetProductById(productId);

                if(product != null)
                {
                    currentCartProduct = this.cartProductFactory.CreateCartProduct(quantity, product);
                    this.cartProducts.Add(currentCartProduct);
                }
            }
            else
            {
                currentCartProduct.Quantity += quantity;
            }
        }

        public void Remove(int productId)
        {
            var currentCartProduct = this.cartProducts.FirstOrDefault(p => p.Product.Id == productId);

            if(currentCartProduct != null)
            {
                this.cartProducts.Remove(currentCartProduct);
            }
        }

        public void Clear()
        {
            this.cartProducts.Clear();
        }

        public decimal Total()
        {
            return this.cartProducts.Sum(p =>
            (p.Product.Price - (p.Product.Price * p.Product.DiscountPercentage / 100.0M)) * p.Quantity);
        }
    }
}
