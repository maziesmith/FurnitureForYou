using FFY.MVP.Account.Login;
using FFY.Services.Contracts;
using FFY.MVP.Tests.Account.LoginPresenterTests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace FFY.MVP.Tests.Account.LoginPresenterTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldCreateAnInstanceInheritingPresenter_WhenValidShoppingCartServiceIsPassed()
        {
            // Arrange
            var mockedView = new Mock<ILoginView>();

            // Act and Assert
            var loginPresenter = new LoginPresenter(mockedView.Object);

            Assert.IsInstanceOf<Presenter<ILoginView>>(loginPresenter);
        }

        [Test]
        public void ShouldSubscribeToLoginViewOnLogingEvent()
        {
            // Arrange
            var mockedView = new MockedLoginView();

            // Act and Assert
            var loginPresenter = new LoginPresenter(mockedView);

            Assert.IsTrue(mockedView.IsSubscribedMethod("OnLoggingIn"));
        }
    }
}
