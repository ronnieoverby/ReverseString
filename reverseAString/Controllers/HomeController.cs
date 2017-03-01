using System;
using System.Collections.Generic;
using System.Linq;
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


        /// <summary>
        /// This corrects your issue.
        /// You were not letting MVC model binding set the properties on your model.
        /// </summary>
        [HttpPost]
        public ActionResult Index(Reverse mReverse)
        {
            char[] cArray = mReverse.sInput.ToCharArray();
            Array.Reverse(cArray);

            mReverse.sOutput = new string(cArray);
            return View(mReverse);
        }


        [HttpPost]
        public ActionResult The_Right_Way_To_Reverse_A_String(Reverse mReverse)
        {
            // see the extension method "Reverse" at the bottom of this file

            mReverse.sOutput = mReverse.sInput.Reverse();
            return View(mReverse);
        }


        /// <summary>
        /// The original broken implementation. (Not using model binding)
        /// </summary>
        /// <param name="sInput"></param>
        /// <param name="sOutput"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BrokeIndex(string sInput, string sOutput)
        {

            // you are manually binding here. Don't do that.
            // let mvc do it for you.
            Reverse mReverse = new Reverse { sInput = "", sOutput = "" };

            mReverse.sInput = sInput;

            char[] cArray = sInput.ToCharArray();
            Array.Reverse(cArray);

            mReverse.sOutput = new string(cArray);
            return View(mReverse);
        }


    }

    public static class StringExtensions
    {
        /// <summary>
        /// Handles funny characters that are actually made up of multiple System.Chars.
        /// </summary>
        public static string Reverse(this string s) =>
            string.Concat(s.ToTextElements().Reverse());

        public static IEnumerable<string> ToTextElements(this string source)
        {
            var e = System.Globalization.StringInfo.GetTextElementEnumerator(source);
            while (e.MoveNext())
                yield return e.GetTextElement();
        }
    }
}
