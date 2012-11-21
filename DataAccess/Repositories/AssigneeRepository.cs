using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class AssigneeRepository
    {
        public List<Assignee> GetAllAssignees()
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.Assignees.ToList();
            }
        }

        public Assignee GetAssigneeById(Guid id)
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.Assignees.SingleOrDefault(a => a.AssigneeId == id);
            }
        }


    }
}
