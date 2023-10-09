using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DemoAPI.Models
{
    public class CodecModule
    {

        public static string PostStringfunction(string Id, string Name)
        {
            string AfterPost = "Hello! "+Id+":" + Name; //執行動作，需要將接收到的資料修改成什麼
            return AfterPost;
        }

        public static string GetStrNChangefunction(string InputText)
        {
            string Text = InputText; //執行動作，需要將接收到的資料修改成什麼
            return Text;
        }


    }
}