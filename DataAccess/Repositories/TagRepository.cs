using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class TagRepository
    {
        private static Tag CastTag(tTag linqTag)
        {
            return linqTag == null ? null : new Tag
            {
                Id = linqTag.TagId,
                Text = linqTag.Text
            };
        }

        public List<Tag> GetAllTags()
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                return dc.tTags.Select(t => CastTag(t)).ToList();
            }
        }

        public Tag GetTagById(Guid id)
        {
            Tag tag;
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                var linqTag = dc.tTags.SingleOrDefault(t => t.TagId == id);
                tag = CastTag(linqTag); 
            }
            return tag;
        }

        public string GetTaskTagsToStr(Guid id)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                string strTags = "";
                var tags = (from tag in dc.tTags
                            join taskTag in dc.tTaskTags on tag.TagId equals taskTag.TagId
                            where taskTag.TaskId == id
                            orderby tag.Text
                            select tag.Text ).ToList();

                strTags = String.Join(", ", tags);
                return strTags;
            }
        }

        public List<Tag> GetTaskTags(Guid id)
        {
            using (TodoListDataContext dc = new TodoListDataContext())
            {
                var tags = (from tag in dc.tTags
                            join taskTag in dc.tTaskTags on tag.TagId equals taskTag.TagId
                            where taskTag.TaskId == id
                            select CastTag(tag)).ToList();
                            //select new Tag { Id = tag.TagId, Text = tag.Text }).ToList<Tag>();
                return tags;
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
