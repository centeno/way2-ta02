using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using way2_ta02.Helper;
using way2_ta02.Models.Enum;
using System.Collections;
using System.Web.Mvc;
using System.Linq;

namespace way2_ta02.Tests.Helper
{
    [TestClass]
    public class SearchTypesHelperTest
    {
        [TestMethod]
        public void Helper_AllSearchTypes_ReturnSelectListWithLength3()
        {
            Assert.AreEqual(3, (SearchTypesHelper.getSearchTypes("centeno") as SelectList).Count());
        }

        [TestMethod]
        public void Helper_AllTypeUser_ReturnCorrectDescription()
        {
            Assert.AreEqual("Repositórios de @{0}", SearchTypesHelper.getDescription(SearchType.User));
            Assert.AreEqual("Repositórios do Github", SearchTypesHelper.getDescription(SearchType.Github));
            Assert.AreEqual("Repositórios Favoritos", SearchTypesHelper.getDescription(SearchType.Favorite));
        }
    }
}
