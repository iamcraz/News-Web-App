using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
   public class PageGroupRepository : IPageGroupRepository
    {
        private MyFirstWebAppContext db;

        public PageGroupRepository(MyFirstWebAppContext context)
        {
            this.db = context;
        }

        public IEnumerable<PageGroup> GetAllGroups()
        {
            return db.PageGroups;       
        }

        public PageGroup GetGroupByID(int groupId)
        {
            return db.PageGroups.Find(groupId);
        }

        public bool Insert(PageGroup pagegroup)
        {
            try
            {
                 db.PageGroups.Add(pagegroup);
                 
                 return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Uptade_group(PageGroup pagegroup)
        {
            try
            {
                db.Entry(pagegroup).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(PageGroup pagegroup)
        {
            try
            {
                db.Entry(pagegroup).State = EntityState.Deleted;
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool Delete(int groupId)
        {
            try
            {
                var user = GetGroupByID(groupId);

                Delete(user);

                return true;
            }
            catch
            {

                return false;
            }
        }

        public void save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<ShowGroupsView> showGroupsforView()
        {
            return db.PageGroups.Select(x => new ShowGroupsView()
            {
                GroupID=x.GroupID,
                GroupTitle=x.GroupTitle,
                GroupCount=x.Pages.Count,
            });
        }
    }
}
