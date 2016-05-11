using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using way2_ta02.Business;
using way2_ta02.Business.Builder;
using way2_ta02.Business.Service;
using way2_ta02.Business.Strategy;
using way2_ta02.Helper;
using way2_ta02.Models;
using way2_ta02.Models.Enum;

namespace way2_ta02.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectPermanent("centeno");
        }

        public ActionResult Repositories(String user, String word = "", SearchType searchType = SearchType.User)
        {
            IList<Repository> repos = new List<Repository>();
            try
            {
                ViewBag.Word = word;
                ViewBag.User = Models.User.Load(user);

                ViewBag.FavoriteItens = SearchTypesHelper.getSearchTypes(user, searchType);

                SearchRepositoryStrategy searchStrategy = SearchBuilderFactory.getStrategy(searchType, user);
                Search search = new Search(searchStrategy);
                repos = search.search(word);  
              
                if(repos.Count == 0)
                    ViewBag.Message = "Nenhum repositório encontrado.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View(repos);
        }

        public ActionResult Repository(String user, String repository)
        {
            Repository repo = new SearchService().getRepository(user, repository);
            return View(repo);
        }

        public ActionResult Favorite(String user, String repository)
        {
            Repository repo = new SearchService().getRepository(user, repository);
            new FavoriteService().save(repo);
            return View();
        }

        public ActionResult Unfavorite(int Id)
        {
            new FavoriteService().delete(Id);
            return View();
        }


       
    }
}