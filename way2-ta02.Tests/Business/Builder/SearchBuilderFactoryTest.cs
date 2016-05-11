using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using way2_ta02.Business.Builder;
using way2_ta02.Models.Enum;
using way2_ta02.Business.Strategy;
using way2_ta02.Business;

namespace way2_ta02.Tests.Business.Builder
{
    [TestClass]
    public class SearchBuilderFactoryTest
    {
        [TestMethod]
        public void BussinesBuilderFactory_TypeGithub_ReturnSearchRepositoryGithub()
        {
            SearchRepositoryStrategy strategy = SearchBuilderFactory.getStrategy(SearchType.Github, "centeno") as SearchRepositoryStrategy;
            Assert.IsNotNull(strategy);
            Assert.IsInstanceOfType(strategy, typeof(SearchRepositoryGithub));
        }

        [TestMethod]
        public void BussinesBuilderFactory_TypeFavorite_ReturnSearchRepositoryFavorite()
        {
            SearchRepositoryStrategy strategy = SearchBuilderFactory.getStrategy(SearchType.Favorite, "centeno") as SearchRepositoryStrategy;
            Assert.IsNotNull(strategy);
            Assert.IsInstanceOfType(strategy, typeof(SearchRepositoryFavorite));
        }

        [TestMethod]
        public void BussinesBuilderFactory_TypeUser_ReturnSearchRepositoryUser()
        {
            SearchRepositoryStrategy strategy = SearchBuilderFactory.getStrategy(SearchType.User, "centeno") as SearchRepositoryStrategy;
            Assert.IsNotNull(strategy);
            Assert.IsInstanceOfType(strategy, typeof(SearchRepositoryUser));
        }
    }
}
