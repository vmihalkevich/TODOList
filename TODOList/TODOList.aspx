<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TODOList.aspx.cs" Inherits="TODOList.TODOList" %>

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
     <asp:ObjectDataSource ID="odsAssignee" runat="server" SelectMethod="GetAllAssignees" TypeName="DataAccess.Repositories.AssigneeRepository" DataObjectTypeName="DataAccess.Entities.Assignee">
        </asp:ObjectDataSource>

        <asp:HiddenField ID="hfPage" runat="server" Value="1" />
        <asp:HiddenField ID="hfPageSize" runat="server" Value="5" />
        <asp:HiddenField ID="hfAssigneeId" runat="server" Value="null" />
        <asp:HiddenField ID="hfPriorityId" runat="server" Value="null" />
        <asp:HiddenField ID="hfFirstDate" runat="server" Value="null" />
        <asp:HiddenField ID="hfLastDate" runat="server" Value="null" />

        <div class="navPanel">
            <label for="from">From</label>
            <input type="text" id="txtFirstDate" name="from" />
            <label for="to">to</label>
            <input type="text" id="txtLastDate" name="to" />
            <br /><br />
            <asp:Label ID="lblAssignees" runat="server" Text="Assignee"></asp:Label>
            <asp:DropDownList ID="ddlAssignees" runat="server" DataTextField="Login" DataValueField="AssigneeId"
                OnDataBound="ddlAssignees_DataBound" DataSourceID="odsAssignee"
                OnSelectedIndexChanged="ddlAssignees_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            <br /><br />
            <asp:Label ID="lblPriority" runat="server" Text="Priority"></asp:Label>
            <asp:DropDownList ID="ddlPriorities" runat="server" DataTextField="Text" DataValueField="PriorityId"
                OnDataBound="ddlPriorities_DataBound" 
                onselectedindexchanged="ddlPriorities_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="contentPanel">
            <asp:Repeater ID="rptTasks" runat="server">
                <ItemTemplate>
                    <div class="task">
                        <h2 id="taskTitle">
                            <%# Eval("Title")%>
                        <h2 />
                        <p id="dates">
                            <%# Eval("StartDate")%>&nbsp;&nbsp;
                            <%# Eval("FinishDate")%>
                        </p>
                        <p id="desription">
                            <%# Eval("Description")%>
                        </p>
                        <p id="assignee">
                            <%# Eval("AssigneeId")%>
                        </p>
                        <p id="priority">
                            <%# Eval("PriorityId")%>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </form>
</body>
</html>
