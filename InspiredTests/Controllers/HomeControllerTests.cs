using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspired.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspiredTests;
using System.Web.Mvc;
using Moq;
using System.Web;
using System.Web.Routing;
using Inspired.Models;

namespace Inspired.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var setUp = new TestSetUp();
            setUp.DiarySetUp();
            var controller = new HomeController(setUp.mockContext.Object);

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void AdoptionDetailTest()
        {
            var controller = new HomeController();
            var result = controller.AdoptionDetail();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void AdoptionTest()
        {
            var controller = new HomeController();

            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);

            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["accountid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.Adoption() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void MyDiaryTest()
        {
            var setUp = new TestSetUp();
            setUp.DiarySetUp();
            setUp.FollowDiarySetUp();
            var controller = new HomeController(setUp.mockContext.Object);

            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);

            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["accountid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.MyDiary() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void AllDiaryTest()
        {
            var setUp = new TestSetUp();
            setUp.DiarySetUp();
            setUp.FollowDiarySetUp();
            var controller = new HomeController(setUp.mockContext.Object);

            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);

            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["accountid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.AllDiary() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void GetCatCensusTest()
        {
            var setUp = new TestSetUp();
            setUp.BreedSetUp();
            setUp.CatSetUp();
            var controller = new HomeController(setUp.mockContext.Object);

            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);

            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["accountid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.CatCensus() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void PostCatCensusTest()
        {
            var setUp = new TestSetUp();
            setUp.CatSetUp();
            var controller = new HomeController(setUp.mockContext.Object);

            Cat cat = new Cat();
            cat.id = 1;
            cat.name = "Cat";
            cat.userid = 1;
            cat.status = 1;
            cat.birthdate = DateTime.Now;
            cat.adoptdate = DateTime.Now;
            cat.deathdate = DateTime.Now;

            var request = new Mock<HttpRequestBase>();
            var session = new Mock<HttpSessionStateBase>();
            var context = new Mock<HttpContextBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            context.SetupGet(x => x.Session["accountid"]).Returns("1");
            context.Setup(x => x.Request).Returns(request.Object);

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);
            var result = controller.CatCensus(cat) as RedirectToRouteResult;

            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod()]
        public void CatTimelineTest()
        {
            var controller = new HomeController();
            var result = controller.CatTimeline();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void MyForumTest()
        {
            var controller = new HomeController();
            var result = controller.MyForum();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void ProfileTest()
        {
            var controller = new HomeController();
            var result = controller.Profile();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void AboutTest()
        {
            var controller = new HomeController();
            var result = controller.About();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void ContactTest()
        {
            var controller = new HomeController();
            var result = controller.Contact();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}