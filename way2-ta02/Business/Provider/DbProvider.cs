using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace way2_ta02.Business.Provider
{
    public abstract class DbProvider
    {
        protected String file = "App_Data/db.json";

        public abstract String Path{get;}
    }
}
