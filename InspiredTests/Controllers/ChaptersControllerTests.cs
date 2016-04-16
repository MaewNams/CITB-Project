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
    public class ChaptersControllerTests
    {
        [TestMethod()]
        public void IndexChapterTest()
        {
            var controller = new ChaptersController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            ReferenceEquals(result, new ViewResult());
           
        }

        [TestMethod()] //ต้อง mock
        public void CreateChapterTest()
        {
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void CreateChapterTest1()
        {
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void DeleteChapterTest()
        {
            Assert.Fail();
        }
         
        [TestMethod()] //ต้อง mock
        public void EditChapterTest()
        {
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void EditChapterTest1()
        {
            Assert.Fail();
        }
    }
}