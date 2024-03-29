﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TODOList.aspx.cs" Inherits="TODOList.TODOList" %>

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
        <asp:HiddenField ID="hfPageSize" runat="server" Value="5" />
        <asp:HiddenField ID="hfAssigneeId" runat="server" Value="-1" />
        <asp:HiddenField ID="hfPriorityId" runat="server" Value="null" />
        <asp:HiddenField ID="hfFirstDate" runat="server" Value="null" />
        <asp:HiddenField ID="hfLastDate" runat="server" Value="null" /> 

        <div class="navPanel">
            <asp:Label ID="lblFirstDate" runat="server" Text="Creation Date: "></asp:Label>
            <asp:TextBox ID="txtFirstDate" runat="server" EnableViewState="True" 
                AutoPostBack="True" ontextchanged="txtFirstDate_TextChanged"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblLastDate" runat="server" Text="Completion Date: "></asp:Label>
            <asp:TextBox ID="txtLastDate" runat="server" EnableViewState="True" 
                AutoPostBack="True" ontextchanged="txtLastDate_TextChanged"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtLastDate"
                Display="Dynamic" ControlToCompare="txtFirstDate" Type="Date" Operator="GreaterThanEqual"
                ErrorMessage="Completion date shall not be less than the creation date"></asp:CompareValidator>
            <br /><br />
            <asp:Label ID="lblAssignees" runat="server" Text="Assignee"></asp:Label>
            <asp:DropDownList ID="ddlAssignees" runat="server" DataTextField="Login" DataValueField="Id"                
                    OnSelectedIndexChanged="ddlAssignees_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True">
                <Items>
                    <asp:ListItem Text="(All Assignees)"></asp:ListItem>
                </Items>
            </asp:DropDownList>
            <br /><br />
            <asp:Label ID="lblPriority" runat="server" Text="Priority"></asp:Label>
            <asp:DropDownList ID="ddlPriorities" runat="server" DataTextField="Text" DataValueField="Id"
                AutoPostBack="True" OnSelectedIndexChanged="ddlPriorities_SelectedIndexChanged" AppendDataBoundItems="True">
                <Items>
                    <asp:ListItem Text="(All Priorities)"></asp:ListItem>
                </Items>
            </asp:DropDownList>
            <br /><br />
            <asp:LinkButton ID="lbAddTask" Text="Add new task" runat="server" OnCommand="AddTask"></asp:LinkButton>
        </div>
        <div class="contentPanel">
             <asp:Repeater ID="rptTasks" runat="server" OnItemCommand="rptTasks_ItemCommand">
                 <HeaderTemplate>
                    <div>
                        <asp:LinkButton ID="lbStartDate" Text="Creation Date" runat="server" CommandName="StartDate"></asp:LinkButton>
                        <asp:LinkButton ID="lbFinishDate" Text="Finish Date" runat="server" CommandName="FinishDate"></asp:LinkButton>
                        <asp:LinkButton ID="lbTitle" Text="Title" runat="server" CommandName="Title"></asp:LinkButton>
                        <asp:LinkButton ID="lbDescription" Text="Description" runat="server" CommandName="Description"></asp:LinkButton>
                        <asp:LinkButton ID="lbPriority" Text="Priority" runat="server" CommandName="Priority"></asp:LinkButton>   
                        <asp:LinkButton ID="lbAssignee" Text="Assignee" runat="server" CommandName="Assignee"></asp:LinkButton>
                        <asp:LinkButton ID="lbState" Text="State" runat="server" CommandName="State"></asp:LinkButton> 
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="task">
                        <div>
                            <asp:Image ID="imgPicture" ImageUrl='<%# Eval("Picture")%>' runat="server" width="100px" height="100px" />
                        </div>
                        <h2 id="taskTitle">
                            <%# Eval("Title")%>
                        <h2 />
                        <p id="dates">
                            <%# ToShortDate(Eval("StartDate"))%>&nbsp;&nbsp;
                            <%# ToShortDate(Eval("FinishDate"))%>
                        </p>
                        <p id="desription">
                            <%# Eval("Description")%>
                        </p>
                        <p id="assignee">
                            <%# GetAssigneeDetails(Eval("AssigneeId"))%>
                        </p>
                        <p id="priority">
                            <%# GetPriorityDetails(Eval("PriorityId"))%>
                        </p>
                        <p id="state">
                            <%# GetStateDetails(Eval("StateId"))%>
                        </p>
                        <p id="tags">Tags: 
                            <%# GetTagsDetails(Eval("Id"))%>
                        </p>
                        <br />
                        <asp:LinkButton ID="lbEdit" Text="Edit Task" runat="server" OnCommand="EditTask" CommandArgument='<%#Eval("Id")%>'></asp:LinkButton>                       
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div>
                <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                <br />
                <asp:LinkButton ID="lbFirst" runat="server" Text=" first " OnClick="lbFirst_Click"></asp:LinkButton>
                &nbsp; &nbsp;
                <asp:LinkButton ID="lbPrev" runat="server" Text=" previous " OnClick="lbPrev_Click"></asp:LinkButton>
                &nbsp; &nbsp;
                <asp:label ID="PagesDisplay" runat="server"></asp:label>
                &nbsp; &nbsp;
                <asp:LinkButton ID="lbNext" runat="server" Text=" next " OnClick="lbNext_Click"></asp:LinkButton>
                &nbsp; &nbsp;
                <asp:LinkButton ID="lbLast" runat="server" Text=" last " OnClick="lbLast_Click"></asp:LinkButton>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
