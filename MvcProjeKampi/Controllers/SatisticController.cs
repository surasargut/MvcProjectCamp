using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class SatisticController : Controller
    {
        // GET: Satistic

        Context _context = new Context();
        public ActionResult Index()
        {
            var totalCategory = _context.Categories.Count(); // toplam kategori
            ViewBag.totCategory = totalCategory;

            var softwareTitle = _context.Headings.Count(x => x.CategoryID == 24); //yazılım kategorisine ait kaç başlık olduğu
            ViewBag.softwareTitleNumber = softwareTitle;

            var writerFilterA = _context.Writers.Count(x => x.WriterName.Contains("a")); // adında a harfi geçen yazar sayısı
            ViewBag.writerANumber = writerFilterA;


            //en çok başlığı olan kategori
            ViewBag.mostTitleInCategory = _context.Categories.Where(       
                categori => categori.CategoryID == 
                _context.Headings.Max(x => x.Category.CategoryID))
                .First().CategoryName; 

            var statusTrue = _context.Categories.Count(x => x.CategoryStatus == true); // durumu true olan kategoriler
            var statusFalse = _context.Categories.Count(x => x.CategoryStatus == false); // durumu false olan kategoriler

            var statusDifference = Math.Abs(statusTrue - statusFalse); // durumu true olanlarla false olan kategorilerin farkı (mutlak değer içerisinde)
            ViewBag.statDifference = statusDifference;

            return View();
        }
    }
}