using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DemoWeb.Controllers
{
    public class DemoApiController : JsonNetController
    {
        [HttpPost]
        public ActionResult PostString(ModelParameter InputText)
        {
            try
            {

                SecurityManager.Authorize(Request);//檢測IP是否允許連線，設定在Web.config。
                return Json(new ApiSucc("1111",
                    CodecModule.PostString(InputText.Name)));
            }
            catch (Exception ex)
            {
                return Json(new ApiError("500", ex.Message));
            }
        }

        public class ModelParameter
        {
            public string Name { get; set; }
        }


        [HttpGet]

        public ActionResult GetStr()
        {
            try
            {
                SecurityManager.Authorize(Request);//檢測IP是否允許連線，設定在Web.config。
                string Text = "RT_LAB DemoWebApi";
                return Json(new ApiSucc("1112",
                    CodecModule.GetStr(Text)), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ApiError("500", ex.Message));
            }
        }

        [HttpGet]

        public ActionResult GetStrNChange(string inputText)
        {
            try
            {
                SecurityManager.Authorize(Request);//檢測IP是否允許連線，設定在Web.config。
                return Json(new ApiSucc("1113",
                    CodecModule.GetStrNChange(inputText)), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ApiError("500", ex.Message));
            }
        }

    }
}