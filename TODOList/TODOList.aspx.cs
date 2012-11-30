using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DataAccess.Repositories;
//using DataAccess.Entities;

namespace TODOList
{
    public partial class TODOList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AssigneeRepository assigneeRepository = new AssigneeRepository();
                ddlAssignees.DataSource = assigneeRepository.GetAllAssignees();
                ddlAssignees.DataBind();

                PriorityRepository priorityRepository = new PriorityRepository();
                ddlPriorities.DataSource = priorityRepository.GetAllPriorities();
                ddlPriorities.DataBind();
                FillRepeater();
            }            
            
        }

        protected void ddlAssignees_SelectedIndexChanged(object sender, EventArgs e)
        {
            NowViewing = 0;
            hfAssigneeId.Value = ddlAssignees.SelectedValue;
            FillRepeater();
        }

        protected void ddlPriorities_SelectedIndexChanged(object sender, EventArgs e)
        {
            NowViewing = 0;
            hfPriorityId.Value = ddlPriorities.SelectedValue;
            FillRepeater();
        }

        protected string GetAssigneeDetails(object id)
        {
            AssigneeRepository assigneeRepository = new AssigneeRepository();
            Guid Id = Guid.Empty, idOut;
            if (Guid.TryParse(id.ToString(), out idOut))
            {
                Id = idOut;
            }
            var assignee = assigneeRepository.GetAssigneeById(Id);
            return String.Join(" ", assignee.LastName, assignee.FirstName); 
        }

        protected string GetPriorityDetails(object id)
        {
            PriorityRepository priorityRepository = new PriorityRepository();
            Guid Id = Guid.Empty, idOut;
            if (Guid.TryParse(id.ToString(), out idOut))
            {
                Id = idOut;
            }
            var priority = priorityRepository.GetPriorityById(Id);
            return priority.Text;
        }

        protected string GetStateDetails(object id)
        {
            StateRepository stateRepository = new StateRepository();
            Guid Id = Guid.Empty, idOut;
            if (Guid.TryParse(id.ToString(), out idOut))
            {
                Id = idOut;
            }
            var state = stateRepository.GetStateById(Id);
            return state.Text;
        }

        protected string GetTagsDetails(object id)
        {
            TagRepository tagRepository = new TagRepository();
            Guid Id = Guid.Empty, idOut;
            if (Guid.TryParse(id.ToString(), out idOut))
            {
                Id = idOut;
            }
            string strTags = tagRepository.GetTaskTagsToStr(Id);
            if (strTags.Length <= 0)
            {
                strTags = "no tags";
            }
            return strTags;
        }

        protected string ToShortDate(object curDate)
        {
            if (curDate != null)
            {
                return DateTime.Parse(curDate.ToString()).ToShortDateString();
            }
            else
            {
                return null; 
            }            
        }

        public int NowViewing
        {
            get
            {
                object obj = ViewState["_NowViewing"];
                if (obj == null)
                    return 0;
                else
                    return (int)obj;
            }
            set
            {
                this.ViewState["_NowViewing"] = value;
            }
        }

        protected void FillRepeater()
        {
            TaskRepository taskRepository = new TaskRepository();

            Guid assigneeId = Guid.Empty, priorityId = Guid.Empty, result2;
            DateTime firstDate = DateTime.MinValue, lastDate = DateTime.MinValue, result3;
            if (Guid.TryParse(hfAssigneeId.Value, out result2))
            {
                assigneeId = result2;
            }
            if (Guid.TryParse(hfPriorityId.Value, out result2))
            {
                priorityId = result2;
            }
            if (DateTime.TryParse(hfFirstDate.Value, out result3))
            {
                firstDate = result3;
            }
            if (DateTime.TryParse(hfLastDate.Value, out result3))
            {
                lastDate = result3;
            }

            var list = taskRepository.GetAllTasks(assigneeId, priorityId, firstDate, lastDate);

            string sortExpression = (ViewState["SortExpression"] ?? "").ToString();

            switch (sortExpression)
            {
                case "StartDate":
                    list = taskRepository.OrderByStartDate(list);
                    break;
                case "FinishDate":
                    list = taskRepository.OrderByFinishDate(list);                    
                    break;
                case "Title":
                    list = taskRepository.OrderByTitle(list);                    
                    break;
                case "Description":
                    list = taskRepository.OrderByDescription(list);                    
                    break;
                case "Priority":
                    list = taskRepository.OrderByPriority(list);                    
                    break;
                case "Assignee":
                    list = taskRepository.OrderByAssignee(list);                    
                    break;
                case "State":
                    list = taskRepository.OrderByState(list);                    
                    break;
                default:
                    list = taskRepository.OrderByStartDate(list);                    
                    break;
            }

            //Create the object of PagedDataSource
            PagedDataSource objPds = new PagedDataSource();

            //Assign our data source to PagedDataSource object
            objPds.DataSource = list; 

            //Set the allow paging to true
            objPds.AllowPaging = true;

            //Set the number of items to show
            Int32 _pageSize = 0, pageSizeOut;
            if (Int32.TryParse(hfPageSize.Value, out pageSizeOut))
            {
                _pageSize = pageSizeOut;
            }
            objPds.PageSize = _pageSize;

            string navigation = (ViewState["Navigation"] ?? "").ToString();
            switch (navigation)
            {
                case "Next":    
                    NowViewing++;
                    break;
                case "Prev":   
                    NowViewing--;
                    break;
                case "Last":       
                    NowViewing = objPds.PageCount - 1;
                    break;
                default:                    
                    NowViewing = 0;
                    break;
            }

            //Set the current page index
            objPds.CurrentPageIndex = NowViewing;

            //Change the text Now viewing text
            lblCurrentPage.Text = "Now viewing : " + (NowViewing + 1).ToString() + " of " + objPds.PageCount.ToString();

            // Disable Prev, Next, First, Last buttons if necessary
            lbPrev.Enabled = !objPds.IsFirstPage;
            lbNext.Enabled = !objPds.IsLastPage;
            lbFirst.Enabled = !objPds.IsFirstPage;
            lbLast.Enabled = !objPds.IsLastPage;
            
            rptTasks.DataSource = objPds;
            rptTasks.DataBind(); 
        }

        protected void rptTasks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ViewState["SortExpression"] = e.CommandName;
            NowViewing = 0;
            FillRepeater();
        }

        protected void lbPrev_Click(object sender, EventArgs e)
        {
            ViewState["Navigation"] = "Prev";
            FillRepeater();
        }

        protected void lbNext_Click(object sender, EventArgs e)
        {
            ViewState["Navigation"] = "Next";
            FillRepeater();
        }

        protected void lbFirst_Click(object sender, EventArgs e)
        {
            ViewState["Navigation"] = "First";
            FillRepeater();
        }

        protected void lbLast_Click(object sender, EventArgs e)
        {
            ViewState["Navigation"] = "Last";
            FillRepeater();
        }

        protected void EditTask(object sender, CommandEventArgs e)
        {
            Response.Redirect("AddEditTask.aspx?Id=" + e.CommandArgument.ToString());
        }

        protected void AddTask(object sender, CommandEventArgs e)
        {
            Response.Redirect("AddEditTask.aspx");
        }

        protected void txtFirstDate_TextChanged(object sender, EventArgs e)
        {
            NowViewing = 0;
            hfFirstDate.Value = txtFirstDate.Text;
            FillRepeater();
        }

        protected void txtLastDate_TextChanged(object sender, EventArgs e)
        {
            NowViewing = 0;
            hfLastDate.Value = txtLastDate.Text;
            FillRepeater();
        }
    }
}