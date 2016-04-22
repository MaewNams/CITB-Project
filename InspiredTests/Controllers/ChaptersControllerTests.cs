using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspired.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using Moq;
using System.Web.Routing;
using InspiredTests;
using System.Data.Entity;
using Inspired.Models;

namespace Inspired.Controllers.Tests
{
    [TestClass()]
    public class ChaptersControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var controller = new ChaptersController();
            var result = controller.Index();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void GetCreateChapterTest()
        {
            var setUp = new TestSetUp();
            setUp.DiarySetUp();

            var controller = new ChaptersController(setUp.mockContext.Object);
            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["diaryid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            
            var result = controller.CreateChapter() as ViewResult;
            Assert.IsNull(result);
            //Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void PostCreateChapterTest()
        {
            var setUp = new TestSetUp();
            setUp.ChapterSetUp();

            var controller = new ChaptersController(setUp.mockContext.Object);
            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();

            context.Setup(x => x.Session).Returns(session.Object);
            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["diaryid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.CreateChapter("New Chapter","This Is New Chapter") as JsonResult;
            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod()]
        public void DeleteChapterTest()
        {
            var setUp = new TestSetUp();
            setUp.ChapterSetUp();

            var controller = new ChaptersController(setUp.mockContext.Object);

            var result = controller.DeleteChapter(1);
            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod()]
        public void GetEditChapterTest()
        {
            var setUp = new TestSetUp();
            setUp.DiarySetUp();
            setUp.ChapterSetUp();

            var controller = new ChaptersController(setUp.mockContext.Object);
            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();

            context.Setup(x => x.Session).Returns(session.Object);
            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["diaryid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.EditChapter(1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void PostEditChapterTest()
        {
            var setUp = new TestSetUp();
            var chapterDb = new Mock<DbSet<Chapter>>();
            chapterDb.Setup(x => x.Find(1)).Returns(new Chapter());

            setUp.mockContext.Setup(c => c.Chapter).Returns(chapterDb.Object);

            var controller = new ChaptersController(setUp.mockContext.Object);

            var result = controller.EditChapter(1, "New Chapter", "This Is New Chapter");
            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }
    }
}