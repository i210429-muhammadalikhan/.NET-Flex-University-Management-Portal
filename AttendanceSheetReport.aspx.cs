using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AttendanceSheetReport : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            DataTable dtbl = new DataTable();
            string query = @"SELECT s.RollNo, s.Fname, s.Lname, sa.AttendanceDate, sa.Status 
                            FROM Student s 
                            INNER JOIN StudentSection ss ON s.StudentID = ss.StudentID 
                            INNER JOIN FACULTYSECTION fs ON ss.SectionID = fs.SectionID 
                            INNER JOIN Faculty f ON fs.FacultyID = f.FacultyID 
                            INNER JOIN StudentAttendance sa ON s.StudentID = sa.StudentID 
                            WHERE f.Email = @Email";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", Session["d1"]);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtbl);
            }

            if (dtbl.Rows.Count > 0)
            {
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
            }
        }
    }
}