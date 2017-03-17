using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMODEL;
using VBLL;
using System.IO;

namespace Venus.Controllers
{
    public class WorksController : Controller
    {
        //
        // GET: /Works/

        WorksBLL bll = new WorksBLL();
        /// <summary>
        /// 作品显示
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<WorksModel> list = bll.WorksList();
            return View(list);
        }


        /// <summary>
        /// 作品显示
        /// </summary>
        /// <returns></returns>

        public ActionResult show(int id)
        {
            List<WorksModel> list = bll.Workshow(id);
            return View(list);
        }


        public ActionResult showdo()
        {
            int id = Convert.ToInt32(Request["id"]);
            return View();
        }

        public ActionResult pictures(HttpPostedFileBase image)
        {
            if (image == null)
            {
                return Content("<script>alert('请上传图片')</script>");

            }
            var filname = Path.Combine(Request.MapPath("~/tupian"), Path.GetFileName(image.FileName));
            WorksModel wmodel = new WorksModel();
            wmodel.Worksname = Request["Worksname"].ToString();
            wmodel.Bra = "A";
            wmodel.Size = 32;
            wmodel.thickness = "薄款";
            wmodel.Worksdate = DateTime.Now;
            wmodel.Worksstate = 1;
            wmodel.Worksurl = "/tupian/" + image.FileName;
            wmodel.WorksCount = 0;
            wmodel.Workcontent = Request["Workscontent"].ToString();
            if (Session["userid"] == null)
            {
                return Content("<script>alert('请登录');location.href='/Userinfo/index'</script>");
            }
            else
            {
                wmodel.Userid = Convert.ToInt32(Session["userid"].ToString());
            }




            if (bll.WorksADD(wmodel) > 0)
            {
                //上传到指定目录
                image.SaveAs(filname);
                return Content("<script>alert('上传成功');location.href='/Userhome/index'</script>");


            }
            else
            {
                return Content("<script>alert('上传失败')</script>");
            }
        }
    }
}
