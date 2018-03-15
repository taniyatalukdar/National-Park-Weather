using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPGeek.Web.Models;
using System.Data.SqlClient;


namespace NPGeek.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        const string connectionString = @"Server=.\SQLEXPRESS;Database=NPGeek;Trusted_Connection=True;";

        public bool SaveNewSurvey(Survey surveyForm)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);", conn);
                    cmd.Parameters.AddWithValue("@parkCode", surveyForm.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", surveyForm.Email);
                    cmd.Parameters.AddWithValue("@state", surveyForm.State);
                    cmd.Parameters.AddWithValue("@activityLevel", surveyForm.ActivityLevel);

                    /*int result =*/ cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch(SqlException)
            {
                //Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<SurveyResult> GetAllSurveyResults()
        {
            List<SurveyResult> surveyResults = new List<SurveyResult>();
            try
            {
                using
                    (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select park.parkCode, park.parkName, survey.count from park join (SELECT COUNT(parkCode) as 'count', parkCode from survey_result GROUP BY parkCode) as survey on park.parkCode=survey.parkCode order by survey.count desc;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        SurveyResult surveyResult = new SurveyResult
                        {
                            ParkName = Convert.ToString(reader["parkName"]),
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            Count = Convert.ToInt32(reader["count"])
                        };

                        surveyResults.Add(surveyResult);
                    }
                }
            }
            catch(SqlException)
            {
                throw;
            }
            return surveyResults;
        }

        
    }
}