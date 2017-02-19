using FFY.Data.Contracts;
using FFY.Data.Factories;
using FFY.Models;
using FFY.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.Services.ShoppingCartsServiceTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullProductIsPassed()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => shoppingCartsService.Add(1, null, "cart-id"));
        }

        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullProductIsPassed()
        {
            // Arrange
            var expectedExMessage = "Product cannot be null.";

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                shoppingCartsService.Add(1, null, "cart-id"));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrowArgumentNullException_WhenNullOrEmptyCartIdIsPassed(string cartId)
        {
            // Arrange
            var product = new Mock<Product>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => 
                shoppingCartsService.Add(1, product.Object, cartId));
        }

        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenNullOrEmptyCartIdIsPassed(string cartId)
        {
            // Arrange
            var expectedExMessage = "Cart id cannot be null or empty.";

            var product = new Mock<Product>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                shoppingCartsService.Add(1, product.Object, cartId));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldCallGetByIdMethodOfShoppingCartRepositoryOnce_WhenShoppingCartIsPassed()
        {
            // Arrange
            var cartId = "42-123";

            var product = new Product();
            // Temporary and Permanent products are empty and it shouldn't find product
            var shoppingCart = new ShoppingCart();
            var cartProduct = new CartProduct() { Product = product };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct);
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => 
                shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart)
                .Verifiable();

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Add(1, product, cartId);

            // Assert
            mockedShoppingCartRepository.Verify(shr => shr.GetById(cartId), Times.Once);
        }

        [Test]
        public void ShouldGetProductFactoryOfCartProductFactoryTwice_WhenShoppingCartIsFoundAndProductIsNotInTheTemporaryAndPermanentProducts()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 2;

            var product = new Product();
            // Temporary and Permanent products are empty and it shouldn't find product
            var shoppingCart = new ShoppingCart();
            var cartProduct = new CartProduct() { Product = product };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf => 
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Add(quantity, product, cartId);

            // Assert
            mockedCartProductFactory.Verify(cpf => 
            cpf.CreateCartProduct(quantity, product), Times.Exactly(2));
        }

        [Test]
        public void ShouldGetProductFactoryOfCartProductFactoryOnce_WhenShoppingCartIsFoundAndProductIsNotInThePermanentProducts()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 2;

            var product = new Product() { Id = 42 };
            var cartProduct = new CartProduct() { Product = product, ProductId = product.Id };
            var shoppingCart = new ShoppingCart()
            {
                TemporaryProducts = new List<CartProduct> { cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Add(quantity, product, cartId);

            // Assert
            mockedCartProductFactory.Verify(cpf =>
            cpf.CreateCartProduct(quantity, product), Times.Once);
        }

        [Test]
        public void ShouldGetProductFactoryOfCartProductFactoryOnce_WhenShoppingCartIsFoundAndProductIsNotInTheTemporaryProducts()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 2;

            var product = new Product() { Id = 42 };
            var cartProduct = new CartProduct() { Product = product, ProductId = product.Id };
            var shoppingCart = new ShoppingCart()
            {
                PermamentProducts = new List<CartProduct> { cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Add(quantity, product, cartId);

            // Assert
            mockedCartProductFactory.Verify(cpf =>
            cpf.CreateCartProduct(quantity, product), Times.Once);
        }

        [Test]
        public void ShouldAddProductToTemporaryProductsOfShoppingCart_WhenShoppingCartIsFoundAndProductIsNotInTheTemporaryProducts()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 2;

            var product = new Product() { Id = 42 };
            var cartProduct = new CartProduct() { Product = product, ProductId = product.Id };
            var shoppingCart = new ShoppingCart()
            {
                PermamentProducts = new List<CartProduct> { cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            var countBefore = shoppingCart.TemporaryProducts.Count;
            shoppingCartsService.Add(quantity, product, cartId);
            var countAfter = shoppingCart.TemporaryProducts.Count;

            // Assert
            Assert.AreEqual(countBefore, countAfter - 1);
        }

        [Test]
        public void ShouldAddExactProductToTemporaryProductsOfShoppingCart_WhenShoppingCartIsFoundAndProductIsNotInTheTemporaryProducts()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 2;

            var product = new Product() { Id = 42 };
            var cartProduct = new CartProduct() { Product = product, ProductId = product.Id };
            var shoppingCart = new ShoppingCart()
            {
                PermamentProducts = new List<CartProduct> { cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Add(quantity, product, cartId);

            // Assert
            Assert.AreSame(cartProduct, shoppingCart.TemporaryProducts.First());
        }

        [Test]
        public void ShouldAddProductToPermanentProductsOfShoppingCart_WhenShoppingCartIsFoundAndProductIsNotInThePermanentProducts()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 2;

            var product = new Product() { Id = 42 };
            var cartProduct = new CartProduct() { Product = product, ProductId = product.Id };
            var shoppingCart = new ShoppingCart()
            {
                TemporaryProducts = new List<CartProduct> { cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            var countBefore = shoppingCart.PermamentProducts.Count;
            shoppingCartsService.Add(quantity, product, cartId);
            var countAfter = shoppingCart.PermamentProducts.Count;

            // Assert
            Assert.AreEqual(countBefore, countAfter - 1);
        }

        [Test]
        public void ShouldAddExactProductToPermanentProductsOfShoppingCart_WhenShoppingCartIsFoundAndProductIsNotInThePermanentProducts()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 2;

            var product = new Product() { Id = 42 };
            var cartProduct = new CartProduct() { Product = product, ProductId = product.Id };
            var shoppingCart = new ShoppingCart()
            {
                TemporaryProducts = new List<CartProduct> { cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Add(quantity, product, cartId);

            // Assert
            Assert.AreSame(cartProduct, shoppingCart.PermamentProducts.First());
        }

        [Test]
        public void ShouldIncreaseFoundPermanentProductQuantityFromShoppingCart_WhenProductIsFoundInThePermanentProducts()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 4;

            var product = new Product() { Id = 42 };
            var cartProduct = new CartProduct() { Product = product, ProductId = product.Id };
            var shoppingCart = new ShoppingCart()
            {
                PermamentProducts = new List<CartProduct> { cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            var quantityBefore = cartProduct.Quantity;
            shoppingCartsService.Add(quantity, product, cartId);
            var quantityAfter = cartProduct.Quantity;

            // Assert
            Assert.AreEqual(quantityBefore, quantityAfter - quantity);
        }

        [Test]
        public void ShouldIncreaseFoundTemporaryProductQuantityFromShoppingCart_WhenProductIsFoundInTheTemporaryProducts()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 4;

            var product = new Product() { Id = 42 };
            // Temporary products is empty and it shouldn't find product
            var cartProduct = new CartProduct() { Product = product, ProductId = product.Id };
            var shoppingCart = new ShoppingCart()
            {
                TemporaryProducts = new List<CartProduct> { cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            var quantityBefore = cartProduct.Quantity;
            shoppingCartsService.Add(quantity, product, cartId);
            var quantityAfter = cartProduct.Quantity;

            // Assert
            Assert.AreEqual(quantityBefore, quantityAfter - quantity);
        }

        [Test]
        public void ShouldCalculateTotalOfFoundTemporaryProductFromShoppingCart_WhenProductIsFoundInTheTemporaryProducts()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 4;
            var price = 12;

            var product = new Product() { Id = 42, DiscountedPrice = price };
            // Temporary products is empty and it shouldn't find product
            var cartProduct = new CartProduct() { Product = product, ProductId = product.Id };
            var shoppingCart = new ShoppingCart()
            {
                TemporaryProducts = new List<CartProduct> { cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Add(quantity, product, cartId);

            // Assert
            Assert.AreEqual(cartProduct.Total, quantity * price);
        }

        [Test]
        public void ShouldCalculateTotalOfFoundPermanentProductFromShoppingCart_WhenProductIsFoundInThePermanentProducts()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 4;
            var price = 12;

            var product = new Product() { Id = 42, DiscountedPrice = price };
            // Temporary products is empty and it shouldn't find product
            var cartProduct = new CartProduct() { Product = product, ProductId = product.Id };
            var shoppingCart = new ShoppingCart()
            {
                PermamentProducts = new List<CartProduct> { cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Add(quantity, product, cartId);

            // Assert
            Assert.AreEqual(cartProduct.Total, quantity * price);
        }

        [Test]
        public void ShouldCalculateTotalOfShoppingCart_WhenProductIsFoundInTheTemporaryProducts()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 4;
            var price = 12;

            var product = new Product() { Id = 42, DiscountedPrice = price };
            // Temporary products is empty and it shouldn't find product
            var cartProduct = new CartProduct() { Product = product, ProductId = product.Id };
            var shoppingCart = new ShoppingCart()
            {
                TemporaryProducts = new List<CartProduct> { cartProduct }
            };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Add(quantity, product, cartId);

            // Assert
            Assert.AreEqual(shoppingCart.Total, quantity * price);
        }

        [Test]
        public void ShouldCallUpdateMethodOfShoppingCartRepository_WhenAllOperationsAreDone()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 2;

            var product = new Product();
            // Temporary and Permanent products are empty and it shouldn't find product
            var shoppingCart = new ShoppingCart();
            var cartProduct = new CartProduct() { Product = product };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => 
                shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);
            mockedShoppingCartRepository.Setup(shr => 
                shr.Update(It.IsAny<ShoppingCart>()))
                .Verifiable();

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Add(quantity, product, cartId);

            // Assert
            mockedShoppingCartRepository.Verify(shr => shr.Update(shoppingCart), Times.Once);
        }

        [Test]
        public void ShouldCallCommitMethodOfUnitOfWork_WhenAllOperationsAreDone()
        {
            // Arrange
            var cartId = "42-123";
            var quantity = 2;

            var product = new Product();
            // Temporary and Permanent products are empty and it shouldn't find product
            var shoppingCart = new ShoppingCart();
            var cartProduct = new CartProduct() { Product = product };
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            mockedUnitOfWork.Setup(uow => uow.Commit()).Verifiable();
            var mockedCartProductFactory = new Mock<ICartProductFactory>();
            mockedCartProductFactory.Setup(cpf =>
                cpf.CreateCartProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .Returns(cartProduct)
                .Verifiable();

            var mockedCartProductRepository = new Mock<IGenericRepository<CartProduct>>();
            var mockedShoppingCartRepository = new Mock<IGenericRepository<ShoppingCart>>();
            mockedShoppingCartRepository.Setup(shr => shr.GetById(It.IsAny<string>()))
                .Returns(shoppingCart);

            var shoppingCartsService = new ShoppingCartsService(mockedUnitOfWork.Object,
                    mockedCartProductFactory.Object,
                    mockedShoppingCartRepository.Object,
                    mockedCartProductRepository.Object);

            // Act
            shoppingCartsService.Add(quantity, product, cartId);

            // Assert
            mockedUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
    }
}
