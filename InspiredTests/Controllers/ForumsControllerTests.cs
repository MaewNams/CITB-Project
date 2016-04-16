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
    public class ForumsControllerTests
    {
        [TestMethod()]
        public void IndexForumTest()
        {
            var controller = new ForumsController();
            var result = controller.Index() as ViewResult;
            Assert.Fail();
        }
    }
}