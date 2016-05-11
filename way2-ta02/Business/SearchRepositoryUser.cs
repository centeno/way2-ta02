using System;
using System.Collections.Generic;
using System.Linq;
using way2_ta02.Business.Strategy;
using way2_ta02.Models;

namespace way2_ta02.Business
{
    public class SearchRepositoryUser : SearchRepositoryStrategy
    {
        protected String user;

        public SearchRepositoryUser(String user)
            : base()
        {
            this.user = user;
        }

        public override IList<Repository> search(String word)
        {
            var search = from s in searchService.getRepositoriesUser(user)
                         where s.Name.ToUpper().Contains(word.ToUpper())
                         select s;

            return search.ToList<Repository>();
        }

    }
}