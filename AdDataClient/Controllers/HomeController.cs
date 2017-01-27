using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AdDataClient.Controllers
{
    public class HomeController : Controller

    {
        private List<AdDataService.Ad> mAds = new List<AdDataService.Ad>();

        public ActionResult Index()
        {
            List<AdDataService.Ad> Ads = new List<AdDataService.Ad>();
            Ads = AdRecords();
            ViewBag.Title = "All Ads";
            ViewBag.Message = "All Ads from 1/1/2011-4/1/2011";
            ViewBag.Ads = Ads;
            return View();
        }

        public ActionResult CoverAds()
        {
            List<AdDataService.Ad> CoverAds = new List<AdDataService.Ad>();
            List<AdDataService.Ad> AllAds = new List<AdDataService.Ad>();
            AllAds = AdRecords();
            foreach (var a in AllAds)
            {
                if (a.Position == "Cover" && a.NumPages >= 0.5m)
                {
                    CoverAds.Add(a); 
                }
            }
            ViewBag.Title = "Cover Ads";
            ViewBag.Message = "Cover Ads, Half Page or Larger"; 
            ViewBag.Ads = CoverAds;
            return View();
        }
        public ActionResult TopAds()
        {
            List<AdDataService.Ad> TopAds = new List<AdDataService.Ad>();
            List<AdDataService.Ad> AllAds = new List<AdDataService.Ad>();
            AllAds = AdRecords();
            IEnumerable<AdDataService.Ad> SortedAds = from a in AllAds orderby a.Brand.BrandName ascending, a.NumPages descending select a;
            string strBrand = "";
            long lCount = 0;
            foreach (var a in SortedAds)
            {
                if (a.Brand.BrandName != strBrand) {
                    strBrand = a.Brand.BrandName;
                    lCount = 0; 
                }
                lCount += 1; 
                if (lCount < 6)
                {
                    TopAds.Add(a); 
                }
            }
            ViewBag.Title = "Top Ads";
            ViewBag.Message = "Top 5 Ads By Brand"; 
            ViewBag.Ads = TopAds;
            return View();
        }
        public ActionResult TopBrands()
        {
            List<AdDataService.Ad> TopBrands = new List<AdDataService.Ad>();
            List<AdDataService.Ad> AllAds = new List<AdDataService.Ad>();
            AllAds = AdRecords();
            IEnumerable<AdDataService.Ad> SortedAds = from a in AllAds orderby a.Brand.BrandName ascending select a;
            string strBrand = "";
            int iBrandId = 0; 
            long lCount = 0;
            decimal dNumPages = 0m; 
            foreach (var b in SortedAds)
            {
                if (b.Brand.BrandName != strBrand)
                {
                    if (lCount != 0)
                    {
                        AdDataService.Ad fNew = new AdDataService.Ad();
                        if (strBrand == null) {
                            strBrand = "No Brand Name";
                            iBrandId = 0; 
                        }
                        AdDataService.Brand bNew = new AdDataService.Brand();
                        bNew.BrandName = strBrand;
                        bNew.BrandId = iBrandId; 
                        fNew.Brand = bNew; 
                        fNew.NumPages = dNumPages;
                        TopBrands.Add(fNew); 
                    }
                    strBrand = b.Brand.BrandName;
                    iBrandId = b.Brand.BrandId; 
                    lCount = 0;
                    dNumPages = 0m;
                }
                lCount += 1;
                dNumPages += b.NumPages; 
            }
            //last one
            if (lCount != 0)
            {
                AdDataService.Ad fNew = new AdDataService.Ad();
                if (strBrand == null)
                {
                    strBrand = "No Brand Name";
                    iBrandId = 0;
                }
                AdDataService.Brand bNew = new AdDataService.Brand();
                bNew.BrandName = strBrand;
                bNew.BrandId = iBrandId;
                fNew.Brand = bNew;
                fNew.NumPages = dNumPages;
                TopBrands.Add(fNew);
            }
            List<AdDataService.Ad> Top5Brands = new List<AdDataService.Ad>();
            Top5Brands = TopBrands.OrderByDescending(foo => foo.NumPages).Take(5).ToList(); 
            ViewBag.Title = "Top Brands";
            ViewBag.Message = "Top 5 Brands By Total Page Coverage";
            ViewBag.Ads = Top5Brands;
            return View();
        }
        

        public List<AdDataService.Ad> AdRecords()
        {
            if (mAds.Count() == 0) {
                AdDataService.AdDataServiceClient client = new AdDataService.AdDataServiceClient();

                DateTime startDate = new DateTime(2011, 01, 01);
                DateTime endDate = new DateTime(2011, 04, 01);
                //List<AdDataService.Ad> Ads = new List<AdDataService.Ad>();
                mAds = client.GetAdDataByDateRange(startDate, endDate).ToList();
            }
            
            return mAds;
        }

    }
}