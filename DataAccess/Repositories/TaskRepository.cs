using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class TaskRepository
    {

        private static Task CastTask(tTask linqTask)
        {
            return linqTask == null ? null : new Task
            {
                Id = linqTask.TaskId,
                StartDate = linqTask.StartDate,
                FinishDate = linqTask.FinishDate,
                Title = linqTask.Title,
                Description = linqTask.Description,
                PriorityId = linqTask.PriorityId,
                AssigneeId = linqTask.AssigneeId,
                Picture = linqTask.Picture,
                StateId = linqTask.StateId
            };
        }

        public Task GetTaskById(Guid id)
        {
            Task task;
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                var linqTask = dc.tTasks.SingleOrDefault(t => t.TaskId == id);
                task = CastTask(linqTask);                
            }
            return task;
        }

        public List<Task> GetAllTasks(Guid assigneeId, Guid priorityId, DateTime firstDate, DateTime lastDate)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
              /*  List<Task> tasks = dc.tTasks
                    .Where(t => assigneeId != Guid.Empty && t.AssigneeId == assigneeId)
                    .Where(t => priorityId != Guid.Empty && t.PriorityId == priorityId)
                    .Where(t => firstDate != DateTime.MinValue && t.StartDate >= firstDate)
                    .Where(t => lastDate != DateTime.MinValue && t.FinishDate <= lastDate)
                    .Select(t => CastTask(t)).ToList();
                return tasks; */

                var q = dc.tTasks.Where(t => 1 == 1);
                if (assigneeId != Guid.Empty)
                {
                    q = q.Where(t => t.AssigneeId == assigneeId);
                }
                if (priorityId != Guid.Empty)
                {
                    q = q.Where(t => t.PriorityId == priorityId);
                }
                if (firstDate != DateTime.MinValue)
                {
                    q = q.Where(t => t.StartDate >= firstDate);
                }
                if (lastDate != DateTime.MinValue)
                {
                    q = q.Where(t => t.FinishDate <= lastDate);
                }
                var list = q.Select(t => CastTask(t)).ToList();                
                return list; 
            }
        }

        public Guid AddTask(DateTime startDate, DateTime finishDate, string title, string description, Guid priorityId, Guid assigneeId, string picturePath, Guid stateId)
        {
            tTask newTask = new tTask();
            newTask.TaskId = Guid.NewGuid();
            newTask.StartDate = startDate;
            newTask.FinishDate = finishDate;
            newTask.Title = title;
            newTask.Description = description;
            newTask.PriorityId = priorityId;
            newTask.AssigneeId = assigneeId;
            newTask.Picture = picturePath;
            newTask.StateId = stateId;

            using (TodoListDataContext dc = new TodoListDataContext())
            {
                dc.tTasks.InsertOnSubmit(newTask);
                dc.SubmitChanges();
            }

            return newTask.TaskId;
        }

        public void EditTask(Guid taskId, DateTime startDate, DateTime finishDate, string title, string description, Guid priorityId, Guid assigneeId, string picturePath, Guid stateId)
        {
           
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                var editTask = dc.tTasks.SingleOrDefault(t => t.TaskId == taskId);
                //editTask.TaskId = taskId;
                editTask.StartDate = startDate;
                editTask.FinishDate = finishDate;
                editTask.Title = title;
                editTask.Description = description;
                editTask.PriorityId = priorityId;
                editTask.AssigneeId = assigneeId;
                editTask.Picture = picturePath;
                editTask.StateId = stateId;
                
                dc.SubmitChanges(); 
            }
        }

        //Order data

        public List<Task> OrderByStartDate(List<Task> tasksList)
        {
            return tasksList.OrderBy(t => t.StartDate).ToList();
        }

        public List<Task> OrderByFinishDate(List<Task> tasksList)
        {
            return tasksList.OrderBy(t => t.FinishDate).ToList();  
        }

        public List<Task> OrderByTitle(List<Task> tasksList)
        {
            return tasksList.OrderBy(t => t.Title).ToList();
        }

        public List<Task> OrderByDescription(List<Task> tasksList)
        {

            return tasksList.OrderBy(t => t.Description).ToList();

        }

        public List<Task> OrderByAssignee(List<Task> tasksList)
        {
            return tasksList.OrderBy(t => t.AssigneeId).ToList();
        }

        public List<Task> OrderByState(List<Task> tasksList)
        {
            return tasksList.OrderBy(t => t.StateId).ToList();
        }

        public List<Task> OrderByPriority(List<Task> tasksList)
        {
            return tasksList.OrderBy(t => t.PriorityId).ToList();
        }

    }
}
