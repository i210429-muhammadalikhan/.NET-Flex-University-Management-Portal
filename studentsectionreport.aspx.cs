using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class studentsectionreport : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStudentList();
        }
    }

    private void LoadStudentList()
    {

        string specificSectionId = "1"; // Replace with the desired section ID

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Fetch section information
            string sectionQuery = "SELECT SectionID FROM SectionCourse WHERE SectionID = @sectionId";
            SqlCommand sectionCommand = new SqlCommand(sectionQuery, connection);
            sectionCommand.Parameters.AddWithValue("@sectionId", specificSectionId);
            SqlDataReader sectionReader = sectionCommand.ExecuteReader();

            if (sectionReader.Read())
            {
                SectionLabel.Text += sectionReader["SectionID"].ToString();
            }
            sectionReader.Close();

            // Fetch student list
            string query = @"
                    SELECT s.RollNo, s.Fname + ' ' + s.Lname AS Name
                    FROM Student s
                    INNER JOIN StudentSection ss ON s.StudentID = ss.StudentID
                    WHERE ss.SectionID = @sectionId
                    ORDER BY s.RollNo ASC";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@sectionId", specificSectionId);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            StudentListGridView.DataSource = dataTable;
            StudentListGridView.DataBind();
        }
    }
}