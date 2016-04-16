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
    public class AccountsControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var controller = new AccountsController();
            var result = controller.Index();
            Assert.IsNotNull(result);
            ReferenceEquals(result, new ViewResult());
        }

        [TestMethod()]
        public void GetLoginTest()
        {
            var controller = new AccountsController();
            var result = controller.Login();
            Assert.IsNotNull(result);
            ReferenceEquals(result, new ViewResult());
           
        }
         
        [TestMethod()] //ยังเทสไม่ผ่านเพราะยังไม่ได้ mock database
        public void PostLoginTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LogoutTest()
        {
            var controller = new AccountsController();
            var result = controller.Logout() as RedirectToRouteResult;
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod()]
        public void GetRegisterTest()
        {
            var controller = new AccountsController();
            var result = controller.Register();
            Assert.IsNotNull(result);
            ReferenceEquals(result, new ViewResult());

        }

        [TestMethod()] //ยังเทสไม่ผ่านเพราะยังไม่ได้ mock database
        public void PostRegisterTest()
        {
            Assert.Fail();
        }
    }
}