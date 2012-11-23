using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DataAccess.Repositories;
using DataAccess.Entities;

namespace TODOList
{
    public partial class TODOList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             /*   AssigneeRepository ar = new AssigneeRepository();
                ddlAssignees.DataSource = ar.GetAllAssignees();
                ddlAssignees.DataBind();*/
                PriorityRepository pr = new PriorityRepository();
                ddlPriorities.DataSource = pr.GetAllPriorities();
                ddlPriorities.DataBind();
                TaskRepository tr = new TaskRepository();
                string page = hfPage.Value;
                string pageSize = hfPageSize.Value;
                string assigneeId = hfAssigneeId.Value;
                string priorityId = hfPriorityId.Value;
                //  string firstDate = hfFirstDate.Value;
                //  string lastDate = hfLastDate.Value;
                rptTasks.DataSource = tr.GetAllTasks(page, pageSize, assigneeId, priorityId); //, firstDate, lastDate);
                rptTasks.DataBind();
            
        }

        protected void ddlAssignees_DataBound(object sender, EventArgs e)
        {
            (sender as DropDownList).Items.Insert(0, new ListItem("(All Assignees)", "-1"));
        }

        protected void ddlPriorities_DataBound(object sender, EventArgs e)
        {
            (sender as DropDownList).Items.Insert(0, new ListItem("(All Priorities)", "-1"));
        }

        protected void ddlAssignees_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfPage.Value = "1";
            hfAssigneeId.Value = ddlAssignees.SelectedValue;
        }

        protected void ddlPriorities_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfPage.Value = "1";
            hfPriorityId.Value = ddlPriorities.SelectedValue;
        }

        protected Assignee GetAssigneeDetails(object id)
        {
            AssigneeRepository ar = new AssigneeRepository();
            var asn = ar.GetAssigneeById(Guid.Parse(id.ToString()));
            return asn;
        }
    }
}