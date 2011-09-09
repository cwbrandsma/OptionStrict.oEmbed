using System;
using System.Linq;
using System.Web;

namespace OptionStrict.oEmbed
{
    public static class Extensions
    {
        public static oEmbedFormat GetOEmbedFormat(this string format)
        {
            switch (format.ToLower())
            {
                case "xml":
                    return oEmbedFormat.Xml;
                case "json":
                    return oEmbedFormat.Json;
                case "jsonp":
                    return oEmbedFormat.Jsonp;
                default:
                    return oEmbedFormat.Unspecified;
            }
        }

        public static string GetOembedContentType(this oEmbedFormat oEmbedFormat)
        {
            switch (oEmbedFormat)
            {
                case oEmbedFormat.Xml:
                    return "text/xml";
                case oEmbedFormat.Jsonp:
                    return "application/javascript";
                default:
                    return "application/json";
            }
        }

        internal static bool In<T>(this T item, params T[] list)
        {
            return list.Contains(item);
        }

        internal static int? ToInt(this string @string)
        {
            if (String.IsNullOrEmpty(@string))
                return null;

            int result;
            var success = Int32.TryParse(@string, out result);
            return success ? (int?)result : null;
        }

        public static oEmbedRequest GetOEmbedRequest(this Uri uri)
        {
            var apiUrl = uri.AbsoluteUri.Replace(uri.Query, "");
            var queryString = HttpUtility.ParseQueryString(uri.Query);
            string url;
            if (queryString.AllKeys.Length == 0 || String.IsNullOrEmpty((url = queryString["url"])))
                throw new ArgumentException("url argument is required");
            var request = new oEmbedRequest(apiUrl, url);
            request.AddQueryParameters(queryString);
            return request;
        }
    }
}
