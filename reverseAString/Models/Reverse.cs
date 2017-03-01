using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace reverseAString.Models
{
    public class Reverse
    {
        [AllowHtml]
        public string sInput { get; set; }

        [AllowHtml]
        public string sOutput { get; set; }
    }
}