using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using way2_ta02.Models.Enum;

namespace way2_ta02.Helper
{
    public class SearchTypesHelper
    {
        public static SelectList getSearchTypes(String user, SearchType searchTypes = SearchType.User)
        {
            var statuses = from SearchType st in Enum.GetValues(typeof(SearchType))
                           select new { ID = st, Name = string.Format(getDescription(st), user) };
           return new SelectList(statuses, "ID", "Name", searchTypes);
        }

        public static string getDescription(Enum Enumeration)
        {
            string Value = Enumeration.ToString();
            Type EnumType = Enumeration.GetType();
            var DescAttribute = (System.ComponentModel.DescriptionAttribute[])EnumType
                .GetField(Value)
                .GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            return DescAttribute[0].Description;
        }
    }
}