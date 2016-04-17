using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using InspiredTests;
using Inspired.Models;
using Moq;
using System.Collections.Specialized;

namespace Inspired.Controllers.Tests
{
    [TestClass()]
    public class AccountsControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var controller = new AccountsController();
            var result = controller.Index();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void GetLoginTest()
        {
            var controller = new AccountsController();
            var result = controller.Login();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }

        [TestMethod()]
        public void PostLoginTest()
        {
            var setUp = new TestSetUp();
            setUp.AccountSetUp();
            var controller = new AccountsController(setUp.mockContext.Object);

            Account user = new Account();
            user.username = "UserA";
            user.password = "123456";

            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            //context.SetupGet(x => x.Session["Authen"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.Login(user) as RedirectToRouteResult;
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod()]
        public void LogoutTest()
        {

            var controller = new AccountsController();

            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);

            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["Username"]).Returns("1");
            context.SetupGet(x => x.Session["AccountID"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.Logout() as RedirectToRouteResult;
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod()]
        public void GetRegisterTest()
        {
            var controller = new AccountsController();
            var result = controller.Register();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }

        [TestMethod()]
        public void PostRegisterTest()
        {
            var setUp = new TestSetUp();
            setUp.AccountSetUp();
            var controller = new AccountsController(setUp.mockContext.Object);

            Account user = new Account();
            user.username = "UserC";
            user.password = "123456";
            user.email = "c@c.c";
            user.usertypeid = 1;

            var request = new Mock<HttpRequestBase>();
            var requestParams = new NameValueCollection { { "repassword", "123456" } };
            request.SetupGet(x => x.Form).Returns(requestParams);

            var session = new Mock<HttpSessionStateBase>();

            var context = new Mock<HttpContextBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            context.Setup(x => x.Request).Returns(request.Object);

            //context.SetupGet(x => x.Session["Authen"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);
            var result = controller.Register(user) as RedirectToRouteResult;

            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
    }
}