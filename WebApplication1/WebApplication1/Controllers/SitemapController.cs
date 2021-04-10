using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.helper;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SitemapController : Controller
    {
        TMDT05Entities db;
        public SitemapController()
        {
            db = new TMDT05Entities();
        }

        // GET: Sitemap
        public ActionResult Index()
        {



            var sitemapItems = new List<SitemapItem>();
            foreach( var item in db.News)
            {

                //sitemapItems.Add(
                //   new SitemapItem(Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port)+"/" + item.Category.Alias + "/" + item.Alias, item.datemodified, (SitemapChangeFrequency)Enum.Parse(typeof(SitemapChangeFrequency), item.changefreq), item.priority )
                //   );
                sitemapItems.Add(
                   new SitemapItem(Url.Action(item.Alias, item.Category.Alias, null, Request.Url.Scheme), item.datemodified, (SitemapChangeFrequency)Enum.Parse(typeof(SitemapChangeFrequency), item.changefreq), item.priority )
                   );


            }
            return new SitemapResult(sitemapItems);
        }
    }
}