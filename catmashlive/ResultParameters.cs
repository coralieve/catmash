using eSpares.Levity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;

namespace catmashlive
{
    public class ResultParameters
    {
        public string appId { get; set; }
        public string opponentCatId { get; set; }
        public int outcome { get; set; }

        public ResultParameters()
        {
            Assembly current = ApplicationAssemblyUtility.ApplicationAssembly;
            appId = ((GuidAttribute)current.GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;
        }
    }
}