using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using reverseAString.Models;

namespace reverseAString.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Reverse mReverse = new Reverse { sInput = "", sOutput = "" };
            return View(mReverse);
        }

     
        [HttpPost]
        public ActionResult Index(string sInput, string sOutput)
        {
            Reverse mReverse = new Reverse { sInput = "", sOutput = "" };

            mReverse.sInput = sInput;

            char[] cArray = sInput.ToCharArray();
            Array.Reverse(cArray);

            mReverse.sOutput = new string(cArray);
            return View(mReverse);
        }

        
    }
}