using System;
using System.Globalization;

namespace PornSearch.Extensions
{
    internal static class StringExtensions
    {
        public static string ToHtmlDecode(this string text) {
            return string.IsNullOrEmpty(text) ? text : HTML5Decode.Utility.HtmlDecode(text).Replace("\u00A0", " ").Trim();
        }

        public static string ToTitleCase(this string text) {
            return string.IsNullOrEmpty(text) ? text : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }

        public static int TransformToInt(this string text) {
            if (string.IsNullOrEmpty(text))
                return 0;
            if (text.EndsWith("k", StringComparison.OrdinalIgnoreCase))
                return (int)(Convert.ToSingle(text.Substring(0, text.Length - 1)) * 1000);
            if (text.EndsWith("m", StringComparison.OrdinalIgnoreCase))
                return (int)(Convert.ToSingle(text.Substring(0, text.Length - 1)) * 1000 * 1000);
            return Convert.ToInt32(text.Replace(",", "").Replace(".", "").Replace(" ", ""));
        }

        public static string RemoveUrlQuery(this string url) {
            if (string.IsNullOrEmpty(url))
                return url;
            int index = url.IndexOf("?", StringComparison.Ordinal);
            return index == -1 ? url : url.Substring(0, index);
        }
    }
}
