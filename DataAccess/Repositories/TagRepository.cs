using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class TagRepository
    {
        public List<Tag> GetAllTags()
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                return dc.tTags.Select(t => new Tag { Id = t.TagId, Text = t.Text }).ToList();
            }
        }

        public Tag GetTagById(Guid id)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                var tag = dc.tTags.SingleOrDefault(t => t.TagId == id);
                if (tag != null) 
                {
                    return new Tag { Id = tag.TagId, Text = tag.Text };
                }
                return null; 
            }
        }

        public string GetTaskTags(Guid id)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                string strTags = "";
                var query = (from tag in dc.tTags
                            join taskTag in dc.tTaskTags on tag.TagId equals taskTag.TagId
                            where taskTag.TaskId == id
                            orderby tag.Text
                            select new Tag { Text = tag.Text }).ToList<Tag>();


                strTags = String.Join(", ", query);

                return strTags;
            }
        }

        public void AddTaskTag(Guid taskId, Guid tagId)
        {
            
            tTaskTag newTaskTag = new tTaskTag();
            newTaskTag.TaskTagId = Guid.NewGuid();
            newTaskTag.TaskId = taskId;
            newTaskTag.TagId = tagId;           

            using (TodoListDataContext dc = new TodoListDataContext())
            {
                dc.tTaskTags.InsertOnSubmit(newTaskTag);
                dc.SubmitChanges();
            }
        }
    }
}
