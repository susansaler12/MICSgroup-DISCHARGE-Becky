<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="discharge.aspx.cs" Inherits="MICSgroup.dispatch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
</head>
<body>    
    <form id="form1" runat="server">
    <div>
    
        <table class="tblSystem">
            <tr>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPatientId" Display="Dynamic" ErrorMessage="Please enter Patient ID" SetFocusOnError="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPatientId" Display="Dynamic" ErrorMessage="Please enter Patient ID number" SetFocusOnError="True" Type="Integer" MaximumValue="99999" MinimumValue="1" ForeColor="Red">*</asp:RangeValidator>
                    &nbsp;Patient Id:</td>
                <td>
                    <asp:TextBox ID="txtPatientId" runat="server"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnLoad" runat="server" OnClick="btnLoad_Click" Text="Load" CssClass="btn" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">First Name:</td>
                <td>
                    <asp:TextBox ID="txtPatientFirstName" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Last Name:</td>
                <td>
                    <asp:TextBox ID="txtPatientLastName" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Gender:</td>
                <td>
                    <asp:TextBox ID="txtPatientGender" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Birthday:</td>
                <td>
                    <asp:TextBox ID="txtPatientBirthday" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Age:</td>
                <td>
                    <asp:TextBox ID="txtPatientAge" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Doctor Name:</td>
                <td>
                    <asp:TextBox ID="txtPatientDoctorName" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Admit Date:</td>
                <td>
                    <asp:TextBox ID="txtPatientAdmitDate" runat="server" TextMode="Date" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Admit Time:</td>
                <td>
                    <asp:TextBox ID="txtPatientAdmitTime" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;Discharge Date:</td>
                <td>
                    <asp:TextBox ID="txtPatientDischargeDate" runat="server" TextMode="Date" Enabled="False" Font-Bold="True"></asp:TextBox>
                    <asp:ImageButton ID="ImgBtnCalendar" runat="server" CssClass="ImgBtnCalendar" ImageUrl="~/images/calendar-icon.png" OnClick="ImgBtnCalendar_Click" Visible="False" />
                    <asp:Calendar ID="tblCalendar" runat="server" OnSelectionChanged="CalDischarge_SelectionChanged" Visible="False" CssClass="datepicker"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Discharge Time:</td>
                <td>
                    <asp:TextBox ID="txtPatientDischargeTime" runat="server" Enabled="False" Font-Bold="True"></asp:TextBox>
<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" CssClass="btn" Visible="False" />
                    <asp:Button ID="btnConfirm" runat="server" CssClass="btn" OnClick="btnConfirm_Click" Text="Confirm Discharge" Visible="False" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
