using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class TaskRepository
    {
        public List<Task> GetAllTasks()
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.Tasks.ToList();
            }
        }

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
                if (assigneeId != null)
                {
                    q = q.Where(t => t.AssigneeId == assigneeId);
                }
                if (priorityId != null)
                {
                    q = q.Where(t => t.PriorityId == priorityId);
                }
                if (firstDate != null)
                {
                    q = q.Where(t => t.StartDate <= firstDate);
                }
                if (lastDate != null)
                {
                    q = q.Where(t => t.FinishDate >= lastDate);
                }
                var list = q.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return list;
            }
        }

    }
}
