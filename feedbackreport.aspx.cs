using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class feedbackreport : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string facultyEmail = Session["d1"].ToString();
            BindFeedbackReport(facultyEmail);
        }
    }

    private void BindFeedbackReport(string facultyEmail)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sqlQuery = @"
            SELECT FF.FeedbackID, FF.StudentID, FF.RollNo, FF.CourseName, FF.FeedbackText,
                FF.TeacherArrivesOnTime, FF.TeachersPace, FF.TeacherEngagement, FF.TeacherDedication,
                FF.TeacherRespect, FF.TeacherAssignments, FF.TeacherRules, FF.TeacherResponsiveness
            FROM FacultyFeedback FF
            INNER JOIN Faculty F ON FF.FacultyID = F.FacultyID
            WHERE F.Email = @FacultyEmail";

            using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
            {
                cmd.Parameters.AddWithValue("@FacultyEmail", facultyEmail);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    gvFeedbackReport.DataSource = dt;
                    gvFeedbackReport.DataBind();
                }
            }
        }
    }

}