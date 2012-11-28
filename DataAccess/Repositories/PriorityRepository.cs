using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class PriorityRepository
    {
        public List<Priority> GetAllPriorities()
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
               // return dc.Priorities.ToList();
                return dc.tPriorities.Select(p => new Priority { Id = p.PriorityId, Text = p.Text }).ToList();
            }
        }

        public Priority GetPriorityById(Guid id)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
              //  return dc.Priorities.SingleOrDefault(p => p.PriorityId == id);
                var priority = dc.tPriorities.SingleOrDefault(p => p.PriorityId == id);
                if (priority != null) 
                {
                    return new Priority { Id = priority.PriorityId, Text = priority.Text };
                }
                return null;                
            }
        }
    }
}
