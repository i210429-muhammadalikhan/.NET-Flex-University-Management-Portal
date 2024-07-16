//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// Other using directives

public partial class login : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //public void CreateTable()
    //{
    //    SqlConnection con = null;
    //    try
    //    {
    //        // Creating Connection  
    //        con = new SqlConnection("data source=.; database=student; integrated security=SSPI");
    //        // writing sql query  
    //        SqlCommand cm = new SqlCommand("create table student(id int not null, name varchar(100), email varchar(50), join_date date)", con);
    //        // Opening Connection  
    //        con.Open();
    //        // Executing the SQL query  
    //        cm.ExecuteNonQuery();
    //        // Displaying a message  
    //        Console.WriteLine("Table created Successfully");
    //    }
    //    catch (Exception e)
    //    {
    //        Console.WriteLine("OOPs, something went wrong." + e);
    //    }
    //    // Closing the connection  
    //    finally
    //    {
    //        con.Close();
    //    }
    //}



    protected void userRole_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void password_TextChanged(object sender, EventArgs e)
    {

    }

    protected void username_TextChanged(object sender, EventArgs e)
    {

    }
  
    protected void loginButton_Click(object sender, EventArgs e)
    {

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            
            string email = TextBox1.Text;
            string password = TextBox2.Text;

            int selectedUserRole = Convert.ToInt32(userRole.SelectedValue);

            Session["d1"] = email;


            string query = "SELECT Userr.UserID, UserRole.RoleID FROM Userr INNER JOIN UserRole ON Userr.UserID = UserRole.UserID WHERE Email = @Email AND Password = @Password AND RoleID = @RoleID";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@RoleID", selectedUserRole);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int userID = reader.GetInt32(0);
                        int roleID = reader.GetInt32(1);

                        // Store the UserID and RoleID in session variables
                        Session["UserID"] = userID;
                        Session["RoleID"] = roleID;

                        // Redirect to a specific page based on the role
                        switch (roleID)
                        {
                            case 1: // Academic Office
                                Response.Redirect("academicoffice.aspx");
                                break;
                            case 2: // Student
                                Response.Redirect("student.aspx");
                                break;
                            case 3: // Faculty
                                Response.Redirect("Faculty.aspx");
                                break;
                            default:
                              //  Label errorMessage = new Label();
                                //errorMessage.Text = "Invalid role.";
                               // form2.Controls.Add(errorMessage);
                                break;
                        }
                    }
                }
                else
                {
                    // Display an error message if the user is not found or the role does not match.
                    //Label errorMessage = new Label();
                    //errorMessage.Text = "Invalid username, password, or role.";
                    //form2.Controls.Add(errorMessage);
                }
            }
        }
    }


    /*
    //protected void loginButton_Click(object sender, EventArgs e)
    //{

    //    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-O82UBQG\\SQLEXPRESS;Initial Catalog=FLEXNU;Integrated Security=True");
    //    conn.Open();

    //    connection.Open();
    //    string query = "SELECT u.UserID, ur.RoleID FROM Userr u " +
    //                   "JOIN UserRole ur ON u.UserID = ur.UserID " +
    //                   "WHERE u.Email = @username AND u.Password = @password";

    //    using (SqlCommand command = new SqlCommand(query, connection))
    //    {
    //        command.Parameters.AddWithValue("@username", TextBox1.Text);
    //        command.Parameters.AddWithValue("@password", TextBox2.Text);
    //        SqlDataReader reader = command.ExecuteReader();

    //        if (reader.HasRows)
    //        {
    //            while (reader.Read())
    //            {
    //                int roleID = Convert.ToInt32(reader["RoleID"]);
    //                if (roleID == Convert.ToInt32(userRole.SelectedValue))
    //                {
    //                    // User exists and role matches, proceed with login
    //                    Session["UserID"] = reader["UserID"].ToString();
    //                    Session["RoleID"] = roleID.ToString();

    //                    // Redirect to the appropriate page based on the role
    //                    if (roleID == 1)
    //                    {
    //                        Response.Redirect("AcademicOffice.aspx");
    //                    }
    //                    else if (roleID == 2)
    //                    {
    //                        Response.Redirect("Student.aspx");
    //                    }
    //                    else if (roleID == 3)
    //                    {
    //                        Response.Redirect("Faculty.aspx");
    //                    }
    //                }
    //                else
    //                {
    //                    // Role doesn't match, show error message
    //                    ErrorMessage.Text = "Invalid role selected.";
    //                }
    //            }
    //        }
    //        else
    //        {
    //            // User not found, show error message
    //            ErrorMessage.Text = "Invalid username or password.";
    //        }
    //        reader.Close();
    //    }
    

    //}*/

    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {   

    }
}









//  MessageBox.Show("Connection Open");
//SqlCommand cm;
//string un = TextBox1.Text;
//string pass = TextBox2.Text;
//string query = "SELECT u.UserID, u.Email, u.Password, r.RoleID FROM Userr u INNER JOIN UserRole r ON u.UserID = r.UserID WHERE u.Email = @Email AND u.Password = @Password";
//cm = new SqlCommand(query, conn);

//cm.Parameters.AddWithValue("@Email", un);
//cm.Parameters.AddWithValue("@Password", pass);

//SqlDataReader res = cm.ExecuteReader();





//if (!res.HasRows)
//{
//   // MessageBox.Show("No such username found");
//}
//else
//{
//    res.Read();
//    int roleID = res.GetInt32(3);
//    //MessageBox.Show("Successfully logged in!");

//    // Redirect to the appropriate page based on the user role
//    switch (roleID)
//    {
//        case 1: // Assuming 1 corresponds to the "Student" role
//            Response.Redirect("student.aspx");
//            break;
//        case 2: // Assuming 2 corresponds to the "Faculty" role
//            Response.Redirect("faculty.aspx");
//            break;
//        case 3: // Assuming 3 corresponds to the "Academic Office" role
//            Response.Redirect("academicoffice.aspx");
//            break;
//        default:
//      //      MessageBox.Show("Invalid user role");
//            break;
//    }
//}

//Console.WriteLine("After method call, value of res : {0}", res);
//cm.Dispose();
//conn.Close();
////this.Close();





//string username = TextBox1.Text;
//string password = TextBox2.Text;
//string userRole = "\0";



//SqlConnection con = null;
//try
//{
//    // Creating Connection  
//    con = new SqlConnection("data source=DESKTOP-O82UBQG\\SQLEXPRESS; database=FLEXNU; integrated security=SSPI");
//    // writing sql query  
//    SqlCommand cm = new SqlCommand("Select * from Userr where Email = '" + username+"' AND password ='"+ password+"'", con);
//    // Opening Connection  
//    con.Open();
//    // Executing the SQL query  
//    SqlDataReader sdr = cm.ExecuteReader();
//    // Iterating Data  
//    while (sdr.Read())
//    {
//        // Displaying Record  
//        Console.WriteLine(sdr["UserID"] + " " + sdr["Password"] + " " + sdr["Email"]);
//    }
//}


//catch (Exception )
//{
//    Console.WriteLine("OOPs, something went wrong." + e);
//}
//// Closing the connection  
//finally
//{
//    con.Close();
//}