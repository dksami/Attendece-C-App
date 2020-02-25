using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matching_cs
{
    static class Global
    {
        private static int _globalVar = 0;

        public static int userid
        {
            get { return _globalVar; }
            set { _globalVar = value; }
        }
    }
}
