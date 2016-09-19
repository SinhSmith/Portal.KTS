using Portal.Service.Implements;
using Portal.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.OnlineStore.Controllers
{
    public class HomeController : BaseController
    {
        #region Properties

        IBannerService _bannerService = new BannerService();
        ICMSNewsService _cmsNewsService = new CMSNewsService();
        IDisplayProjectService _projectService = new DisplayProjectService();

        #endregion

        #region Constructures

        public HomeController()
        {
            _bannerService = new BannerService();
            _cmsNewsService = new CMSNewsService();
            _projectService = new DisplayProjectService();
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            ViewBag.FeaturedProjects = _projectService.GetFeaturedProjects(6).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult _HeaderPartial()
        {
            return PartialView();
        }

        public ActionResult BannerPartial()
        {
            return PartialView(_bannerService.GetBanners1ForHomePage());
        }

        public ActionResult BlogPartial()
        {
            return PartialView(_cmsNewsService.GetCMSNewsForHomePage());
        }

        #endregion

        #region Release resources

        /// <summary>
        /// Dispose database connection
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion
    }
}