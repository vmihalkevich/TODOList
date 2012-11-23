using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Entities
{
    public class Task : EntityBase
    {
        public Guid TaskId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid PriorityId { get; set; }
        public Guid AssigneeId { get; set; }
        public string Picture { get; set; }
        public Guid StateId { get; set; }
    }
}
