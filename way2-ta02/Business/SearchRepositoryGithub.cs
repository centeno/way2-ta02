using System;
using System.Collections.Generic;
using way2_ta02.Business.Strategy;
using way2_ta02.Models;

namespace way2_ta02.Business
{
    public class SearchRepositoryGithub : SearchRepositoryStrategy
    {
        public override IList<Repository> search(String word)
        {
            if (string.IsNullOrEmpty(word))
                throw new Exception("Para pesquisar no Github é necessário informar uma palavra.");

            return searchService.getRepositoriesGitHub(word);
        }

    }
}