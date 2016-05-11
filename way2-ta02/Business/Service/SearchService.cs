using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using way2_ta02.Models;

namespace way2_ta02.Business.Service
{
    public class SearchService
    {
        private WebClient wc;

        private const String URL_User = "https://api.github.com/users/{0}";
        private const String URL_UserRepositories = "https://api.github.com/users/{0}/repos";
        private const String URL_AllRepositories = "https://api.github.com/search/repositories?q={0}";
        private const String URL_Repository = "https://api.github.com/repos/{0}/{1}";
        private const String URL_Contributors = "https://api.github.com/repos/{0}/{1}/contributors";

        public SearchService()
        {
            wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.UserAgent, "Way2-ta02");
            //string credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("centeno:password"));
            //wc.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
        }

        public User getUser(String user)
        {
            return JsonConvert.DeserializeObject<User>(wc.DownloadString(string.Format(URL_User, user)));
        }

        public IList<Repository> getRepositoriesUser(String user)
        {
            var repos = JsonConvert.DeserializeObject<IList<Repository>>(wc.DownloadString(string.Format(URL_UserRepositories, user)));
            return setFavorite(repos);
        }

        public IList<Repository> getRepositoriesGitHub(String word)
        {
            string query = wc.DownloadString(string.Format(URL_AllRepositories, word));
            string itens = (JsonConvert.DeserializeObject<object>(query) as JContainer).ElementAt(2).Last.ToString();
            IList<Repository> repos = JsonConvert.DeserializeObject<IList<Repository>>(itens);

            return setFavorite(repos);
        }

        public IList<Repository> getRepositoriesFavorite()
        {
            return new FavoriteService().getAll()
                                        .Select(r => { r.Favorite = true; return r; })
                                        .GroupBy(r => r.Id)
                                        .Select(r => r.First())
                                        .ToList<Repository>();
        }

        public Repository getRepository(string user, string repository)
        {
            var repo = JsonConvert.DeserializeObject<Repository>(wc.DownloadString(string.Format(URL_Repository, user, repository)));

            if (getRepositoriesFavorite().Where(r => r.Id == repo.Id).Count() > 0)
                repo.Favorite = true;

            return repo as Repository;
        }

        private IList<Repository> setFavorite(IList<Repository> repos)
        {
            var favorites = getRepositoriesFavorite();

            return repos.Select(r =>
            {
                r.Favorite = (favorites.Where(f => f.Id == r.Id).Count() == 0) ? false : true;
                return r;
            }).ToList<Repository>();

        }

        public IList<User> getContributors(String url)
        {
            try
            {
                string query = wc.DownloadString(url);

                return JsonConvert.DeserializeObject<IList<User>>(query);
            }
            catch (Exception)
            {
                return new List<User>();
            }
        }
    }
}
