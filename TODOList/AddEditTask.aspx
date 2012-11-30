<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditTask.aspx.cs" Inherits="TODOList.AddEditTask" %>

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
    <form id="form1" runat="server" enableviewstate="True">
    <div>
        <asp:Label ID="lblFirstDate" runat="server" Text="Creation Date: "></asp:Label>
        <asp:TextBox ID="txtFirstDate" runat="server" EnableViewState="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtFirstDate" Display="Dynamic" ErrorMessage="Select Creation date"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="lblLastDate" runat="server" Text="Completion Date: "></asp:Label>
        <asp:TextBox ID="txtLastDate" runat="server" EnableViewState="False"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtLastDate"
            Display="Dynamic" ControlToCompare="txtFirstDate" Type="Date" Operator="GreaterThanEqual"
            ErrorMessage="Completion date shall not be less than the creation date"></asp:CompareValidator>
        <br /><br />
        <asp:Label ID="lblTitle" runat="server" Text="Title: "></asp:Label>
        <asp:TextBox ID="txtTitle" runat="server" EnableViewState="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="Select Title">
        </asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server" Rows="4" TextMode="MultiLine" 
            Width="253px" EnableViewState="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txtDescription" Display="Dynamic" ErrorMessage="Select Description">
        </asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="lblAssignee" runat="server" Text="Assignee: "></asp:Label>
        <asp:DropDownList ID="ddlAssignee" runat="server" DataTextField="Login" DataValueField="Id"
            AppendDataBoundItems="True">
            <Items>
                <asp:ListItem Text="(Choose an Assignee)"></asp:ListItem>
            </Items>
        </asp:DropDownList>
        <br /><br />
        <asp:Label ID="lblPriority" runat="server" Text="Priority: "></asp:Label>
        <asp:DropDownList ID="ddlPriority" runat="server" DataTextField="Text" DataValueField="Id"
            AppendDataBoundItems="True">
            <Items>
                <asp:ListItem Text="(Choose a Priority)"></asp:ListItem>
            </Items>
        </asp:DropDownList>
        <br /><br />
        <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
        <asp:DropDownList ID="ddlState" runat="server" DataTextField="Text" DataValueField="Id"
            AppendDataBoundItems="True">
            <Items>
                <asp:ListItem Text="(Choose a State)"></asp:ListItem>
            </Items>
        </asp:DropDownList>
        <br /><br />
        <asp:Label ID="lblTags" runat="server" Text="Tags: "></asp:Label>
        <asp:CheckBoxList ID="lstTags" runat="server" DataTextField="Text" 
            DataValueField="Id" RepeatColumns="2" RepeatDirection="Vertical">
        </asp:CheckBoxList>
        <br /><br />
        <asp:Label ID="lblPicture" runat="server" Text="Picture: "></asp:Label>
        <asp:FileUpload ID="fuPicture" runat="server" Width="315px" />
        <br />
        <asp:Image ID="imgPicture" runat="server" width="100px" height="100px"/>
        <asp:Panel ID="pnlMessagePanel" runat="server" ForeColor="Red" Visible="False" 
            BackColor="#FFFF99" Width="300px">
            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        </asp:Panel>
        <br /><br /> 
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" /> 
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            onclick="btnCancel_Click" />
    </div>
    </form>
</body>
</html>
