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
    public class CatdiariesControllerTests
    {
        [TestMethod()]
        public void IndexCatdiariesTest()
        {
            var controller = new CatdiariesController();
            var result = controller.Index() as ViewResult;

        }

        [TestMethod()]
        public void DetailsTest()
        {
            var controller = new CatdiariesController();
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            var controller = new CatdiariesController();
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            var controller = new CatdiariesController();
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest()
        {
            var controller = new CatdiariesController();
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            var controller = new CatdiariesController();
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var controller = new CatdiariesController();
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            var controller = new CatdiariesController();
            Assert.Fail();
        }
    }
}