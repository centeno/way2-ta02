using System;
using System.Collections.Generic;
using way2_ta02.Business.Strategy;
using way2_ta02.Models.Enum;

namespace way2_ta02.Business.Builder
{

    public static class SearchBuilderFactory
    {
        private static List<SearchRepositoryStrategy> searchs = new List<SearchRepositoryStrategy>();

        /*TODO: Implements getStrategy without switch
        public static SearchStrategy getStrategy(SearchType searchType)
        {
            if (searchs.Count == 0)
            {
                searchs = Assembly.GetExecutingAssembly()
                                   .GetTypes()
                                   .Where(type => typeof(SearchStrategy).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                                   .Select(type => Activator.CreateInstance(type))
                                   .Cast<SearchStrategy>()
                                   .ToList();
            }
            return searchs.Where(s => s.Type == searchType).FirstOrDefault();
        }*/

        public static SearchRepositoryStrategy getStrategy(SearchType searchType, String user)
        {
            switch (searchType)
            {
                case SearchType.User:
                default:
                    return new SearchRepositoryUser(user);
                case SearchType.Github:
                    return new SearchRepositoryGithub();
                case SearchType.Favorite:
                    return new SearchRepositoryFavorite();
            }
        }
    }
}