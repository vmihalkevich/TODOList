using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class StateRepository
    {
        private static State CastState(tState linqState)
        {
            return linqState == null ? null : new State
            {
                Id = linqState.StateId,
                Text = linqState.Text
            };
        }

        public List<State> GetAllStates()
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                return dc.tStates.Select(s => CastState(s)).ToList();
            }
        }

        public State GetStateById(Guid id)
        {
            State state;
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                var linqState = dc.tStates.SingleOrDefault(s => s.StateId == id);
                state = CastState(linqState);
            }
            return state;
        }
    }
}
