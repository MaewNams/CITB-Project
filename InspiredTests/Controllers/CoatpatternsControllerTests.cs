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
    public class CoatpatternsControllerTests
    {
        [TestMethod()]  //ต้อง mock
        public void IndexCoatpatternsTest()
        {
            var controller = new CoatpatternsController();
            var result = controller.Index() as ViewResult;
        }

        [TestMethod()] //ต้อง mock
        public void DetailsTest()
        {
            var controller = new CoatpatternsController();
         
            Assert.Fail();
        }

        [TestMethod()]//ต้อง mock
        public void GetCreateTest()
        {
            var controller = new CoatpatternsController();
         
            Assert.Fail();
        }

        [TestMethod()]//ต้อง mock
        public void PostCreateTest()
        {
            var controller = new CoatpatternsController();
   
            Assert.Fail();
        }

        [TestMethod()]//ต้อง mock
        public void GetEditTest()
        {
            var controller = new CoatpatternsController();
          
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void PostEditTest()
        {
            var controller = new CoatpatternsController();
     
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void DeleteTest()
        {
            var controller = new CoatpatternsController();
      
            Assert.Fail();
        }

        [TestMethod()] //ต้อง mock
        public void DeleteConfirmedTest()
        {
            var controller = new CoatpatternsController();
           
            Assert.Fail();
        }
    }
}