using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class AssigneeRepository
    {
        public List<Assignee> GetAllAssignees()
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                return dc.tAssignees.Select(a => new Assignee { Id = a.AssigneeId, FirstName = a.FirstName, LastName = a.LastName, Login = a.Login }).ToList();
            }
        }

        public Assignee GetAssigneeById(Guid id)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                var assignee = dc.tAssignees.SingleOrDefault(a => a.AssigneeId == id);
                if (assignee != null)
                {
                    return new Assignee { Id = assignee.AssigneeId, FirstName = assignee.FirstName, LastName = assignee.LastName, Login = assignee.Login };
                }
                return null;
            }
        }
    }
}
