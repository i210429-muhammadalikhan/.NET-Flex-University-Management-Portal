<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendanceSheetReport.aspx.cs" Inherits="AttendanceSheetReport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance Sheet Report</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            padding: 20px;
            background-color: #f0f0f0;
        }
        .report-table {
            width: 100%;
            border-collapse: collapse;
        }
        .report-table th, .report-table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }
        .report-table th {
            background-color: #007BFF;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Attendance Sheet Report</h2>
            <asp:GridView ID="GridView1" CssClass="report-table" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="RollNo" HeaderText="Registration Number" />
                    <asp:BoundField DataField="Fname" HeaderText="First Name" />
                    <asp:BoundField DataField="Lname" HeaderText="Last Name" />
                    <asp:BoundField DataField="AttendanceDate" HeaderText="Date" />
                    <asp:BoundField DataField="Status" HeaderText="Attendance Status" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
