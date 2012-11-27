using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DataAccess.Repositories;

namespace TODOList
{
    public partial class AddTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AssigneeRepository ar = new AssigneeRepository();
                ddlAssignee.DataSource = ar.GetAllAssignees();
                ddlAssignee.DataBind();
                PriorityRepository pr = new PriorityRepository();
                ddlPriority.DataSource = pr.GetAllPriorities();
                ddlPriority.DataBind();
                StateRepository sr = new StateRepository();
                ddlState.DataSource = sr.GetAllStates();
                ddlState.DataBind();
                TagRepository tr = new TagRepository();
                cblTags.DataSource = tr.GetAllTags();
                cblTags.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid) return;
            TaskRepository tr = new TaskRepository();
            tr.AddTask(txtFirstDate.Text, txtLastDate.Text, txtTitle.Text, txtDescription.Text, ddlPriority.SelectedValue,
                       ddlAssignee.SelectedValue, ddlState.SelectedValue);
            
        }

        protected void ddlAssignee_DataBound(object sender, EventArgs e)
        {
            (sender as DropDownList).Items.Insert(0, new ListItem("(Select Assignee)", "0"));
        }
    }
}