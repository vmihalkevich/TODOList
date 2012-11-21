using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class TagRepository
    {
        public List<Tag> GetAllTags()
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.Tags.ToList();
            }
        }

        public Tag GetTagById(Guid id)
        {
            using (dbTODOListDataContext dc = new dbTODOListDataContext())
            {
                return dc.Tags.SingleOrDefault(t => t.TagId == id);
            }
        }
    }
}
