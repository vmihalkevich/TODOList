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
                return dc.tAssignees.Select(a => CastAssignee(a)).ToList();
            }
        }

        public Assignee GetAssigneeById(Guid id)
        {
            Assignee assignee;
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                var linqAssignee = dc.tAssignees.SingleOrDefault(a => a.AssigneeId == id);
                assignee = CastAssignee(linqAssignee);
            }
            return assignee;
        }

        private static Assignee CastAssignee(tAssignee linqAssignee)
        {
            return linqAssignee == null ? null : new Assignee
            {
                Id = linqAssignee.AssigneeId,
                FirstName = linqAssignee.FirstName,
                LastName = linqAssignee.LastName,
                Login = linqAssignee.Login
            };
        }
    }
}
