using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models
{
    public class Survey
    {
        public string Email { get; set; }
        public string State { get; set; }
        public string SurveyId { get; set; }
        public string ActivityLevel { get; set; }
        public string ParkCode { get; set; }
    }
}