using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspired.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using InspiredTests;
using System.Web;
using Moq;
using System.Web.Routing;
using Inspired.Models;
using System.Data.Entity;

namespace Inspired.Controllers.Tests
{
    [TestClass()]
    public class CatsControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var setUp = new TestSetUp();
            setUp.CatSetUp();
            var controller = new CatsController(setUp.mockContext.Object);

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest()
        {
            var controller = new CatsController();
            var result = controller.Create();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var setUp = new TestSetUp();
            var catDb = new Mock<DbSet<Cat>>();
            catDb.Setup(x => x.Find(1)).Returns(new Cat());
            setUp.mockContext.Setup(c => c.Cat).Returns(catDb.Object);
            var controller = new CatsController(setUp.mockContext.Object);

            var result = controller.Details(1) as JsonResult;
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void EditTest()
        {
            var controller = new CatsController();
            var result = controller.Edit();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var controller = new CatsController();
            var result = controller.Delete();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void DeleteCatTest()
        {
            var setUp = new TestSetUp();
            setUp.CatSetUp();
            var controller = new CatsController(setUp.mockContext.Object);
            var result = controller.DeleteCat(1) as JsonResult;

            setUp.mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }
    }
}