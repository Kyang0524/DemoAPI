using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    // <summary>
    /// API呼叫時，傳回的統一物件
    /// </summary>
    public class ApiResult<T>
    {
        /// <summary>
        /// 執行成功與否
        /// </summary>
        public bool Succ { get; set; }
        /// <summary>
        /// 結果代碼(0000=成功，其餘為錯誤代號)
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 資料時間
        /// </summary>
        public DateTime DataTime { get; set; }
        /// <summary>
        /// 資料本體
        /// </summary>
        public T Data { get; set; }
        public ApiResult() { }

    }

    public class ApiSucc : ApiResult<object>
    {
        /// <summary>
        /// 建立成功結果
        /// </summary>
        /// <param name="data"></param>
        public ApiSucc(string code, string data)
        {
            Code = code;//代碼可自定義
            Succ = true;
            Message = "";//成功是 錯誤訊息為空值
            DataTime = DateTime.Now; //回傳的時間
            Data = data;//回傳的資料
        }
    }

    public class ApiError : ApiResult<object>
    {
        /// <summary>
        /// 建立失敗結果
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ApiError(string code, string message)
        {
            Code = code;//錯誤代碼為500
            Succ = false;
            this.DataTime = DateTime.Now;//回傳的時間
            Message = message; //回傳錯誤訊息
            Data = "";//失敗時 資料為空值
        }
    }
}