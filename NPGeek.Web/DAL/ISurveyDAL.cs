using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;
using NPGeek.Web.DAL;

namespace NPGeek.Web.DAL
{
    public interface ISurveyDAL
    {
        bool SaveNewSurvey(Survey surveyForm);
        List<SurveyResult> GetAllSurveyResults();
    }
}