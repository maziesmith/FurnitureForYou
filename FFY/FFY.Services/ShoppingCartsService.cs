using FFY.Data.Contracts;
using FFY.Data.Factories;
using FFY.Models;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services
{
    public class ShoppingCartsService : IShoppingCartsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<ShoppingCart> shoppingCartRepository;
        private readonly IGenericRepository<CartProduct> cartProductRepository;
        private readonly ICartProductFactory cartProductFactory;

        public ShoppingCartsService(IUnitOfWork unitOfWork,
            ICartProductFactory cartProductFactory,
            IGenericRepository<ShoppingCart> shoppingCartRepository,
            IGenericRepository<CartProduct> cartProductRepository)
        {
            if(unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null.");
            }

            if(shoppingCartRepository == null)
            {
                throw new ArgumentNullException("Shopping cart repository cannot be null.");
            }

            if (cartProductRepository == null)
            {
                throw new ArgumentNullException("Cart product repository cannot be null.");
            }

            if (cartProductFactory == null)
            {
                throw new ArgumentNullException("Cart product factory cannot be null.");
            }

            this.unitOfWork = unitOfWork;
            this.shoppingCartRepository = shoppingCartRepository;
            this.cartProductRepository = cartProductRepository;
            this.cartProductFactory = cartProductFactory;
        }

        public void AssignShoppingCart(ShoppingCart shoppingCart)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException("Shopping cart cannot be null.");
            }

            using (this.unitOfWork)
            {
                this.shoppingCartRepository.Add(shoppingCart);
                this.unitOfWork.Commit();
            }
        }

        public void Add(int quantity, Product product, string cartId)
        {
            if(product == null)
            {
                throw new ArgumentNullException("Product cannot be null.");
            }

            if(string.IsNullOrEmpty(cartId))
            {
                throw new ArgumentNullException("Cart id cannot be null or empty.");
            }

            var shoppingCart = this.shoppingCartRepository.GetById(cartId);

            var temporaryCartProduct = shoppingCart.TemporaryProducts.FirstOrDefault(p => p.ProductId == product.Id);
            var permanentCartProduct = shoppingCart.PermamentProducts.FirstOrDefault(p => p.ProductId == product.Id);

            if (temporaryCartProduct == null)
            {
                temporaryCartProduct = this.cartProductFactory.CreateCartProduct(quantity, product);
                shoppingCart.TemporaryProducts.Add(temporaryCartProduct);
            }
            else
            {
                temporaryCartProduct.Quantity += quantity;
            }

            if (permanentCartProduct == null)
            {
                permanentCartProduct = this.cartProductFactory.CreateCartProduct(quantity, product);
                shoppingCart.PermamentProducts.Add(permanentCartProduct);
            }
            else
            {
                permanentCartProduct.Quantity += quantity;
            }

            temporaryCartProduct.Total = temporaryCartProduct.Quantity * temporaryCartProduct.Product.DiscountedPrice;
            permanentCartProduct.Total = permanentCartProduct.Quantity * permanentCartProduct.Product.DiscountedPrice;

            shoppingCart.Total = shoppingCart.TemporaryProducts.Sum(p =>
            (p.Product.DiscountedPrice * p.Quantity));

            using (this.unitOfWork)
            {
                this.shoppingCartRepository.Update(shoppingCart);
                this.unitOfWork.Commit();
            }
        }

        public void Remove(int productId, string cartId)
        {
            if(string.IsNullOrEmpty(cartId))
            {
                throw new ArgumentNullException("Cart id cannot be null or empty.");
            }

            var shoppingCart = this.shoppingCartRepository.GetById(cartId);

            var temporaryCartProduct = shoppingCart.TemporaryProducts.FirstOrDefault(p => p.ProductId == productId);
            var permanentCartProduct = shoppingCart.PermamentProducts.FirstOrDefault(p => p.ProductId == productId);

            if (temporaryCartProduct != null)
            {
                this.cartProductRepository.Delete(temporaryCartProduct);
                this.cartProductRepository.Delete(permanentCartProduct);
            }

            shoppingCart.Total = shoppingCart.TemporaryProducts.Sum(p =>
            (p.Product.DiscountedPrice * p.Quantity));

            using (this.unitOfWork)
            {
                this.shoppingCartRepository.Update(shoppingCart);
                this.unitOfWork.Commit();
            }
        }

        public void Clear(ShoppingCart shoppingCart)
        {
            if(shoppingCart == null)
            {
                throw new ArgumentNullException("Shopping cart cannot be null.");
            }

            // Possibly better way to delete products and not clear reference only
            shoppingCart.TemporaryProducts.Clear();

            shoppingCart.Total = 0;

            using (this.unitOfWork)
            {
                this.shoppingCartRepository.Update(shoppingCart);
                this.unitOfWork.Commit();
            }
        }

        public int CartProductsCount(string cartId)
        {
            if (string.IsNullOrEmpty(cartId))
            {
                throw new ArgumentNullException("Cart id cannot be null.");
            }

            return this.shoppingCartRepository.GetById(cartId)
                .TemporaryProducts.Count();
        }

        public ShoppingCart GetCart(string cartId)
        {
            if (string.IsNullOrEmpty(cartId))
            {
                throw new ArgumentNullException("Cart id cannot be null.");
            }

            return this.shoppingCartRepository.GetById(cartId);
        }
    }
}
