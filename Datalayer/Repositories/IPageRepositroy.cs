using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
   public interface IPageRepositroy:IDisposable
    {
        IEnumerable<Page> GetAllPages();
        Page GetPageByID(int pageId);
        bool Insert(Page page);
        bool Uptade(Page page);
        bool Delete(Page page);
        bool Delete(int pageId);
        void save();
        IEnumerable<Page> GetPagesByView(int take);
    }
}
