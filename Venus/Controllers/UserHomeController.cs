using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VBLL;
using VMODEL;
namespace Venus.Controllers
{
    public class UserHomeController : Controller
    {
        //
        // GET: /UserHome/
        UserinfoBLL usbl = new UserinfoBLL();
        WorksBLL w_bl = new WorksBLL();
        UserHomeBLL UH_bl = new UserHomeBLL();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult user()
        {
            int id = Convert.ToInt32(Session["userid"]);
            UserHomeMODEL<UserinfoModel> userhomelist = UH_bl.UserHomeList(id);
            return Json(userhomelist);
        }
        public JsonResult userinfo()
        {
            int id = Convert.ToInt32(Session["userid"]);
            List<UserinfoModel> list = usbl.UserinfoList();
            UserinfoModel user = new UserinfoModel();
            user = list.Where(p => p.Userid == id).FirstOrDefault();
            return Json(user);
        }
        public int upda()
        {
            UserinfoModel ml = new UserinfoModel();
            ml.Userid = Convert.ToInt32(Session["userid"]);
            ml.Usercheng = Request["cheng"];
            string sex = Request["sex"].ToString();
            if (sex == "男")
            {
                ml.Usersex = 1;
            }
            else if (sex == "女")
            {
                ml.Usersex = 2;
            }
            else
            {
                ml.Usersex = 0;
            }
            ml.Userpwd = Request["pwd"];
            return usbl.UserinfoUpdate(ml);
        }
        /// <summary>
        /// 我的作品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Works(int id)
        {

            List<WorksModel> list = w_bl.WorksList();
            list = list.Where(p => p.Userid == id).ToList();
            return Json(list);
        }
        ///<summary>
        ///我的评论
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        public JsonResult Review()
        {
            int id = Convert.ToInt32(Session["userid"]);
            List<WorksModel> wlist = UH_bl.Review(id);
            return Json(wlist);
        }
        /// <summary>
        /// 我的收藏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Collect()
        {
            int id = Convert.ToInt32(Session["userid"]);
            List<WorksModel> Rlist = UH_bl.Collect(id);
            return Json(Rlist);
        }
        /// <summary>
        /// 判断是否登陆
        /// </summary>
        /// <returns></returns>
        public int fou()
        {
            if (Session["userid"] == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public int tui()
        {
            Session["userid"] = null;
            return 1;
        }
    }
}
