using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GradeReport : System.Web.UI.Page
{


    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        string facultyEmail = Session["d1"].ToString();

        string query = @"
            SELECT 
                s.RollNo, s.Fname, s.Lname, sm.Assignment, sm.Quiz, sm.Sessional_I, sm.Sessional_II, sm.Project, sm.Final 
            FROM 
                Student s 
            INNER JOIN 
                StudentSection ss ON s.StudentID = ss.StudentID 
            INNER JOIN 
                StudentMarks sm ON s.StudentID = sm.StudentID 
            INNER JOIN 
                FACULTYSECTION fs ON fs.SectionID = ss.SectionID 
            INNER JOIN 
                Faculty f ON f.FacultyID = fs.FacultyID 
            WHERE 
                f.Email = @FacultyEmail";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FacultyEmail", facultyEmail);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }

    protected string CalculateGrade(int total)
    {
        if (total > 90)
            return "+A";
        else if (total >= 86)
            return "A";
        else if (total >= 82)
            return "-A";
        else if (total >= 78)
            return "+B";
        else if (total >= 74)
            return "B";
        else if (total >= 70)
            return "-B";
        else if (total >= 66)
            return "+C";
        else if (total >= 62)
            return "C";
        else if (total >= 58)
            return "-C";
        else if (total >= 54)
            return "+D";
        else if (total >= 50)
            return "D";
        else
            return "F";
    }
}