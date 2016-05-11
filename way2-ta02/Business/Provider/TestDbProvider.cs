using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace way2_ta02.Business.Provider
{
    public class TestDbProvider : DbProvider
    {
        public override String Path
        {
            get
            {
                return System.IO.Path.GetFullPath(System.IO.Path.Combine("..", "..", "..", "way2-ta02", this.file));
            }
        }
    }
}