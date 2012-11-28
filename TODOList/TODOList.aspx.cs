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

        protected string GetTagsDetails(object id)
        {
            TagRepository tr = new TagRepository();
            var strTags = tr.GetTaskTags(Guid.Parse(id.ToString()));
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

      //      rptTasks.DataSource = list; 
      //     rptTasks.DataBind();

            //Create the object of PagedDataSource
            PagedDataSource objPds = new PagedDataSource();

            //Assign our data source to PagedDataSource object
            objPds.DataSource = list; 

            //Set the allow paging to true
            objPds.AllowPaging = true;

            //Set the number of items you want to show
            objPds.PageSize = Int32.Parse(hfPageSize.Value);

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
            
            // Display the page links
            PagesDisplay.Text = "";
            for (int i = 1; i <= objPds.PageCount; i++)
            {
                if ((NowViewing + 1) != i)
                    PagesDisplay.Text += "<a href=\"javascript:ChangePage("+i+")\">"+i+"</a>  ";
                else
                    PagesDisplay.Text += "[" + i + "]  ";
            }

            rptTasks.DataSource = objPds;
            rptTasks.DataBind(); 

        }

        protected void rptTasks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ViewState["SortExpression"] = e.CommandName;
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

    }
}