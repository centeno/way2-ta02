using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using way2_ta02.Business.Provider;
using way2_ta02.Models;

namespace way2_ta02.Business.Service
{
    public class FavoriteService
    {
        private String path;

        public FavoriteService(String path)
        {
            this.path = path;
        }

        public FavoriteService()
            : this(new ServerDbProvider().Path)
        {
        }

        public IList<Repository> getAll()
        {
            String repos = load();

            if (string.IsNullOrEmpty(repos))
                return new List<Repository>();
            else
                return JsonConvert.DeserializeObject<List<Repository>>(repos); ;
        }

        public void save(Repository repository)
        {
            IList<Repository> repos = getAll();
            repos.Add(repository);
            persist(repos);
        }

        public void delete(int Id)
        {
            IList<Repository> repos = getAll().Where(r => r.Id != Id).Select(r => r).ToList<Repository>();
            persist(repos);
        }

        public void clear() {
            File.WriteAllText(path, "");
        }

        private void persist(IList<Repository> repositories)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(repositories));
        }

        private String load()
        {
            return File.ReadAllText(path);
        }

        
    }
}