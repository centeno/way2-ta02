using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using way2_ta02.Models.Enum;
using way2_ta02.Business;
using way2_ta02.Business.Builder;
using way2_ta02.Business.Strategy;
using way2_ta02.Models;
using System.Collections.Generic;

namespace way2_ta02.Tests.Business
{
    [TestClass]
    public class SearchRepositoryTest
    {
        [TestMethod]
        public void BussinesSearchRepository_getRepositoryUserCentenoAndRepositoryCentenogithubio_ReturnMoreThen0()
        {
            SearchRepositoryStrategy strategy = SearchBuilderFactory.getStrategy(SearchType.User, "centeno") as SearchRepositoryStrategy;
            Search search = new Search(strategy);
            Assert.AreNotEqual(0, search.search("centeno.github.io").Count);
        }

        [TestMethod]
        public void BussinesSearchRepository_getRepositoryFavoriteAndRepositoryNotfound_Return0()
        {
            SearchRepositoryStrategy strategy = SearchBuilderFactory.getStrategy(SearchType.Favorite, "centeno") as SearchRepositoryStrategy;
            Assert.AreEqual(0, strategy.search("fjkdsjfkdsjfkjdksaflasd").Count);
        }

        [TestMethod]
        public void BussinesSearchRepository_getRepositoryGithubAndRepositoryCentenogithubio_ReturnMoreThen0()
        {
            SearchRepositoryStrategy strategy = SearchBuilderFactory.getStrategy(SearchType.Github, "centeno") as SearchRepositoryStrategy;
            Assert.AreNotEqual(0, strategy.search("centeno.github.io").Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BussinesSearchRepository_getRepositoryGithubAndWordNull_ReturnException()
        {
            SearchRepositoryStrategy strategy = SearchBuilderFactory.getStrategy(SearchType.Github, "centeno") as SearchRepositoryStrategy;
            strategy.search("");
        }
    }
}
