using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



public partial class student : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Assuming "d1" session variable contains the student's email
            string studentEmail = Session["d1"].ToString();
            BindStudentInfo(studentEmail);
            BindStudentMarks(studentEmail);
            BindStudentAttendance(studentEmail);
        }
    }

    private void BindStudentInfo(string email)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE Email = @Email", con);
            cmd.Parameters.AddWithValue("@Email", email);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvStudentInfo.DataSource = dt;
            gvStudentInfo.DataBind();
        }
    }

    private void BindStudentMarks(string email)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT SM.* FROM StudentMarks SM INNER JOIN Student S ON SM.StudentID = S.StudentID WHERE S.Email = @Email", con);
            cmd.Parameters.AddWithValue("@Email", email);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvStudentMarks.DataSource = dt;
            gvStudentMarks.DataBind();
        }
    }

    private void BindStudentAttendance(string email)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT SA.AttendanceID, SA.StudentID, SA.Status, SA.AttendanceDate FROM StudentAttendance SA INNER JOIN Student S ON SA.StudentID = S.StudentID WHERE S.Email = @Email", con);
            cmd.Parameters.AddWithValue("@Email", email);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvStudentAttendance.DataSource = dt;
            gvStudentAttendance.DataBind();
        }
    }

    protected void btnFacultyFeedback_Click(object sender, EventArgs e)
    {
        // Redirect to the Faculty Feedback page
        Response.Redirect("StudentFeedbackReport.aspx");
    }


}


//protected void Page_Load(object sender, EventArgs e)
//{
//    string studentID = ""; // Replace with the actual student ID
//    List<string> studentData = FetchStudentData(studentID);

//    if (studentData.Count > 0)
//    {

//        //StudentIDLabel.Text = studentData[0];
//        //RollNolabel.Text = studentData[1];
//        //FirstNameLabel.Text = studentData[2];
//        //LastNameLabel.Text = studentData[3];
//        //DOBlabel.Text = studentData[4];
//        //PhoneNolabel.Text = studentData[5];
//        //DateOfAdmissionlabel.Text = studentData[6];
//        //CGPAlabel.Text = studentData[7];
//        //CreditHourslabel.Text = studentData[8];
//        //Addresslabel.Text = studentData[9];
//    }



//    string x = "";
//    if (!IsPostBack)
//    {
//        if (Session["UserID"] != null)
//        {
//            string StudentName = Session["UserID"].ToString();
//            // Use the data as needed
//            x = StudentName;
//        }
//    }
//   // Label1.Text = x;

//}



////using System.Data.SqlClient;

//public List<string> FetchStudentData(string studentID)
//{
//    List<string> studentData = new List<string>();

//    // Step 1: Create SqlConnection object
//    string connectionString = "Data Source=DESKTOP-NL5RAIC\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";
//    SqlConnection conn = new SqlConnection(connectionString);

//    // Step 2: Define SQL query
//    string query = "SELECT StudentID, RollNo, FName, LName, DOB, PhoneNo, DateOfAdmission, CGPA, CreditHours, Address  FROM Students WHERE StudentID = @StudentID";
//    SqlCommand cmd = new SqlCommand(query, conn);
//    cmd.Parameters.AddWithValue("@StudentID", studentID);

//    // Step 3: Execute query and retrieve data
//    conn.Open();
//    SqlDataReader reader = cmd.ExecuteReader();
//    while (reader.Read())
//    {
//        //studentData.Add(reader.GetString(0)); // Replace with appropriate column name or index
//        //studentData.Add(reader.GetString(1)); // Replace with appropriate column name or index
//        //                                      // Add additional columns as needed


//        string StudentID = reader.GetString(0);
//        string RollNo = reader.GetString(1);
//        string FName = reader.GetString(2);
//        string LName = reader.GetString(3);
//        string DOB = reader.GetString(4);
//        string PhoneNo = reader.GetString(5);
//        string DateOfAdmission = reader.GetString(6);
//        string CGPA = reader.GetString(7);
//        string CreditHours = reader.GetString(8);
//        string Address = reader.GetString(9);
//    }
//    conn.Close();

//    return studentData;
//}

