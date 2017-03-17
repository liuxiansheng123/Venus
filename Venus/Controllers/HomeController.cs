using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VBLL;
using VMODEL;
namespace Venus.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        /// <summary>
        /// 首页显示
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            WorksBLL bll = new WorksBLL();
            ViewBag.list = bll.WorksList();
            ViewBag.hot = bll.WorkHot();
            return View();
        }
        /// <summary>
        /// 作品详情
        /// </summary>
        /// <returns></returns>
        public ActionResult show(int id=2)
        {
            WorksBLL wbll=new WorksBLL();
            WorksModel list = wbll.idlist(id);          
            return View(list);
        }
        /// <summary>
        /// 有多少收藏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int shou()
        {
            int id = Convert.ToInt32(Request["id"]);
            CollectBLL cbll = new CollectBLL();
            return cbll.CollectCount(id);
        }
        public ActionResult add()
        {
            return View();
        }
        public ActionResult test()
        {
            return View();
        }
        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int dianzan(int id)
        {
            LikesBLL lbll = new LikesBLL();
            UserinfoModel m = Session["userid"] as UserinfoModel;
            LikesModel z = new LikesModel();
            z.UserId = m.Userid;
            z.Worksid = id;
            if (lbll.LikesADD(z) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 消赞
        /// </summary>
        /// <param name="workid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int xiaozan(int workid, int userid)
        {
            LikesBLL lbll = new LikesBLL();
            if (lbll.LikesDelete(workid, userid) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 评论
        /// </summary>
        /// <returns></returns>
        public int pinglun()
        {
            ReviewBLL rbll = new ReviewBLL();
            int workid = Convert.ToInt32(Request["workid"]);
            string PinglunContent = Request["PinglunContent"].ToString();
            ReviewModel t = new ReviewModel();
            t.Reviewcontent = PinglunContent;
            t.Userid = Convert.ToInt32(Session["userid"]);
            t.Reviewstate = DateTime.Now;
            t.Worksid = workid;
            if (rbll.ReviewADD(t) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}
