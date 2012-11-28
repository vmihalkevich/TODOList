using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class StateRepository
    {
        public List<State> GetAllStates()
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                return dc.tStates.Select(s => new State { Id = s.StateId, Text = s.Text }).ToList();
            }
        }

        public State GetStateById(Guid id)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                var state = dc.tStates.SingleOrDefault(s => s.StateId == id);
                if (state != null)
                {
                    return new State { Id = state.StateId, Text = state.Text };
                }
                return null;
            }
        }
    }
}
