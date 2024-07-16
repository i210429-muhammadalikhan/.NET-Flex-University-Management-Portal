<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherSection.aspx.cs" Inherits="TeacherSection" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Panel</title>
    <style>
      
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }

        h1, h2 {
            color: #1a237e;
        }

        .form-control {
            display: block;
            width: 70%;
            padding: 8px;
            border: 1px solid #1a237e;
            border-radius: 4px;
            background-color: #ffffff;
            font-size: 14px;
            margin-left: auto;
            margin-right: auto;
        }

        .btn {
            padding: 8px 16px;
            font-size: 14px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            text-align: center;
            text-decoration: none;
        }

        .btn-primary {
            background-color: #1a237e;
            color: #ffffff;
        }

        .btn-primary:hover {
            background-color: #3f51b5;
            color: #ffffff;
        }

        .btn-danger {
            background-color: #b71c1c;
            color: #ffffff;
        }

        .btn-danger:hover {
            background-color: #c62828;
            color: #ffffff;
        }

        .container {
            max-width: 800px;
            margin: 0 auto;
            padding: 16px;
            background-color: #ffffff;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }
      
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <h1>Admin Panel</h1>

        <h2>Search faculty</h2>
        <label for="txtSearch">FacultyID:</label>
        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" />
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
        <br /><br />

        <hr />
        <h2>Faculty Details</h2>
        <label for="lblID">ID:</label>
        <asp:Label ID="lblID" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblName">Name:</label>
       <asp:Label ID="lblName" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblEmail">Email:</label>
        <asp:Label ID="lblEmail" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblCurEdu">Current Education:</label>
        <asp:Label ID="lblCurEdu" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblExperience">Experience:</label>
        <asp:Label ID="lblExperience" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblPosition">Position:</label>
        <asp:Label ID="lblPosition" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblDateOfEmployment">Date of Employment:</label>
        <asp:Label ID="lblDateOfEmployment" runat="server" CssClass="form-control" />
        <br /><br />


        <h2>Add Data</h2>
        <label for="txtID">ID:</label>
        <asp:TextBox ID="Textid1" runat="server" CssClass="form-control" />
        <br />
        <br />

        <label for="txtFname">First Name:</label>
        <asp:TextBox ID="txtFname" runat="server" CssClass="form-control" />
        <br />
        <br />
        <label for="txtLname">Last Name:</label>
        <asp:TextBox ID="txtLname" runat="server" CssClass="form-control" />
        <br />
        <br />
        <label for="txtEmail">Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        <br />
        <br />
        <label for="txtPassword">Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
        <br />
        <br />
        <label for="txtCurEdu">Current Education:</label>
        <asp:TextBox ID="txtCurEdu" runat="server" CssClass="form-control" />
        <br />
        <br />
        <label for="txtExperience">Experience:</label>
        <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control" />
        <br />
        <br />
        <label for="txtPosition">Position:</label>
        <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control" />
        <br />
        <br />
        <label for="txtDateOfEmployment">Date of Employment:</label>
        <asp:TextBox ID="txtDateOfEmployment" runat="server" CssClass="form-control" />
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
        <hr />


        <h2>Delete Data</h2>
         <label for="txtID">ID:</label>
         <asp:TextBox ID="txtID" runat="server" CssClass="form-control" />
         <br /><br />
         <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
        </form>

    </body>
</html>









<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherSection.aspx.cs" Inherits="TeacherSection" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Panel</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            font-size: 14px;
            margin: 0;
            padding: 0;
        }

        h1, h2 {
            color: #333;
        }

        h1 {
            margin: 20px 0;
            text-align: center;
        }

        h2 {
            margin: 10px 0;
        }

        label {
            display: inline-block;
            width: 80px;
            margin-top: 0px;
        }

        input[type="text"],
        input[type="number"] {
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 3px;
            font-size: 14px;
            margin-bottom: 10px;
        }

        button {
            background-color: #4CAF50;
            color: white;
            padding: 8px 16px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

        button:hover {
            background-color: #3e8e41;
        }

        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            text-align: left;
            padding: 8px;
            border-bottom: 1px solid #ddd;
        }

        th {
            background-color: #4CAF50;
            color: white;
        }

        tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .form-control {
    display: inline-block;
    width: calc(100% - 90px);
    box-sizing: border-box;
}

.btn {
    display: inline-block;
    margin-left: 80px;
    margin-top: 10px;
    font-size: 14px;
    transition: all 0.3s ease;
}

.btn-primary {
    background-color: #007bff;
    border-color: #007bff;
    color: #fff;
}

.btn-primary:hover {
    background-color: #0069d9;
    border-color: #0062cc;
}

.btn-danger {
    background-color: #dc3545;
    border-color: #dc3545;
    color: #fff;
}

.btn-danger:hover {
    background-color: #c82333;
    border-color: #bd2130;
}

    </style>
</head>
<body>
    <form id="form2" runat="server">
        <h1>Admin Panel</h1>

        <h2>Search faculty</h2>
        <label for="txtSearch">FacultyID:</label>
        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" />
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
        <br /><br />

        <hr />
        <h2>Faculty Details</h2>
        <label for="lblID">ID:</label>
        <asp:Label ID="lblID" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblName">Name:</label>
        <asp:Label ID="lblName" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblEmail">Email:</label>
        <asp:Label ID="lblEmail" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblCurEdu">Current Education:</label>
        <asp:Label ID="lblCurEdu" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblExperience">Experience:</label>
        <asp:Label ID="lblExperience" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblPosition">Position:</label>
        <asp:Label ID="lblPosition" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="lblDateOfEmployment">Date of Employment:</label>
        <asp:Label ID="lblDateOfEmployment" runat="server" CssClass="form-control" />
        <br /><br />

        
        <hr />
        <h2>Add Data</h2>
        <label for="txtName">Name:</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
        <br /><br />
        <label for="txtAge">Age:</label>
        <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" />
        <br /><br />
    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
    <hr />
    <h2>Delete Data</h2>
    <label for="txtID">ID:</label>
    <asp:TextBox ID="txtID" runat="server" CssClass="form-control" />
    <br /><br />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary" OnClick="btnDelete_Click" />
    </form>

</body>
</html>--%>
