using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace way2_ta02.Business.Provider
{
    public class ServerDbProvider : DbProvider
    {
        public override String Path
        {
            get
            {
                string fullPath = "";
                try
                {
                    fullPath = HttpContext.Current.Server.MapPath("~/" + this.file);
                }
                catch (Exception)
                {
                    fullPath = new TestDbProvider().Path;
                }

                return fullPath;
            }
        }
    }
}