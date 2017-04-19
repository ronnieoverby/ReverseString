using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using reverseAString.Models;
using MarkdownDeep;

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
        /// Reverse the string and post back
        /// </summary>
        [HttpPost]
        public ActionResult Index(Reverse mReverse)
        {
            string sReverseText = ""; 
            sReverseText = mReverse.sInput.Reverse();

             // Create new markdown instance
            Markdown mark = new Markdown();

            // Run parser
            mark.Transform(sReverseText);
            mReverse.sOutput = sReverseText;
            return View(mReverse);
        }

        [HttpPost]
        public PartialViewResult ReversedText(Reverse mReverse)
        {
            mReverse.sOutput = mReverse.sInput.Reverse();
            return PartialView(mReverse);
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
