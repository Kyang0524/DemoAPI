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

        public class ModelParameter
        {
            public string Name { get; set; }
        }


        [HttpPost]
        public ActionResult PostString(ModelParameter InputText)
        {
            try
            {
                return Json(new ApiSucc("1111",
                    CodecModule.PostStringfunction(InputText.Name)));//跳轉到CodecModule.cs 的某function執行動作
            }
            catch (Exception ex)
            {
                return Json(new ApiError("500", ex.Message));
            }
        } 

        [HttpGet]

        public ActionResult GetStr()
        {
            try
            {
                string Text = "RT_LAB DemoWebApi";
                return Json(new ApiSucc("1112",
                    Text));
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
                return Json(new ApiSucc("1113",
                    CodecModule.GetStrNChangefunction(inputText)));//跳轉到CodecModule.cs 的某function執行動作
            }
            catch (Exception ex)
            {
                return Json(new ApiError("500", ex.Message));
            }
        }

    }
}