using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inspired.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Inspired.Controllers.Tests
{
    [TestClass()]
    public class BreedsControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var controller = new BreedsController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var controller = new BreedsController();
            var result = controller.Details(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void GetCreateTest()
        {
            var controller = new BreedsController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void PostCreateTest()
        {
            var controller = new BreedsController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void GetEditTest()
        {
            var controller = new BreedsController();
            var result = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void PostEditTest()
        {
            var controller = new BreedsController();
            var result = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var controller = new BreedsController();
            var result = controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            var controller = new BreedsController();
            var result = controller.DeleteConfirmed(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}