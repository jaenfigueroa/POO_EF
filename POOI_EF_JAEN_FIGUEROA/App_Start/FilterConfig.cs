﻿using System.Web;
using System.Web.Mvc;

namespace POOI_EF_JAEN_FIGUEROA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
