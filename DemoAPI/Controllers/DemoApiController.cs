using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DemoWeb.Controllers
{
    public class DemoApiController : JsonNetController
    {

        public class ModelParameter //Object
        {
            public string Name { get; set; }
            public string Id { get; set; }
        }


        [HttpPost]
        public ActionResult PostString(ModelParameter InputText)
        {
            try
            {
                return Json(new ApiSucc("1111",
                    CodecModule.PostStringfunction(InputText.Id, InputText.Name)));//跳轉到CodecModule.cs 的某function執行動作，然後 return 資料回呼叫地方
            }
            catch (Exception ex)
            {
                return Json(new ApiError("500", ex.Message));//錯誤跳轉信息
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
                return Json(new ApiError("500", ex.Message));//錯誤跳轉信息
            }
        }

        [HttpGet]

        public ActionResult GetStrNChange(string inputText)
        {
            //HttpClient http = new HttpClient();
            //Task<string> task = http.GetStringAsync(fullurl);
            //string ResultTyle = JsonConvert.DeserializeObject<ResultType>(task.Result).data;
            if (inputText == null)
            {
                return Json(new ApiError("400", "Error API"));//錯誤跳轉信息
            }
            try
            {
                return Json(new ApiSucc("1113",
                    CodecModule.GetStrNChangefunction(inputText)));//跳轉到CodecModule.cs 的某function執行動作，然後 return 資料回呼叫地方
            }
            catch (Exception ex)
            {
                return Json(new ApiError("500", ex.Message));//錯誤跳轉信息
            }
        }

    }
}