using System;
using System.Collections.Generic;
using way2_ta02.Business.Strategy;
using way2_ta02.Models;

namespace way2_ta02.Business
{
    public class Search
    {
        private SearchRepositoryStrategy strategy;

        public Search(SearchRepositoryStrategy strategy)
        {
            this.strategy = strategy;
        }

        public IList<Repository> search(String word)
        {
            return strategy.search(word);
        }
    }
}
