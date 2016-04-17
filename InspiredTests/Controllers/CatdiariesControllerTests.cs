using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspired.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using InspiredTests;
using System.Data.Entity;
using Moq;
using Inspired.Models;
using System.Web;
using System.Web.Routing;

namespace Inspired.Controllers.Tests
{
    [TestClass()]
    public class CatdiariesControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var setUp = new TestSetUp();
            var catDiaryDb = new Mock<DbSet<Catdiary>>();

            setUp.mockContext.Setup(c => c.Catdiary).Returns(catDiaryDb.Object);
            setUp.CatDiarySetUp();

            var controller = new CatdiariesController(setUp.mockContext.Object);
            var result = controller.Index();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var setUp = new TestSetUp();
            var catDb = new Mock<DbSet<Catdiary>>();
            catDb.Setup(x => x.Find(1)).Returns(new Catdiary());
            setUp.mockContext.Setup(c => c.Catdiary).Returns(catDb.Object);
            var controller = new CatdiariesController(setUp.mockContext.Object);

            var result = controller.Details(1) as JsonResult;
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void GetCreateTest()
        {
            var setUp = new TestSetUp();
            setUp.CatSetUp();
            setUp.DiarySetUp();

            var controller = new CatdiariesController(setUp.mockContext.Object);
            var result = controller.Create();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void PostCreateTest()
        {
            var setUp = new TestSetUp();
            setUp.CatDiarySetUp();

            var controller = new CatdiariesController(setUp.mockContext.Object);

            var catDiary = new Catdiary();
            catDiary.id = 1;
            catDiary.catid = 1;
            catDiary.diaryid = 1;
            var result = controller.Create(catDiary) as RedirectToRouteResult;

            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod()]
        public void GetEditTest()
        {
            var setUp = new TestSetUp();
            var catDb = new Mock<DbSet<Catdiary>>();
            catDb.Setup(x => x.Find(1)).Returns(new Catdiary());
            setUp.mockContext.Setup(c => c.Catdiary).Returns(catDb.Object);
            setUp.CatSetUp();
            setUp.DiarySetUp();

            var controller = new CatdiariesController(setUp.mockContext.Object);

            var result = controller.Edit(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void PostEditTest()
        {
            var setUp = new TestSetUp();
            setUp.CatDiarySetUp();

            var controller = new CatdiariesController(setUp.mockContext.Object);

            var catDiary = new Catdiary();
            catDiary.id = 1;
            catDiary.catid = 1;
            catDiary.diaryid = 1;
            var result = controller.Create(catDiary) as RedirectToRouteResult;

            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var setUp = new TestSetUp();
            var catDb = new Mock<DbSet<Catdiary>>();
            catDb.Setup(x => x.Find(1)).Returns(new Catdiary());
            setUp.mockContext.Setup(c => c.Catdiary).Returns(catDb.Object);
            setUp.CatSetUp();
            setUp.DiarySetUp();

            var controller = new CatdiariesController(setUp.mockContext.Object);

            var result = controller.Edit(1) as ViewResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            var setUp = new TestSetUp();
            setUp.CatDiarySetUp();

            var controller = new CatdiariesController(setUp.mockContext.Object);

            var result = controller.DeleteConfirmed(1);
            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
    }
}