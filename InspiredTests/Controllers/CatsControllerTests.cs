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
    public class CatsControllerTests
    {
        [TestMethod()]
        public void IndexCatsTest()
        {
            var controller = new CatsController();
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCreateTest()
        {
            var controller = new CatsController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
            ReferenceEquals(result, new ViewResult());
        
        }

        [TestMethod()]
        public void PostCreateTest()
        {
            var controller = new CatsController();
            
            Assert.Fail();
        }

        [TestMethod()]
        public void DetailsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDeleteTest()
        {
            var controller = new CatsController();
            var result = controller.Delete() as ViewResult
            Assert.IsNotNull(result);
            ReferenceEquals(result, new ViewResult());
        }

        [TestMethod()]
        public void DeleteCatTest()
        {
            Assert.Fail();
        }
    }
}