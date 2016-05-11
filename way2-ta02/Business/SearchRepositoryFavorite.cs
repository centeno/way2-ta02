using System;
using System.Collections.Generic;
using System.Linq;
using way2_ta02.Business.Strategy;
using way2_ta02.Models;

namespace way2_ta02.Business
{
    public class SearchRepositoryFavorite : SearchRepositoryStrategy
    {

        public override IList<Repository> search(String word)
        {
            var search = from s in searchService.getRepositoriesFavorite()
                         where s.Name.ToUpper().Contains(word.ToUpper())
                         select s;

            return search.ToList<Repository>();
        }

    }
}