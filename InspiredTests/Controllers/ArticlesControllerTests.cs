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
    public class ArticlesControllerTests
    {
        [TestMethod()] //ยังเทสไม่ผ่านเพราะยังไม่ได้ mock database
        public void IndexArticlesTest()
        {
            var controller = new ArticlesController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            ReferenceEquals(result, new ViewResult());
        }

        [TestMethod()]
        public void GetCreateTest()
        {
            var controller = new ArticlesController();
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
        public void DetailsTest()
        {
            Assert.Fail();
        }
    }
}