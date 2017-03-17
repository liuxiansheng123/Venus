using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMODEL;
using VBLL;

namespace Venus.Controllers
{
    public class UserinfoController : Controller
    {
        //
        // GET: /Userinfo/
        UserinfoBLL bll = new UserinfoBLL();
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录判断
        /// </summary>
        /// <returns></returns>
        public int LoginDo()
        {
            // 
            UserinfoModel mm = new UserinfoModel();
            string username = Request["sname"]; ;
            string pwd = Request["spwd"];
            int isChecked =Convert.ToInt32(Request["isChecked"]);
            List<UserinfoModel> list = bll.UserinfoList();
            UserinfoModel Ulist = list.Where(p => p.Username == username && p.Userpwd == pwd).FirstOrDefault();
            if (Ulist != null)
            {
                Session["userid"] = Ulist.Userid;
                //选中记住密码复选框后创建Cookie
                if (isChecked == 1)
                {
                    HttpCookie cookie = new HttpCookie("UserInfo");
                    //如果不存在该Cookie
                    if (cookie == null)
                    {

                        cookie["Uname"] = Ulist.Username;
                        cookie["Upwd"] = Ulist.Userpwd;
                        cookie.Expires.AddDays(3);
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        if (Ulist.Username == cookie["Uname"])
                        {

                        }
                        else
                        {
                            HttpCookie newCookie = new HttpCookie("UserInfo");
                            cookie["Uname"] = Ulist.Username;
                            cookie["Upwd"] = Ulist.Userpwd;
                            cookie.Expires = DateTime.Now.AddDays(10);
                            Response.Cookies.Set(cookie);
                        }
                    }
                }
                else
                {
                    HttpCookie theCookie = Request.Cookies["UserInfo"];
                    if (theCookie != null)
                    {
                        theCookie.Values.Remove("Uname");
                        theCookie.Values.Remove("Upwd");
                        theCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(theCookie);
                    }
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 注册判断
        /// </summary>
        /// <returns></returns>
        public int RegisterDo()
        {
            UserinfoModel mm = new UserinfoModel();
            mm.Username = Request["sname"];
            mm.Userpwd = Request["spwd"];
            mm.Userstate = 1;
            if (bll.UserinfoCount(mm) >= 1)
            {
                return 1;
            }
            else
            {
                if (bll.UserinfoADD(mm) > 0)
                {

                    return 3;
                }
                else
                {
                    return 0;
                }
            }
        }




        ///// <summary>
        ///// 记录和清空Cookies
        ///// </summary>
        ///// <returns></returns>
        //public JsonResult Cookies()
        //{
        //    string username = Request["sname"]; ;
        //    string pwd = Request["spwd"];
        //    HttpCookie cookie = new HttpCookie("MyCook");//初使化并设置Cookie的名称
        //    DateTime dt = DateTime.Now;
        //    TimeSpan ts = new TimeSpan(0, 0, 1, 0, 0);//过期时间为1分钟
        //    cookie.Expires = dt.Add(ts);//设置过期时间
        //    cookie.Values.Add("username", "userid_value");
        //    cookie.Values.Add("pwd", "userid2_value2");
        //    Response.AppendCookie(cookie);
        //    //输出该Cookie的所有内容
        //    //Response.Write(cookie.Value);//输出为：userid=userid_value&userid2=userid2_value2 
        //    //读取
        //    // HttpCookie cokie = new HttpCookie("MyCook");//初使化
        //    if (Request.Cookies["MyCook"] != null)
        //    {
        //        //Response.Write("Cookie中键值为userid的值:" + Request.Cookies["MyCook"]["userid"]);//整行
        //        //Response.Write("Cookie中键值为userid2的值" + Request.Cookies["MyCook"]["userid2"]);
        //        Response.Write(Request.Cookies["MyCook"].Value);//输出全部的值
        //    }

        //    //修改Cookie

        //    //获取客户端的Cookie对象
        //    HttpCookie cok = Request.Cookies["MyCook"];

        //    if (cok != null)
        //    {
        //        //修改Cookie的两种方法
        //        cok.Values["userid"] = "alter-value";
        //        cok.Values.Set("userid", "alter-value");

        //        //往Cookie里加入新的内容
        //        cok.Values.Set("newid", "newValue");
        //        Response.AppendCookie(cok);
        //    }
        //}

        //public void SetCookie(UserinfoModel user)
        //{
        //    HttpCookie myCookie = HttpContext.Current.Request.Cookies[CookieName] ?? new HttpCookie(CookieName);
        //    myCookie.Values["UserId"] = user.UserId.ToString();
        //    myCookie.Values["LastVisit"] = DateTime.Now.ToString();
        //    myCookie.Expires = DateTime.Now.AddDays(365);
        //    HttpContext.Current.Response.Cookies.Add(myCookie);
        //}
    }
}
