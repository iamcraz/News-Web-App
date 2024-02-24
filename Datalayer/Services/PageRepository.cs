using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class PageRepository : IPageRepositroy
    {
        private MyFirstWebAppContext db;
        public PageRepository(MyFirstWebAppContext context)
        {
            this.db = context;
        }
        public IEnumerable<Page> GetAllPages()
        {
            return db.Pages;
        }

        public Page GetPageByID(int pageId)
        {
            return db.Pages.Find(pageId);
        }
        public bool Insert(Page page)
        {
            try
            {
                db.Pages.Add(page);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Uptade(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool Delete(int pageId)
        {
            try
            {
                var user = GetPageByID(pageId);

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

        public IEnumerable<Page> GetPagesByView(int take=4)
        {
            return db.Pages.OrderByDescending(x => x.Visit).Take(take);
        }

        public IEnumerable<Page> GetPagesBySlider()
        {
            return db.Pages.Where(x => x.ShowInSlider == true);
        }

        public IEnumerable<Page> GetPagesByDate(int take=3)
        {
            return db.Pages.OrderByDescending(x => x.CreateDate).Take(take);
        }
        public IEnumerable<Page> GetPagesByGroupID(int id)
        {
            return db.Pages.Where(x => x.GroupID == id);
        }
        public string GetPagesTitleByGroupId(int id)
        {
            return db.Pages.First(x => x.GroupID == id).PageGroup.GroupTitle;
        }
    }
}
