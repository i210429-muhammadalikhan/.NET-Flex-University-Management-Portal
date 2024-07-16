using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Attendance : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    private int _sectionID;
    private int _courseID;
    private int _facultyID;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStudents();
        }
    }

    protected void BindStudents()
    {
        string facultyEmail = Session["d1"].ToString();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            // First, fetch the SectionID, CourseID, and FacultyID for the faculty
            SqlCommand cmdFaculty = new SqlCommand("SELECT fs.SectionID, fs.CourseID, f.FacultyID FROM FACULTYSECTION fs INNER JOIN Faculty f ON fs.FacultyID = f.FacultyID WHERE f.Email = @Email", con);
            cmdFaculty.Parameters.AddWithValue("@Email", facultyEmail);
            SqlDataReader dr = cmdFaculty.ExecuteReader();
            if (dr.Read())
            {
                _sectionID = dr.GetInt32(0);  // Assuming the SectionID is the first column
                _courseID = dr.GetInt32(1);  // Assuming the CourseID is the second column
                _facultyID = dr.GetInt32(2);  // Assuming the FacultyID is the third column
            }
            dr.Close();

            // Then fetch the students
            SqlCommand cmd = new SqlCommand("SELECT s.StudentID, s.Fname, s.Lname FROM Student s INNER JOIN StudentSection ss ON s.StudentID = ss.StudentID INNER JOIN FACULTYSECTION fs ON ss.SectionID = fs.SectionID WHERE fs.FacultyID = (SELECT FacultyID FROM Faculty WHERE Email = @Email)", con);
            cmd.Parameters.AddWithValue("@Email", facultyEmail);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            gvStudents.DataSource = dt;
            gvStudents.DataBind();
            con.Close();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            foreach (GridViewRow row in gvStudents.Rows)
            {
                DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");

                // Assuming that you have the FacultyID stored in a variable _facultyID
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentAttendance (StudentID, SectionID, CourseID, FacultyID, Status, AttendanceDate) VALUES (@StudentID, @SectionID, @CourseID, @FacultyID, @Status, @AttendanceDate)", con);

                cmd.Parameters.AddWithValue("@StudentID", row.Cells[0].Text);
                cmd.Parameters.AddWithValue("@SectionID", _sectionID);
                cmd.Parameters.AddWithValue("@CourseID", _courseID);
                cmd.Parameters.AddWithValue("@FacultyID", _facultyID); // Add this line
                cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@AttendanceDate", DateTime.Now.Date);

                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        Response.Write("<script>alert('Attendance Marked Successfully.');</script>");
    }



    protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByText("Present")); // Default to Present
        }
    }


}


















//    protected void Page_Load(object sender, EventArgs e)
//    {
//        if (!IsPostBack)
//        {
//            LoadCourses();
//        }
//    }

//    protected void LoadCourses()
//    {
//        // Load the courses for the faculty member
//        // TODO: Replace with your connection string
//        using (SqlConnection connection = new SqlConnection(connectionString))
//        {
//            connection.Open();
//            string query = "SELECT Course.CourseID, Course.CourseName FROM Course INNER JOIN FacultyCourse ON Course.CourseID = FacultyCourse.CourseID WHERE FacultyCourse.FacultyID = @FacultyID";
//            SqlCommand command = new SqlCommand(query, connection);
//            command.Parameters.AddWithValue("@FacultyID", GetFacultyID());

//            SqlDataReader reader = command.ExecuteReader();
//            CourseDropDownList.DataSource = reader;
//            CourseDropDownList.DataTextField = "CourseName";
//            CourseDropDownList.DataValueField = "CourseID";
//            CourseDropDownList.DataBind();
//            CourseDropDownList.Items.Insert(0, new ListItem("Select a course", "0"));

//            reader.Close();
//        }
//    }

//    protected int GetFacultyID()
//    {
//        // Retrieve the faculty ID based on the logged-in faculty email (session variable)
//        // TODO: Implement your logic to retrieve the faculty ID based on the session variable
//        string facultyEmail = Session["d1"].ToString();

//        // TODO: Replace with your connection string
//        int facultyID = 0;

//        using (SqlConnection connection = new SqlConnection(connectionString))
//        {
//            connection.Open();
//            string query = "SELECT FacultyID FROM Faculty WHERE Email = @Email";
//            SqlCommand command = new SqlCommand(query, connection);
//            command.Parameters.AddWithValue("@Email", facultyEmail);

//            SqlDataReader reader = command.ExecuteReader();
//            if (reader.Read())
//            {
//                facultyID = Convert.ToInt32(reader["FacultyID"]);
//            }

//            reader.Close();
//        }

//        return facultyID;
//    }

//    protected void CourseDropDownList_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        // Load the students for the selected course
//        int courseID = Convert.ToInt32(CourseDropDownList.SelectedValue);

//        // TODO: Replace with your connection string

//        using (SqlConnection connection = new SqlConnection(connectionString))
//        {
//            connection.Open();
//            string query = "SELECT StudentID, Fname, Lname FROM Student INNER JOIN StudentSection ON Student.StudentID = StudentSection.StudentID WHERE CourseID = @CourseID";
//            SqlCommand command = new SqlCommand(query, connection);
//            command.Parameters.AddWithValue("@CourseID", courseID);

//            SqlDataReader reader = command.ExecuteReader();
//            StudentDropDownList.DataSource = reader;
//            StudentDropDownList.DataTextField = "Fname";
//            StudentDropDownList.DataValueField = "StudentID";
//            StudentDropDownList.DataBind();
//            StudentDropDownList.Items.Insert(0, new ListItem("Select a student", "0"));

//            reader.Close();
//        }
//    }





//protected void SubmitButton_Click(object sender, EventArgs e)
//{
//    int studentID = Convert.ToInt32(StudentDropDownList.SelectedValue);
//    string attendanceStatus = AttendanceStatusDropDownList.SelectedValue;
//    DateTime attendanceDate = Convert.ToDateTime(AttendanceDate.Text);

//    // TODO: Replace with your connection string

//    using (SqlConnection connection = new SqlConnection(connectionString))
//    {
//        connection.Open();
//        string query = "INSERT INTO StudentAttendance (StudentID, AttendanceID, CourseID, Status, AttendanceDate) " +
//                       "VALUES (@StudentID, @AttendanceID, @CourseID, @Status, @AttendanceDate)";
//        SqlCommand command = new SqlCommand(query, connection);
//        command.Parameters.AddWithValue("@StudentID", studentID);
//        command.Parameters.AddWithValue("@AttendanceID", GenerateAttendanceID()); // Generate a unique attendance ID
//        command.Parameters.AddWithValue("@CourseID", Convert.ToInt32(CourseDropDownList.SelectedValue));
//        command.Parameters.AddWithValue("@Status", attendanceStatus);
//        command.Parameters.AddWithValue("@AttendanceDate", attendanceDate);

//        command.ExecuteNonQuery();
//    }

//    // Redirect to a success page or display a success message
//    Response.Redirect("SuccessPage.aspx");
//}


//private int GenerateAttendanceID()
//{
//    // Generate a unique attendance ID based on the current date and time
//    string uniqueId = Guid.NewGuid().ToString(); // Generate a unique identifier

//    // Concatenate the current date and time with the unique identifier
//    string attendanceIdString = DateTime.Now.ToString("yyyyMMddHHmmss") + uniqueId;

//    // Parse the attendance ID string to an integer
//    int attendanceID = int.Parse(attendanceIdString);

//    return attendanceID;
//}