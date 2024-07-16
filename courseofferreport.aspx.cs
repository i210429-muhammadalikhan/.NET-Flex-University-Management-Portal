using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class courseofferreport : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCourses();
        }
    }

    private void BindCourses()
    {
        string query = @"
            SELECT
                c.CourseID,
                c.CourseName,
                c.CreditHours,
                c.MaxEnrollement,
                c.PreReq,
                cs.SemesterID
            FROM
                Course c
            INNER JOIN
                CourseSemester cs ON c.CourseID = cs.CourseID;
        ";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
    }
}