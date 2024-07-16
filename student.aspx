<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student.aspx.cs" Inherits="student" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Information</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
        }
        .container {
            width: 80%;
            margin: auto;
            overflow: hidden;
        }
        h1 {
            color: #444;
            margin: 20px 0;
        }
        .grid-view {
            margin: 20px 0;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0px 0px 10px #ccc;
        }
        .feedback-btn {
            display: block;
            width: 200px;
            height: 45px;
            margin: 20px auto;
            background-color: #3498db;
            text-align: center;
            border-radius: 5px;
            color: white;
            font-weight: bold;
            line-height: 45px;
            letter-spacing: 1px;
            text-decoration: none;
        }
        .feedback-btn:hover {
            background-color: #2980b9;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Welcome to Student Section</h1>
            <div class="grid-view">
                <asp:Label ID="lblStudentInfo" runat="server" Text="Student Information"></asp:Label>
                <asp:GridView ID="gvStudentInfo" runat="server" AutoGenerateColumns="true" />
            </div>
            <div class="grid-view">
                <asp:Label ID="lblStudentMarks" runat="server" Text="Student Marks"></asp:Label>
                <asp:GridView ID="gvStudentMarks" runat="server" AutoGenerateColumns="true" />
            </div>
            <div class="grid-view">
                <asp:Label ID="lblStudentAttendance" runat="server" Text="Student Attendance"></asp:Label>
                <asp:GridView ID="gvStudentAttendance" runat="server" AutoGenerateColumns="true" />
            </div>
            <asp:Button ID="btnFacultyFeedback" runat="server" Text="Faculty Feedback" CssClass="feedback-btn" OnClick="btnFacultyFeedback_Click" />
        </div>
    </form>
</body>
</html>



<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Information</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Student Information</h1>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                    <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                    <asp:BoundField DataField="Fname" HeaderText="First Name" />
                    <asp:BoundField DataField="Lname" HeaderText="Last Name" />
                    <asp:BoundField DataField="DOB" HeaderText="Date of Birth" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Password" HeaderText="Password" />
                    <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" />
                    <asp:BoundField DataField="DateOfAdmission" HeaderText="Date of Admission" />
                    <asp:BoundField DataField="CGPA" HeaderText="CGPA" />
                    <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>--%>


<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student.aspx.cs" Inherits="student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Information</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to Student Section</h1>
            <asp:Label ID="lblStudentInfo" runat="server" Text="Student Information" Font-Bold="true" />
            <asp:Table ID="tblStudentInfo" runat="server">
                <!-- Table rows to display student information will be added dynamically in the code-behind file -->
            </asp:Table>
        </div>
    </form>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student.aspx.cs" Inherits="student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Information</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            height: 121px;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }
        th, td {
            text-align: left;
            padding: 8px;
            border: 1px solid #ddd;
        }
        th {
            background-color: #f2f2f2;
            font-weight: bold;
        }
        tr:nth-child(even) {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to Student Section</h1>
            <table>
                <tr>
                    <th>Student ID</th>
                    <th>Roll No</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Date of Birth</th>
                    <th>Email</th>
                    <th>Phone No</th>
                    <th>Date of Admission</th>
                    <th>CGPA</th>
                    <th>Credit Hours</th>
                    <th>Address</th>
                </tr>
                <%-- Add your server-side code to loop through the student records and display them in the table here 
            </table>
        </div>
    </form>
</body>
</html>--%>



<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student.aspx.cs" Inherits="student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to Student Section</h1>
        </div>
    </form>
</body>
</html>--%>
