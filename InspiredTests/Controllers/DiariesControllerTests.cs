using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspired.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspiredTests;
using System.Web;
using Moq;
using System.Web.Routing;
using System.Web.Mvc;
using System.Data.Entity;
using Inspired.Models;
using System.Collections.Specialized;

namespace Inspired.Controllers.Tests
{
    [TestClass()]
    public class DiariesControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var setUp = new TestSetUp();
            setUp.ChapterSetUp();
            setUp.FollowDiarySetUp();
            var controller = new DiariesController(setUp.mockContext.Object);

            var diaryDb = new Mock<DbSet<Diary>>();
            diaryDb.Setup(x => x.Find(1)).Returns(new Diary());

            setUp.mockContext.Setup(c => c.Diary).Returns(diaryDb.Object);

            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);

            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["accountid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.Index(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void AddFollTest()
        {
            var setUp = new TestSetUp();
            setUp.ChapterSetUp();
            setUp.FollowDiarySetUp();
            var controller = new DiariesController(setUp.mockContext.Object);

            var request = new Mock<HttpRequestBase>();
            var session = new Mock<HttpSessionStateBase>();
            var context = new Mock<HttpContextBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            context.SetupGet(x => x.Session["accountid"]).Returns("1");
            context.Setup(x => x.Request).Returns(request.Object);

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);
            var result = controller.AddFoll(1) as JsonResult;

            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod()]
        public void UnFoll()
        {
            var setUp = new TestSetUp();
            setUp.FollowDiarySetUp();
            var controller = new DiariesController(setUp.mockContext.Object);

            var request = new Mock<HttpRequestBase>();
            var session = new Mock<HttpSessionStateBase>();
            var context = new Mock<HttpContextBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            context.SetupGet(x => x.Session["accountid"]).Returns("1");
            context.Setup(x => x.Request).Returns(request.Object);

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);
            var result = controller.UnFoll(1) as JsonResult;

            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod()]
        public void DiaryIndexTest()
        {
            var setUp = new TestSetUp();
            setUp.ChapterSetUp();
            setUp.FollowDiarySetUp();
            var controller = new DiariesController(setUp.mockContext.Object);

            var diaryDb = new Mock<DbSet<Diary>>();
            diaryDb.Setup(x => x.Find(1)).Returns(new Diary());

            setUp.mockContext.Setup(c => c.Diary).Returns(diaryDb.Object);

            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);

            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["accountid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.DiaryIndex(1, "Diary") as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void ChapterDetailTest()
        {
            var setUp = new TestSetUp();
            setUp.ChapterSetUp();
            var controller = new DiariesController(setUp.mockContext.Object);

            var diaryDb = new Mock<DbSet<Diary>>();
            diaryDb.Setup(x => x.Find(1)).Returns(new Diary());

            var chapterDb = new Mock<DbSet<Chapter>>();
            var chapters = new Chapter[]
                {
                new Chapter() {
                    id = 1,
                    diaryid = 1,
                    name = "Chapter A",
                    detail = "Chapter A Detail",
                    pic1 = "ChapterA1.jpg",
                    pic2 = "ChapterA2.jpg",
                    timestamp = DateTime.Now,
                    views = 1
                  },
                new Chapter() {
                    id = 2,
                    diaryid = 1,
                    name = "Chapter B",
                    detail = "Chapter B Detail",
                    pic1 = "ChapterB1.jpg",
                    pic2 = "ChapterB2.jpg",
                    timestamp = DateTime.Now,
                    views = 1
                  },
                };
            chapterDb.As<IQueryable<Chapter>>().Setup(m => m.Provider)
                   .Returns(chapters.AsQueryable().Provider);
            chapterDb.As<IQueryable<Chapter>>().Setup(m => m.Expression)
                    .Returns(chapters.AsQueryable().Expression);
            chapterDb.As<IQueryable<Chapter>>().Setup(m => m.ElementType)
                    .Returns(chapters.AsQueryable().ElementType);
            chapterDb.As<IQueryable<Chapter>>().Setup(m => m.GetEnumerator())
                    .Returns(chapters.AsQueryable().GetEnumerator());
            chapterDb.Setup(x => x.Find(1)).Returns(new Chapter());

            setUp.mockContext.Setup(c => c.Diary).Returns(diaryDb.Object);
            setUp.mockContext.Setup(c => c.Chapter).Returns(chapterDb.Object);

            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);

            context.SetupGet(x => x.Session["diaryid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.ChapterDetail("User", 1, "Chapter", 1) as ViewResult;

            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void GetCreateTest()
        {
            var setUp = new TestSetUp();
            setUp.CatSetUp();
            var controller = new DiariesController(setUp.mockContext.Object);

            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["accountid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void PostCreateTest()
        {
            var setUp = new TestSetUp();
            setUp.CatSetUp();
            setUp.DiarySetUp();
            setUp.CatDiarySetUp();
            var controller = new DiariesController(setUp.mockContext.Object);

            var request = new Mock<HttpRequestBase>();
            var session = new Mock<HttpSessionStateBase>();
            var context = new Mock<HttpContextBase>();

            var requestParams = new NameValueCollection { { "catdiaries", "123456" } };
            request.SetupGet(x => x.Form).Returns(requestParams);

            context.Setup(x => x.Session).Returns(session.Object);
            context.SetupGet(x => x.Session["accountid"]).Returns("1");

            context.Setup(x => x.Request).Returns(request.Object);

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);
            Diary diary = new Diary();
            diary.userid = 1;
            var result = controller.Create(diary) as ViewResult;

            //setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void SettingDiaryTest()
        {
            var setUp = new TestSetUp();
            setUp.CatSetUp();
            setUp.CatDiarySetUp();

            var diaryDb = new Mock<DbSet<Diary>>();
            diaryDb.Setup(x => x.Find(1)).Returns(new Diary());
            setUp.mockContext.Setup(c => c.Diary).Returns(diaryDb.Object);

            var controller = new DiariesController(setUp.mockContext.Object);

            var request = new Mock<HttpRequestBase>();
            var session = new Mock<HttpSessionStateBase>();
            var context = new Mock<HttpContextBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["accountid"]).Returns("1");
            context.SetupGet(x => x.Session["diaryid"]).Returns("1");
            context.Setup(x => x.Request).Returns(request.Object);

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);
            var result = controller.SettingDiary(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void AddOwnerTest()
        {
            var setUp = new TestSetUp();
            setUp.CatDiarySetUp();
            var controller = new DiariesController(setUp.mockContext.Object);

            var request = new Mock<HttpRequestBase>();
            var session = new Mock<HttpSessionStateBase>();
            var context = new Mock<HttpContextBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            context.SetupGet(x => x.Session["diaryid"]).Returns("1");
            context.Setup(x => x.Request).Returns(request.Object);

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);
            var result = controller.AddOwner(1) as JsonResult;

            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod()]
        public void DeleteOwnerTest()
        {
            var setUp = new TestSetUp();
            setUp.CatDiarySetUp();
            var controller = new DiariesController(setUp.mockContext.Object);

            var request = new Mock<HttpRequestBase>();
            var session = new Mock<HttpSessionStateBase>();
            var context = new Mock<HttpContextBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            context.SetupGet(x => x.Session["diaryid"]).Returns("1");
            context.Setup(x => x.Request).Returns(request.Object);

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);
            var result = controller.DeleteOwner(1) as JsonResult;

            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod()]
        public void DeleteDiaryTest()
        {
            var setUp = new TestSetUp();
            setUp.ChapterSetUp();
            setUp.CatDiarySetUp();
            var controller = new DiariesController(setUp.mockContext.Object);

            var diaryDb = new Mock<DbSet<Diary>>();
            diaryDb.Setup(x => x.Find(1)).Returns(new Diary());
            
            setUp.mockContext.Setup(c => c.Diary).Returns(diaryDb.Object);

            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["diaryid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.DeleteDiary(1) as JsonResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod()]
        public void StatisticDiaryTest()
        {
            var setUp = new TestSetUp();
            var controller = new DiariesController(setUp.mockContext.Object);

            var diaryDb = new Mock<DbSet<Diary>>();
            diaryDb.Setup(x => x.Find(1)).Returns(new Diary());

            setUp.mockContext.Setup(c => c.Diary).Returns(diaryDb.Object);

            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);

            context.SetupGet(x => x.Session["diaryid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.StatisticDiary(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void ChapterDiaryTest()
        {
            var setUp = new TestSetUp();
            setUp.ChapterSetUp();
            var controller = new DiariesController(setUp.mockContext.Object);

            var diaryDb = new Mock<DbSet<Diary>>();
            diaryDb.Setup(x => x.Find(1)).Returns(new Diary());

            setUp.mockContext.Setup(c => c.Diary).Returns(diaryDb.Object);

            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            context.SetupGet(x => x.Session["Authen"]).Returns("1");
            context.SetupGet(x => x.Session["diaryid"]).Returns("1");

            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            var result = controller.StatisticDiary(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}