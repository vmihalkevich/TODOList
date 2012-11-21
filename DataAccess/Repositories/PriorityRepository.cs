using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class PriorityRepository
    {
        public List<Priority> GetAllPriorities()
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.Priorities.ToList();
            }
        }

        public Priority GetPriorityById(Guid id)
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.Priorities.SingleOrDefault(p => p.PriorityId == id);
            }
        }
    }
}
