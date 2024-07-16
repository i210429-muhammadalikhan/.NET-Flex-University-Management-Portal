using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class courseallocationreport : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCourseData();
        }
    }

    private void BindCourseData()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(@"SELECT C.CourseID, C.CourseName, CS.SemesterID AS Semester 
                                                         FROM Course C 
                                                         INNER JOIN CourseSemester CS ON C.CourseID = CS.CourseID", connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int courseId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CourseID"));
            Label lblInstructors = (Label)e.Row.FindControl("lblInstructors");
            lblInstructors.Text = GetInstructorsByCourseId(courseId);

            Label lblCoordinator = (Label)e.Row.FindControl("lblCoordinator");
            lblCoordinator.Text = GetCourseCoordinatorByCourseId(courseId);
        }
    }

    private string GetInstructorsByCourseId(int courseId)
    {
        StringBuilder instructors = new StringBuilder();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT F.Fname, F.Lname FROM Faculty F INNER JOIN FacultyCourse FC ON F.FacultyID = FC.FacultyID WHERE FC.CourseID = @CourseID", connection))
            {
                cmd.Parameters.AddWithValue("@CourseID", courseId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    instructors.Append(reader["Fname"].ToString() + " " + reader["Lname"].ToString() + ", ");
                }
                reader.Close();
            }
        }

        return instructors.ToString().TrimEnd(',', ' ');
    }

    private string GetCourseCoordinatorByCourseId(int courseId)
    {
        string coordinator = "";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT F.Fname, F.Lname FROM Faculty F INNER JOIN Course C ON F.FacultyID = C.CoordinatorID WHERE C.CourseID = @CourseID", connection))
            {
                cmd.Parameters.AddWithValue("@CourseID", courseId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    coordinator = reader["Fname"].ToString() + " " + reader["Lname"].ToString();
                }
                reader.Close();
            }
        }

        return coordinator;
    }

}