using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
   public class PageGroup
    {
        [Key]
        public int GroupID { get; set; }
        [Display(Name ="سرگروه")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string GroupTitle { get; set; }

        //Navigation Prop
        public virtual List<Page> Pages { get; set; }

        public PageGroup()
        {

        }


    }
}
