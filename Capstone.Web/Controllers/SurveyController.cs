using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyResult surveyDao;

        public SurveyController(ISurveyResult surveyDao)
        {
            this.surveyDao = surveyDao;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return View(survey);
            }
            try
            {
                surveyDao.AddSurvey(survey);

            }catch(Exception e)
            {

            }
            return RedirectToAction ("FindSurveys", "Survey");
        }

        public IActionResult FindSurveys()
        {
            var newList = surveyDao.GetSurveys();
            return View(newList);
        }

    }
}