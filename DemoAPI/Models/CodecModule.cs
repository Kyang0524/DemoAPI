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

        public static string PostStringfunction(string InputText)
        {
            string AfterPost = "Hello!" + InputText;
            return AfterPost;
        }

        public static string GetStr(string Name)
        {
             return Name;

        }
        public static string GetStrNChangefunction(string InputText)
        {
            string Text = "RT_LAB DemoWebApi " + InputText;
            return Text;
        }


    }
}