using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Hosting;
using way2_ta02.Business.Provider;
using way2_ta02.Business.Service;
using way2_ta02.Models;

namespace way2_ta02.Tests.Business.Service
{
    [TestClass]
    public class SearchServiceTest
    {
        SearchService searchService;

        [TestInitialize]
        public void Initialize()
        {
            searchService = new SearchService();
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void BussinesSearchService_getCenteno_ReturnId571016()
        {
            User user = searchService.getUser("centeno") as User;
            Assert.IsNotNull(user);
            Assert.AreEqual(571016, user.Id);
        }

        [TestMethod]
        public void BussinesSearchService_getRepositoriesUserCenteno_ReturnMoreThen0()
        {
            IList<Repository> repos = searchService.getRepositoriesUser("centeno");
            Assert.AreNotEqual(0, repos.Count);
        }

         [TestMethod]
        public void BussinesSearchService_getRepositoriesGithubCentenogithubio_ReturnMoreThen0()
        {
            IList<Repository> repos = searchService.getRepositoriesGitHub("centeno.github.io");
            Assert.AreNotEqual(0, repos.Count);
        }

        [TestMethod]
        public void BussinesSearchService_getRepositoryUserCentenoAndRepositoryCentenogithubio_ReturnNotNull()
        {
            Repository repo = searchService.getRepository("centeno", "centeno.github.io") as Repository;
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void BussinesSearchService_getContribuitorsUserCentenoAndRepositoryCentenogithubio_ReturnMoreThen0()
        {
            Repository repo = searchService.getRepository("centeno", "centeno.github.io") as Repository;
            Initialize();
            IList<User> contribuitors = searchService.getContributors(repo.ContributorsUrl);
            Assert.AreNotEqual(0, contribuitors.Count);
        }

        [TestMethod]
        public void BussinesSearchService_getContribuitorsUserCentenoAndRepositoryChirrinchirrion_Return0()
        {
            Repository repo = searchService.getRepository("centeno", "centeno.github.io") as Repository;
            Initialize();
            string url = repo.ContributorsUrl.Replace("centeno.github.io", "ChirrinChirrion");
            IList<User> contribuitors = searchService.getContributors(url);
            Assert.AreEqual(0, contribuitors.Count);
        }
    }
}
