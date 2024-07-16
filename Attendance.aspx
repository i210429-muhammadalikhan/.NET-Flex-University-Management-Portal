<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Attendance.aspx.cs" Inherits="Attendance" %>



<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to Faculty</h1>
            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvStudents_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                    <asp:BoundField DataField="Fname" HeaderText="First Name" />
                    <asp:BoundField DataField="Lname" HeaderText="Last Name" />
                    <asp:TemplateField HeaderText="Attendance Status">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlStatus" runat="server">
                                <asp:ListItem>Present</asp:ListItem>
                                <asp:ListItem>Late</asp:ListItem>
                                <asp:ListItem>Absent</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>

