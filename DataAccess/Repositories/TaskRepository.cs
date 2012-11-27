using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class TaskRepository
    {
    /*    public List<Task> GetAllTasks()
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.Tasks.ToList();
            }
        }*/

        public Task GetTaskById(Guid id)
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.Tasks.SingleOrDefault(t => t.TaskId == id);
            }
        }

        public List<Task> GetAllTasks(Int32 page, Int32 pageSize)
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.Tasks.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Task> GetTasksByAssignee(Int32 page, Int32 pageSize, Guid assigneeId)
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.Tasks.Where(t => t.AssigneeId == assigneeId).Skip((page - 1) * pageSize).Take(pageSize).ToList();                
            }
        }

        public List<Task> GetTaskByPriority(Int32 page, Int32 pageSize, Guid priorityId)
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.Tasks.Where(t => t.PriorityId == priorityId).Skip((page - 1) * pageSize).Take(pageSize).ToList(); 
            }
        }

        public List<Task> GetTaskByState(Int32 page, Int32 pageSize, Guid stateId)
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.Tasks.Where(t => t.StateId == stateId).Skip((page - 1) * pageSize).Take(pageSize).ToList(); 
            }
        } 


        public List<Task> GetTasks(Int32 page, Int32 pageSize, Guid assigneeId, Guid priorityId, DateTime firstDate, DateTime lastDate)
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                var q = dc.Tasks.Where(t => 1 == 1);
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
                var list = q.ToList();
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


        public void AddTask(string startDate, string finishDate, string title, string description, string priorityId, string assigneeId, string stateId)
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

            Task newTask = new Task();
            newTask.TaskId = Guid.NewGuid();
            newTask.StartDate = _startDate;
            newTask.FinishDate = _finishDate;
            newTask.Title = title;
            newTask.Description = description;
            newTask.PriorityId = _priorityId;
            newTask.AssigneeId = _assigneeId;
            newTask.Picture = @"D:\work\TODOList\Images";
            newTask.StateId = _stateId;

            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                dc.Tasks.InsertOnSubmit(newTask);
                dc.SubmitChanges();
            }
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
