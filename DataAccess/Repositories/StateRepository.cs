using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class StateRepository
    {
        public List<State> GetAllStates()
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.States.ToList();
            }
        }

        public State GetStateById(Guid id)
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.States.SingleOrDefault(s => s.StateId == id);
            }
        }

    }
}
