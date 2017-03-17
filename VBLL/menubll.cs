using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDAL;
using VMODEL;
namespace VBLL
{
    public class menubll
    {
        menudal dal = new menudal();
        public List<menuview> list()
        {
            return dal.parentlist();
        }
    }
}
