using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using way2_ta02.Business.Service;
using way2_ta02.Models;
using System.Web.Hosting;
using System.Web;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Moq;
using way2_ta02.Business.Provider;
using System.Collections.Generic;
using System.Linq;

namespace way2_ta02.Tests.Business.Service
{
    [TestClass]
    public class FavoriteServiceTest
    {
        FavoriteService favoriteService;
        SearchService searchService;
        Repository repository;
        IList<Repository> backup;

        [TestInitialize]
        public void Initialize()
        {
            favoriteService = new FavoriteService(new TestDbProvider().Path);
            searchService = new SearchService();
            backup = favoriteService.getAll();
            favoriteService.clear();
            repository = new Repository() { Id = 32425883, Name = "Teste" };
            favoriteService.save(repository);
        }

        [TestCleanup]
        public void Cleanup()
        {
            favoriteService.clear();
            foreach (var r in backup)
                favoriteService.save(r);
        }

        [TestMethod]
        public void BussinesFavoriteService_getAll_ReturnCount1()
        {
            Assert.AreEqual(1, favoriteService.getAll().Count);
        }

        [TestMethod]
        public void BussinesFavoriteService_Delete_ReturnCount0()
        {
            Assert.AreEqual(1, favoriteService.getAll().Count);
            favoriteService.delete(repository.Id);
            Assert.AreEqual(0, favoriteService.getAll().Count);

        }

        [TestMethod]
        public void BussinesSearchService_getAllFavorites_ReturnCount1()
        {
            Assert.AreEqual(1, searchService.getRepositoriesFavorite().Count);
        }

        [TestMethod]
        public void BussinesSearchService_getRepositoryCentenogithubio_ReturnFavoriteTrue()
        {
            Repository repo = searchService.getRepository("centeno", "centeno.github.io") as Repository;
            Assert.IsTrue(repo.Favorite);
        }

         [TestMethod]
        public void BussinesSearchService_getRepositoryCenteno_ReturnFavoriteTrue()
        {
            Repository repo = searchService.getRepositoriesUser("centeno").
                                  Where(r => r.Id == repository.Id).
                                  First<Repository>();
             Assert.IsTrue(repo.Favorite);
         }
    }
}
