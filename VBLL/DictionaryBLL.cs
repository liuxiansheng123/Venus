using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMODEL;
using VDAL;

namespace VBLL
{
    public class DictionaryBLL
    {
        DictionaryDAL dal = new DictionaryDAL();
        public List<DictionaryModel> DictionaryList()
        {
            return dal.DictionaryList();
        }

        /// <summary>
        /// 字典表的添加
        /// </summary>
        /// <returns></returns>
        public int DictionaryADD(DictionaryModel mm)
        {
            return dal.DictionaryADD(mm);
        }

        /// <summary>
        /// 字典表的删除
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int DictionaryDelete(DictionaryModel mm)
        {
            return dal.DictionaryDelete(mm);
        }

        /// <summary>
        /// 字典表的修改
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public int DictionaryUpdate(DictionaryModel mm)
        {
            return dal.DictionaryUpdate(mm);
        }
    }
}
