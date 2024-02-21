using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
   public interface IPageCommentRepository
    {
        IEnumerable<PageComment> GetAllGroups();
        PageGroup GetGroupByID(int CommentID);
        bool Insert(PageComment Comment);
        bool Uptade_group(PageComment Comment);
        bool Delete(PageComment Comment);
        bool Delete(int CommentID);
        void save();
    }
}
