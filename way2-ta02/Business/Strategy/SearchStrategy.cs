using System;
using System.Collections.Generic;
using way2_ta02.Business.Service;
using way2_ta02.Models;
using way2_ta02.Models.Enum;

namespace way2_ta02.Business.Strategy
{
    public abstract class SearchRepositoryStrategy
    {
        protected SearchService searchService;

        public SearchRepositoryStrategy()
        {
            searchService = new SearchService();
        }

        public abstract IList<Repository> search(String word);

    }
}