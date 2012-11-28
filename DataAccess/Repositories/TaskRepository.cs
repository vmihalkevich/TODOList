using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class TaskRepository
    {

        public Task GetTaskById(Guid id)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                //return dc.Tasks.SingleOrDefault(t => t.TaskId == id);
                var task = dc.tTasks.SingleOrDefault(t => t.PriorityId == id);
                if (task != null)
                {
                    return new Task
                    { 
                        Id = task.TaskId, 
                        StartDate = task.StartDate, 
                        FinishDate = task.FinishDate, 
                        Title = task.Title, 
                        Description = task.Description, 
                        PriorityId = task.PriorityId,
                        AssigneeId = task.AssigneeId,
                        Picture = task.Picture,
                        StateId = task.StateId
                    };
                }
                return null;  
            }
        }

        public List<Task> GetAllTasks(Int32 page, Int32 pageSize)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                return dc.tTasks.Select(t => new Task
                {
                    Id = t.TaskId,
                    StartDate = t.StartDate,
                    FinishDate = t.FinishDate,
                    Title = t.Title,
                    Description = t.Description,
                    PriorityId = t.PriorityId,
                    AssigneeId = t.AssigneeId,
                    Picture = t.Picture,
                    StateId = t.StateId
                }).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Task> GetTasksByAssignee(Int32 page, Int32 pageSize, Guid assigneeId)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                return dc.tTasks.Where(t => t.AssigneeId == assigneeId).Select(t => new Task
                {
                    Id = t.TaskId,
                    StartDate = t.StartDate,
                    FinishDate = t.FinishDate,
                    Title = t.Title,
                    Description = t.Description,
                    PriorityId = t.PriorityId,
                    AssigneeId = t.AssigneeId,
                    Picture = t.Picture,
                    StateId = t.StateId
                }).Skip((page - 1) * pageSize).Take(pageSize).ToList();                
            }
        }

        public List<Task> GetTaskByPriority(Int32 page, Int32 pageSize, Guid priorityId)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                return dc.tTasks.Where(t => t.PriorityId == priorityId).Select(t => new Task
                {
                    Id = t.TaskId,
                    StartDate = t.StartDate,
                    FinishDate = t.FinishDate,
                    Title = t.Title,
                    Description = t.Description,
                    PriorityId = t.PriorityId,
                    AssigneeId = t.AssigneeId,
                    Picture = t.Picture,
                    StateId = t.StateId
                }).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Task> GetTaskByState(Int32 page, Int32 pageSize, Guid stateId)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                return dc.tTasks.Where(t => t.StateId == stateId).Select(t => new Task
                {
                    Id = t.TaskId,
                    StartDate = t.StartDate,
                    FinishDate = t.FinishDate,
                    Title = t.Title,
                    Description = t.Description,
                    PriorityId = t.PriorityId,
                    AssigneeId = t.AssigneeId,
                    Picture = t.Picture,
                    StateId = t.StateId
                }).Skip((page - 1) * pageSize).Take(pageSize).ToList(); 
            }
        } 

        public List<Task> GetTasks(Int32 page, Int32 pageSize, Guid assigneeId, Guid priorityId, DateTime firstDate, DateTime lastDate)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
              /*  List<Task> tasks = dc.tTasks
                    .Where(t => assigneeId != Guid.Empty && t.AssigneeId == assigneeId)
                    .Where(t => priorityId != Guid.Empty && t.PriorityId == priorityId)
                    .Where(t => firstDate != DateTime.MinValue && t.StartDate >= firstDate)
                    .Where(t => lastDate != DateTime.MinValue && t.FinishDate <= lastDate)
                    .Select(t => new Task
                    {
                        Id = t.TaskId,
                        StartDate = t.StartDate,
                        FinishDate = t.FinishDate,
                        Title = t.Title,
                        Description = t.Description,
                        PriorityId = t.PriorityId,
                        AssigneeId = t.AssigneeId,
                        Picture = t.Picture,
                        StateId = t.StateId
                    }).ToList();
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
                var list = q.Select(t => new Task
                    {
                        Id = t.TaskId,
                        StartDate = t.StartDate,
                        FinishDate = t.FinishDate,
                        Title = t.Title,
                        Description = t.Description,
                        PriorityId = t.PriorityId,
                        AssigneeId = t.AssigneeId,
                        Picture = t.Picture,
                        StateId = t.StateId
                    }).ToList();
                //var list = q.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return list; 
            }
        }

        public List<Task> GetAllTasks(string Page, string PageSize, string AssigneeId, string PriorityId, string FirstDate, string LastDate)
        {
            Int32 page = 0, pageSize = 0, result;
            Guid assigneeId = Guid.Empty, priorityId = Guid.Empty, result2;
            DateTime firstDate = DateTime.MinValue, lastDate = DateTime.MinValue, result3;
            if (Int32.TryParse(Page, out result))
            {
                page = result;
            }
            if (Int32.TryParse(PageSize, out result))
            {
                pageSize = result;
            }
            if (Guid.TryParse(AssigneeId, out result2))
            {
                assigneeId = result2;
            }
            if (Guid.TryParse(PriorityId, out result2))
            {
                priorityId = result2;
            }
            if (DateTime.TryParse(FirstDate, out result3))
            {
                firstDate = result3;
            }
            if (DateTime.TryParse(LastDate, out result3))
            {
                lastDate = result3;
            }
            List<Task> tasksList = GetTasks(page, pageSize, assigneeId, priorityId, firstDate, lastDate);
            return tasksList;
        }


        public Guid AddTask(string startDate, string finishDate, string title, string description, string priorityId, string assigneeId, string picturePath, string stateId)
        {
            DateTime _startDate = DateTime.Today, _finishDate = DateTime.Today, result1;
            Guid _priorityId = Guid.Empty, _assigneeId = Guid.Empty, _stateId = Guid.Empty, result2;
            if (DateTime.TryParse(startDate, out result1))
            {
                _startDate = result1;
            }
            if (DateTime.TryParse(finishDate, out result1))
            {
                _finishDate = result1;
            }
            if (Guid.TryParse(priorityId, out result2))
            {
                _priorityId = result2;
            }
            if (Guid.TryParse(assigneeId, out result2))
            {
                _assigneeId = result2;
            }
            if (Guid.TryParse(stateId, out result2))
            {
                _stateId = result2;
            }

            tTask newTask = new tTask();
            newTask.TaskId = Guid.NewGuid();
            newTask.StartDate = _startDate;
            newTask.FinishDate = _finishDate;
            newTask.Title = title;
            newTask.Description = description;
            newTask.PriorityId = _priorityId;
            newTask.AssigneeId = _assigneeId;
            newTask.Picture = picturePath;
            newTask.StateId = _stateId;

            using (TodoListDataContext dc = new TodoListDataContext())
            {
                dc.tTasks.InsertOnSubmit(newTask);
                dc.SubmitChanges();
            }

            return newTask.TaskId;
        }

        //Order data

        public List<Task> OrderByStartDate(List<Task> tasksList, bool isAscending)
        {
            if (isAscending)
                return tasksList.OrderBy(t => t.StartDate).ToList();
            else
                return tasksList.OrderByDescending(t => t.StartDate).ToList();
        }

        public List<Task> OrderByFinishDate(List<Task> tasksList, bool isAscending)
        {
            if (isAscending)
                return tasksList.OrderBy(t => t.FinishDate).ToList();
            else
                return tasksList.OrderByDescending(t => t.FinishDate).ToList();
        }

        public List<Task> OrderByTitle(List<Task> tasksList, bool isAscending)
        {
            if (isAscending)
                return tasksList.OrderBy(t => t.Title).ToList();
            else
                return tasksList.OrderByDescending(t => t.Title).ToList();
        }

        public List<Task> OrderByDescription(List<Task> tasksList, bool isAscending)
        {
            if (isAscending)
                return tasksList.OrderBy(t => t.Description).ToList();
            else
                return tasksList.OrderByDescending(t => t.Description).ToList();
        }


    }
}
