using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookOpinions.App_Start
{
    public class ViewEnginesConfiguration
    {
        public static void RegisterViewEngines(ViewEngineCollection viewEngineCollection)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}