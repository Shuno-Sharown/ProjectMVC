using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
namespace WebApplication1.helper
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !value.IsNullOrEmpty();
        }
        public static string ToSlug(this string value, int? maxLength = null)
        {
            // Ensure.Argument.NotNull(value, "value");
            // if it's already a valid slug, return it
            if (RegexUtils.SlugRegex.IsMatch(value))
                return value;
            return GenerateSlug(value, maxLength);
        }
        private static string GenerateSlug(string value, int? maxLength = null)
        {
            // prepare string, remove accents, lower case and convert hyphens to  whitespace
             var result = RemoveAccent(value).Replace("-", " ").ToLowerInvariant();
            
             result = Regex.Replace(result, @"[^a-z0-9\s-]", string.Empty); // remove invalid characters
             result = Regex.Replace(result, @"\s+", " ").Trim(); // convert  multiple spaces into one space
            if (maxLength.HasValue) // cut and trim
                result = result.Substring(0, result.Length <= maxLength ?
               result.Length : maxLength.Value).Trim();
            return Regex.Replace(result, @"\s", "-"); // replace all spaces with  hyphens
 }
        private static string RemoveAccent(string value)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            return Encoding.ASCII.GetString(bytes);
        }
    }


    public static class PathUtils
    {
        /// <summary>
        /// Makes a filename safe for use within a URL
        /// </summary>
        public static string MakeFileNameSafeForUrls(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            var safeFileName = Path.GetFileNameWithoutExtension(fileName).ToSlug();
            return Path.Combine(Path.GetDirectoryName(fileName), safeFileName +
           extension);
        }
        /// <summary>
        /// Combines two URL paths
        /// </summary>
        public static string CombinePaths(string path1, string path2)
        {
            if (path2.IsNullOrEmpty())
            {
                return path1;
            }
            if (path1.IsNullOrEmpty())
                return path2;
            if (path2.StartsWith("http://") || path2.StartsWith("https://"))
                return path2;
            var ch = path1[path1.Length - 1];
            if (ch != '/')
                return (path1.TrimEnd('/') + '/' + path2.TrimStart('/'));
            return (path1 + path2);
        }
    }



}