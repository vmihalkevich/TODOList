using System;
using System.Collections.Generic;
using System.IO;
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

            //Upload image
            string path = Server.MapPath("Images/");
            string picturePath = "";
            if (fuPicture.HasFile)
            {
                string ext = Path.GetExtension(fuPicture.FileName);
                if (ext == ".jpg" || ext == ".png")
                {
                    fuPicture.SaveAs(path + fuPicture.FileName);
                    
                    picturePath = "~/Images/" + fuPicture.FileName;

                    Response.Write("Your file has been uploaded");
                }
                else
                {
                    Response.Write("Your can upload only .jpg and .png files");
                    return;
                }
            }
            else
            {                
                Response.Write("Please select an file");
                return;
            }

            TaskRepository tr = new TaskRepository();
            Guid newTaskId = tr.AddTask(txtFirstDate.Text, txtLastDate.Text, txtTitle.Text, txtDescription.Text, ddlPriority.SelectedValue,
                       ddlAssignee.SelectedValue, picturePath, ddlState.SelectedValue);

            TagRepository tgr = new TagRepository();
            
            for (int i = 0; i < cblTags.Items.Count; i++)
            {

                if (cblTags.Items[i].Selected)
                {
                    Guid tagId = Guid.Empty, result;
                    if (Guid.TryParse(cblTags.Items[i].Value, out result))
                    {
                        tagId = result;
                    }
                    tgr.AddTaskTag(newTaskId, tagId);                    

                }
            }
             
        }

    }
}