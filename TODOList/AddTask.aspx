<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="TODOList.AddTask" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="Styles/Site.css" rel="Stylesheet" />
    <link type="text/css" href="Styles/jquery-ui-1.9.1.custom.css" rel="Stylesheet" />	
    <script type="text/javascript" src="Scripts/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.9.1.custom.js"></script>
    <script src="Scripts/MyScript.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblFirstDate" runat="server" Text="Дата создания: "></asp:Label>
        <asp:TextBox ID="txtFirstDate" runat="server" EnableViewState="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtFirstDate" Display="Dynamic" ErrorMessage="Укажите дату создания"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="lblLastDate" runat="server" Text="Дата завершения: "></asp:Label>
        <asp:TextBox ID="txtLastDate" runat="server" EnableViewState="False"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtLastDate" Display="Dynamic"
            ControlToCompare="txtFirstDate" Type="Date" Operator="GreaterThanEqual" ErrorMessage="Дата завершения должна быть не меньше даты создания"></asp:CompareValidator>
        <br /><br />
        <asp:Label ID="lblTitle" runat="server" Text="Заголовок: "></asp:Label>
        <asp:TextBox ID="txtTitle" runat="server" EnableViewState="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="Укажите заголовок">
        </asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="lblDescription" runat="server" Text="Описание задания: "></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server" Rows="4" TextMode="MultiLine" 
            Width="253px" EnableViewState="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txtDescription" Display="Dynamic" ErrorMessage="Укажите описание задания">
        </asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="lblAssignee" runat="server" Text="Исполнитель: "></asp:Label>
        <asp:DropDownList ID="ddlAssignee" runat="server" DataTextField="Login" DataValueField="AssigneeId">
        </asp:DropDownList>
        <br /><br />
        <asp:Label ID="lblPriority" runat="server" Text="Приоритет: "></asp:Label>
        <asp:DropDownList ID="ddlPriority" runat="server" DataTextField="Text" DataValueField="PriorityId">
        </asp:DropDownList>
        <br /><br />
        <asp:Label ID="lblState" runat="server" Text="Статус: "></asp:Label>
        <asp:DropDownList ID="ddlState" runat="server" DataTextField="Text" DataValueField="StateId">
        </asp:DropDownList>
        <br /><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
