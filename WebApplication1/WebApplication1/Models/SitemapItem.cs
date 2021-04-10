using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.helper;

namespace WebApplication1.Models
{
    public class SitemapItem : ISitemapItem
    {
        public SitemapItem(string url, DateTime? lastModified = null, SitemapChangeFrequency? changeFrequency = null, double? priority = null)
        {
            // Ensure.Argument.NotNullOrEmpty(url, "url");
            Url = url;
            LastModified = lastModified;
            ChangeFrequency = changeFrequency;
            Priority = priority;
        }
        /// <summary>
        /// URL of the page.
        /// </summary>
        public string Url { get; protected set; }
        /// <summary>
        /// The date of last modification of the file.
        /// </summary>
        public DateTime? LastModified { get; protected set; }
        /// <summary>
        /// How frequently the page is likely to change.
        /// </summary>
        public SitemapChangeFrequency? ChangeFrequency { get; protected set; }
        /// <summary>
        /// The priority of this URL relative to other URLs on your site. Valid values range from 0.0 to 1.0.
 /// </summary>
    public double? Priority { get; protected set; }
    }

}
