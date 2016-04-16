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
        public void IndexBreedsTest() // test ไม่ผ่านเพราะยังไม่ได้ mock
        {
            var controller = new BreedsController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            ReferenceEquals(result, new ViewResult());

        }

        [TestMethod()]
        public void DetailsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCreateTest()
        {
            var controller = new BreedsController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
            ReferenceEquals(result, new ViewResult());
        }

        [TestMethod()]
        public void PostCreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetEditTest() // ต้อง mock 
        {
            var controller = new BreedsController();
            //var result = controller.Edit as ViewResult;
            Assert.IsNotNull(result);
            ReferenceEquals(result, new ViewResult());
        }

        [TestMethod()] // mock 
        public void PostEditTest()
        {
            Assert.Fail();
        }

        [TestMethod()] // mock
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()] //mock 
        public void DeleteConfirmedTest()
        {
            Assert.Fail();
        }
    }
}