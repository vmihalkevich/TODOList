using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DataAccess.Entities;
using DataAccess.Repositories;

namespace TODOList
{
    public partial class AddEditTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string TaskId = Request.QueryString["Id"];

                AssigneeRepository assigneeRepository = new AssigneeRepository();
                ddlAssignee.DataSource = assigneeRepository.GetAllAssignees();
                ddlAssignee.DataBind();
                PriorityRepository priorityRepository = new PriorityRepository();
                ddlPriority.DataSource = priorityRepository.GetAllPriorities();
                ddlPriority.DataBind();
                StateRepository stateRepository = new StateRepository();
                ddlState.DataSource = stateRepository.GetAllStates();
                ddlState.DataBind();
                TagRepository tagRepository = new TagRepository();
                lstTags.DataSource = tagRepository.GetAllTags();
                lstTags.DataBind();

                if (TaskId != null)
                {
                    Guid taskId = Guid.Empty, taskIdOut;
                    if (Guid.TryParse(TaskId, out taskIdOut))
                    {
                        taskId = taskIdOut;
                    }
                    TaskRepository taskRepository = new TaskRepository();
                    Task editingTask = taskRepository.GetTaskById(taskId);
                    txtFirstDate.Text = editingTask.StartDate.ToShortDateString();
                    txtLastDate.Text = editingTask.FinishDate.Value.ToShortDateString();
                    txtTitle.Text = editingTask.Title;
                    txtDescription.Text = editingTask.Description;
                    ddlAssignee.SelectedValue = editingTask.AssigneeId.ToString();
                    ddlPriority.SelectedValue = editingTask.PriorityId.ToString();
                    ddlState.SelectedValue = editingTask.StateId.ToString();

                    List<Tag> listTags = tagRepository.GetTaskTags(taskId);
                    for (int item = 0; item < lstTags.Items.Count; item++)
                    {
                        foreach (Tag tag in listTags)
                        {
                            Guid tagId = Guid.Empty, tagIdOut;
                            if (Guid.TryParse(lstTags.Items[item].Value, out tagIdOut))
                            {
                                tagId = tagIdOut;
                            }
                            if (tag.Id == tagId)
                            {
                                lstTags.Items[item].Selected = true;
                            }
                        }
                    }
                    imgPicture.ImageUrl = editingTask.Picture;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string TaskId = Request.QueryString["Id"];
            Page.Validate();
            if (!Page.IsValid) return;

            if (ddlAssignee.SelectedIndex == 0)
            {
                pnlMessagePanel.Visible = true;
                lblMessage.Text = "You must choose an Assignee";
                return;
            }

            if (ddlPriority.SelectedIndex == 0)
            {
                pnlMessagePanel.Visible = true;
                lblMessage.Text = "You must choose a Priority";
                return;
            }

            if (ddlState.SelectedIndex == 0)
            {
                pnlMessagePanel.Visible = true;
                lblMessage.Text = "You must choose a State";
                return;
            }

            //Upload image
            string path = Server.MapPath("Images/");
            string picturePath = "";
            if (TaskId != null)
            {
                picturePath = imgPicture.ImageUrl;
            }
            else
            {
                if (fuPicture.HasFile)
                {
                    string ext = Path.GetExtension(fuPicture.FileName);
                    if (ext == ".jpg" || ext == ".png")
                    {
                        fuPicture.SaveAs(path + fuPicture.FileName);
                        picturePath = "~/Images/" + fuPicture.FileName;
                        lblMessage.Text = "Your file has been uploaded";
                    }
                    else
                    {
                        lblMessage.Text = "Your can upload only .jpg and .png files";
                        return;
                    }
                }
                else
                {
                    lblMessage.Text = "Please select an image file";
                    return;
                }
            } 

            TaskRepository taskRepository = new TaskRepository();
            if (TaskId != null)
            {
                DateTime startDate = DateTime.Today, finishDate = DateTime.Today, result1;
                Guid taskId = Guid.Empty, priorityId = Guid.Empty, assigneeId = Guid.Empty, stateId = Guid.Empty, result2;

                if (DateTime.TryParse(txtFirstDate.Text, out result1))
                {
                    startDate = result1;
                }
                if (DateTime.TryParse(txtLastDate.Text, out result1))
                {
                    finishDate = result1;
                }
                if (Guid.TryParse(TaskId, out result2))
                {
                    taskId = result2;
                }
                if (Guid.TryParse(ddlPriority.SelectedValue, out result2))
                {
                    priorityId = result2;
                }
                if (Guid.TryParse(ddlAssignee.SelectedValue, out result2))
                {
                    assigneeId = result2;
                }
                if (Guid.TryParse(ddlState.SelectedValue, out result2))
                {
                    stateId = result2;
                }
                taskRepository.EditTask(taskId, startDate, finishDate, txtTitle.Text, txtDescription.Text, priorityId,
                      assigneeId, picturePath, stateId);

                lblMessage.Text = "Task has been added successfully";
                Response.Redirect("TODOList.aspx");
            }
            else
            {
                DateTime startDate = DateTime.Today, finishDate = DateTime.Today, result1;
                Guid priorityId = Guid.Empty, assigneeId = Guid.Empty, stateId = Guid.Empty, result2;
                if (DateTime.TryParse(txtFirstDate.Text, out result1))
                {
                    startDate = result1;
                }
                if (DateTime.TryParse(txtLastDate.Text, out result1))
                {
                    finishDate = result1;
                }
                if (Guid.TryParse(ddlPriority.SelectedValue, out result2))
                {
                    priorityId = result2;
                }
                if (Guid.TryParse(ddlAssignee.SelectedValue, out result2))
                {
                    assigneeId = result2;
                }
                if (Guid.TryParse(ddlState.SelectedValue, out result2))
                {
                    stateId = result2;
                }

                Guid newTaskId = taskRepository.AddTask(startDate, finishDate, txtTitle.Text, txtDescription.Text, priorityId, assigneeId, picturePath, stateId);

                TagRepository tagRepository = new TagRepository();

                for (int item = 0; item < lstTags.Items.Count; item++)
                {

                    if (lstTags.Items[item].Selected)
                    {
                        Guid tagId = Guid.Empty, result;
                        if (Guid.TryParse(lstTags.Items[item].Value, out result))
                        {
                            tagId = result;
                        }
                        tagRepository.AddTaskTag(newTaskId, tagId);
                    }
                }
                lblMessage.Text = "Task has been edited successfully";
                Response.Redirect("TODOList.aspx");
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TODOList.aspx");
        }

    }
}