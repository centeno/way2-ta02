using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using way2_ta02.Models;
using way2_ta02.Business.Service;
using System.Web;
using System.Web.Hosting;
using System.IO;
using System.Web.SessionState;
using System.Reflection;

namespace way2_ta02.Tests.Models
{
    [TestClass]
    public class ModelsTest
    {
        SearchService searchService;

        [TestInitialize]
        public void Initialize()
        {
            searchService = new SearchService();
            /**/
        }

        [TestMethod]
        public void ModelRepository_getContribuitorsUserCentenoAndRepositoryCentenogithubio_ReturnMoreThen0()
        {
            Repository repo = searchService.getRepository("centeno", "centeno.github.io") as Repository;
            Assert.AreNotEqual(0, repo.Contributors.Count);
        }

        [TestMethod]
        public void ModelUser_getUserWithoutSession_ReturnId571016()
        {
            User user = User.Load("centeno") as User;
            Assert.IsNotNull(user);
            Assert.AreEqual(571016, user.Id);
        }

        [TestMethod]
        public void ModelUser_getUserWithSession_ReturnId571016()
        {
            loadSession();
            User user = User.Load("centeno") as User;
            Assert.IsNotNull(user);
            Assert.AreEqual(571016, user.Id);
        }

        [TestMethod]
        public void ModelUser_ChangeUserWithSession_ReturnId571016()
        {
            loadSession();
            User user = User.Load("centeno") as User;
            Assert.IsNotNull(user);
            User user2 = User.Load("descarte") as User;
            Assert.AreNotEqual(571016, user2.Id);
        }

        private void loadSession()
        {
            SimpleWorkerRequest request = new SimpleWorkerRequest("", "", "", null, new StringWriter());
            HttpContext context = new HttpContext(request);

            var sessionContainer = new HttpSessionStateContainer("id",
                                      new SessionStateItemCollection(),
                                      new HttpStaticObjectsCollection(),
                                      10,
                                      true,
                                      HttpCookieMode.AutoDetect,
                                      SessionStateMode.InProc,
                                      false);
            context.Items["AspSession"] = typeof(HttpSessionState)
                                        .GetConstructor(
                                                            BindingFlags.NonPublic | BindingFlags.Instance,
                                                            null,
                                                            CallingConventions.Standard,
                                                            new[] { typeof(HttpSessionStateContainer) },
                                                            null)
                                        .Invoke(new object[] { sessionContainer });

            HttpContext.Current = context;
        }
    }
}
