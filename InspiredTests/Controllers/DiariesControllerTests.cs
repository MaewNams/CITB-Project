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
    public class DiariesControllerTests
    {
        [TestMethod()] //ต้อง mock
        public void IndexDiariesTest()
        {
            var controller = new DiariesController();
           // var result = controller.Index() as ViewResult;
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void GetCreateTest()
        {
            var controller = new DiariesController();
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void PostCreateTest()
        {
            var controller = new DiariesController();
            Assert.Fail();
        }

        [TestMethod()] ////ต้อง mock
        public void SettingDiaryTest()
        {
            var controller = new DiariesController();
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void AddOwnerTest()
        {
            var controller = new DiariesController();
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void DeleteOwnerTest()
        {
            var controller = new DiariesController();
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void EditDiaryTest()
        {
            var controller = new DiariesController();
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void DeleteDiaryTest()
        {
            var controller = new DiariesController();
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void StatisticDiaryTest()
        {
            var controller = new DiariesController();
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void ChapterDiaryTest()
        {
            var controller = new DiariesController();
            Assert.Fail();
        }
    }
}