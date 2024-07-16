<%@ Page Language="C#" AutoEventWireup="true" CodeFile="evaluate.aspx.cs" Inherits="evaluate" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Marks</title>
    <style>
        /* Add some basic styling here */
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Enter Student Marks</h1>

        <div>
            <label for="studentDropdown">Select Student:</label>
            <asp:DropDownList ID="studentDropdown" runat="server"></asp:DropDownList>
        </div>

        <div>
            <label for="courseDropdown">Select Course:</label>
            <asp:DropDownList ID="courseDropdown" runat="server"></asp:DropDownList>
        </div>

        <div>
            <label for="assignmentMarks">Assignment Marks:</label>
            <asp:TextBox ID="assignmentMarks" runat="server"></asp:TextBox>
        </div>

        <div>
            <label for="quizMarks">Quiz Marks:</label>
            <asp:TextBox ID="quizMarks" runat="server"></asp:TextBox>
        </div>

        <div>
            <label for="sessional_1">Sessional I Marks:</label>
            <asp:TextBox ID="sessional_1" runat="server"></asp:TextBox>
        </div>

        <div>
            <label for="sessional_2">Sessional II Marks:</label>
            <asp:TextBox ID="sessional_2" runat="server"></asp:TextBox>
        </div>

        <div>
            <label for="projectMarks">Project Marks:</label>
            <asp:TextBox ID="projectMarks" runat="server"></asp:TextBox>
        </div>

        <div>
            <label for="finalMarks">Final Marks:</label>
            <asp:TextBox ID="finalMarks" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="submitMarks" Text="Submit Marks" runat="server" OnClick="SubmitMarks_Click" />
        </div>
    </form>
</body>
</html>

