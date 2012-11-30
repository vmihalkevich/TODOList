using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class PriorityRepository
    {
        private static Priority CastPriority(tPriority linqPriority)
        {
            return linqPriority == null ? null : new Priority
            {
                Id = linqPriority.PriorityId,
                Text = linqPriority.Text
            };
        }

        public List<Priority> GetAllPriorities()
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {               
                return dc.tPriorities.Select(p => CastPriority(p)).ToList();
            }
        }

        public Priority GetPriorityById(Guid id)
        {
            Priority priority;
            using (TodoListDataContext dc = new TodoListDataContext())
            {              
                var linqPriority = dc.tPriorities.SingleOrDefault(p => p.PriorityId == id);
                priority = CastPriority(linqPriority);              
            }
            return priority;
        }
    }
}
