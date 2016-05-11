using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace way2_ta02.Models.Enum
{
    public enum SearchType
    {
        [Description("Repositórios de @{0}")]
        User,

        [Description("Repositórios do Github")]
        Github,

        [Description("Repositórios Favoritos")]
        Favorite,
    }
}