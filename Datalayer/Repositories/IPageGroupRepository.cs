 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
   public interface IPageGroupRepository:IDisposable
    {
        IEnumerable<PageGroup> GetAllGroups();
        PageGroup GetGroupByID(int groupId);
        bool Insert(PageGroup pagegroup);
        bool Uptade_group(PageGroup pagegroup);  
        bool Delete(PageGroup pagegroup);
        bool Delete(int groupId);
        void save();
        IEnumerable<ShowGroupsView>showGroupsforView();

    }
}
