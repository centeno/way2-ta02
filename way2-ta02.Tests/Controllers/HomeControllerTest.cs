using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using way2_ta02;
using way2_ta02.Controllers;
using System.Web.Hosting;
using System.Web;
using System.IO;
using way2_ta02.Models;
using way2_ta02.Models.Enum;

namespace way2_ta02.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        HomeController controller;

        [TestInitialize]
        public void Initialize()
        {
            controller = new HomeController();
        }

        [TestMethod]
        public void Controller_Index_ReturnValidRedirect()
        {
            RedirectResult result = controller.Index() as RedirectResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Controller_RepositoriesCenteno_ReturnValidUser()
        {
            ViewResult result = controller.Repositories("centeno") as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewBag.User, typeof(User));
        }

        [TestMethod]
        public void Controller_RepositoriesNotfound_ReturnMessage()
        {
            ViewResult result = controller.Repositories("centeno", "xpto") as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Nenhum repositório encontrado.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Controller_RepositoriesGithubSearch_ReturnMessage()
        {
            ViewResult result = controller.Repositories("centeno", "", SearchType.Github) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Para pesquisar no Github é necessário informar uma palavra.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Controller_RepositoryCanvasAndUserCenteno_ReturnNotnull()
        {
            ViewResult result = controller.Repository("centeno", "canvas") as ViewResult;
            Assert.IsNotNull(result);
            Repository repo = result.Model as Repository;
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void Controller_Favorite_ReturnValidResult()
        {
            ViewResult result = controller.Favorite("centeno", "canvas") as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Controller_Unfavorite_ReturnValidResult()
        {
            ViewResult result = controller.Unfavorite(23445326) as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
