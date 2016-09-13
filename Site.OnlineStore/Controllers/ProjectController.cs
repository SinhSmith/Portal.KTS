using Portal.Infractructure.Utility;
using Portal.Model.Context;
using Portal.Model.MessageModel;
using Portal.Service.Implements;
using Portal.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Site.OnlineStore.Controllers
{
    public class ProjectController : Controller
    {
        #region Private Properties

        private static int productPerPage = 10;
        private IDisplayProjectService service;

        #endregion

        #region Constructures

        public ProjectController(){
            service = new DisplayProjectService();
        }

        #endregion

        #region Actions

        public ActionResult Index(string searchString = "", int Index = 0)
        {
            GetProjectWithConditionsRequest request = new GetProjectWithConditionsRequest()
            {
                Index = Index,
                NumberOfResultsPerPage = productPerPage,
                ProgressStatus = null,
                ProjectType = null,
                Region = null,
                SearchString = searchString
            };

            GetProjectWithConditionResponse response = service.GetAllProjectMatchingConditions(request);

            return View("DisplayProjects", response);
        }

        public ActionResult GetProjectByType(Define.ProjectType type, string searchString, int Index)
        {
            if (type != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GetProjectWithConditionsRequest request = new GetProjectWithConditionsRequest()
            {
                Index = Index,
                NumberOfResultsPerPage = productPerPage,
                ProgressStatus = null,
                ProjectType = type,
                Region = null,
                SearchString = searchString
            };

            GetProjectWithConditionResponse response = service.GetAllProjectMatchingConditions(request);

            return View("DisplayProjects", response);
        }

        public ActionResult GetProjectByRegion(Define.Region region, string searchString, int Index)
        {
            if (region != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GetProjectWithConditionsRequest request = new GetProjectWithConditionsRequest()
            {
                Index = Index,
                NumberOfResultsPerPage = productPerPage,
                ProgressStatus = null,
                ProjectType = null,
                Region = region,
                SearchString = searchString
            };

            GetProjectWithConditionResponse response = service.GetAllProjectMatchingConditions(request);

            return View("DisplayProjects", response);
        }

        public ActionResult GetProjectByProgressStatus(Define.ProgressStatus progressStatus, string searchString, int Index)
        {
            if (progressStatus != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GetProjectWithConditionsRequest request = new GetProjectWithConditionsRequest()
            {
                Index = Index,
                NumberOfResultsPerPage = productPerPage,
                ProgressStatus = progressStatus,
                ProjectType = null,
                Region = null,
                SearchString = searchString
            };

            GetProjectWithConditionResponse response = service.GetAllProjectMatchingConditions(request);

            return View("DisplayProjects", response);
        }

        public ActionResult ProjectDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            portal_Projects response = service.GetDetailProject(id);

            return View("Details", response);
        }
        
        #endregion
    }
}