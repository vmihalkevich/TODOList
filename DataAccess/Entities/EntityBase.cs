using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
    }
}
