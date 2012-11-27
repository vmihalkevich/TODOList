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
        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);
            ddlAssignees.SelectedIndexChanged += new EventHandler(ddlAssignees_SelectedIndexChanged);
            ddlPriorities.SelectedIndexChanged += new EventHandler(ddlPriorities_SelectedIndexChanged);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AssigneeRepository ar = new AssigneeRepository();
                ddlAssignees.DataSource = ar.GetAllAssignees();
                ddlAssignees.DataBind();

                PriorityRepository pr = new PriorityRepository();
                ddlPriorities.DataSource = pr.GetAllPriorities();
                ddlPriorities.DataBind();
                FillRepeater();
            }            
            
        }

        protected void ddlAssignees_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfPage.Value = "1";
            hfAssigneeId.Value = ddlAssignees.SelectedValue;
            FillRepeater();
        }

        protected void ddlPriorities_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfPage.Value = "1";
            hfPriorityId.Value = ddlPriorities.SelectedValue;
            FillRepeater();
        }

        protected string GetAssigneeDetails(object id)
        {
            AssigneeRepository ar = new AssigneeRepository();
            var asn = ar.GetAssigneeById(Guid.Parse(id.ToString()));
            return asn.LastName + " " + asn.FirstName;
        }

        protected string GetPriorityDetails(object id)
        {
            PriorityRepository pr = new PriorityRepository();
            var prt = pr.GetPriorityById(Guid.Parse(id.ToString()));
            return prt.Text;
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

        protected void FillRepeater()
        {
            TaskRepository tr = new TaskRepository();
            string page = hfPage.Value;
            string pageSize = hfPageSize.Value;
            string assigneeId = hfAssigneeId.Value;
            string priorityId = hfPriorityId.Value;
            string firstDate = hfFirstDate.Value;
            string lastDate = hfLastDate.Value;
            var list = tr.GetAllTasks(page, pageSize, assigneeId, priorityId, firstDate, lastDate);

            string sortExpression = (ViewState["SortExpression"] ?? "").ToString();
            bool isAscending = true;

            if (ViewState["SortDetails"] == null)
            {
                Hashtable hs = new Hashtable();
                hs.Add("StartDate", false);
                ViewState["SortDetails"] = hs;
            }

            Hashtable hsSortDetails = ViewState["SortDetails"] as Hashtable;

            if (sortExpression.Length > 0)
            {
                if (!hsSortDetails.Contains(sortExpression))
                    hsSortDetails.Add(sortExpression, true);
                isAscending = bool.Parse(hsSortDetails[sortExpression].ToString());
                hsSortDetails[sortExpression] = !isAscending;
            } 

            switch (sortExpression)
            {
                case "StartDate":
                    list = tr.OrderByStartDate(list, isAscending);
                    break;
                case "FinishDate":
                    list = tr.OrderByFinishDate(list, isAscending);
                    break;
                case "Title":
                    list = tr.OrderByTitle(list, isAscending);
                    break;
                case "Description":
                    list = tr.OrderByDescription(list, isAscending);
                    break;
                default:
                    list = tr.OrderByStartDate(list, isAscending);
                    break;
            }

            rptTasks.DataSource = list; 
            rptTasks.DataBind();

     /*       //Create the object of PagedDataSource
            PagedDataSource objPds = new PagedDataSource();

            //Assign our data source to PagedDataSource object
            objPds.DataSource = list; 

            //Set the allow paging to true
            objPds.AllowPaging = true;

            //Set the number of items you want to show
            objPds.PageSize = Int32.Parse(hfPageSize.Value);

            //Set the current page index
            //objPds.CurrentPageIndex = NowViewing;
            
           //Assign PagedDataSource to repeater
            rptTasks.DataSource = objPds;
            rptTasks.DataBind(); */

        }

        protected void rptTasks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ViewState["SortExpression"] = e.CommandName;
            FillRepeater();
        }

    }
}