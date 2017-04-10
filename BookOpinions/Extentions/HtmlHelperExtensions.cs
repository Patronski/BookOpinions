using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookOpinions.Extentions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Button(this HtmlHelper helper, string text)
        {
            TagBuilder builder = new TagBuilder("button");
            builder.AddCssClass("btn btn-success");
            builder.MergeAttribute("type", "submit");
            builder.InnerHtml = text;
            return new MvcHtmlString(builder.ToString());
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string url, string alt)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.AddCssClass("img-thumbnail");
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("alt", alt);

            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}