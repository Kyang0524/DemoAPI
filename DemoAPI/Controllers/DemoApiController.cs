using DemoAPI.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DemoWeb.Controllers
{
    public class DemoApiController : JsonNetController
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

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

        [HttpPost]
        public async Task GASLabReceiveFile(HttpPostedFileBase file,string input)
        {

            //Debug.WriteLine("recevied Other server file,file name is :" + file.FileName +", and dictionary key and value are:" + input);
            _logger.Info("recevied file:{0}  dictionary key and value:{1}",file.FileName,input);

            //demo
            string[] filename = file.FileName.Split('.');
            string Filename = filename[0] + "Convert";
            string FileType = "." + filename[filename.Length - 1];
            
            
            //Stream to byte to base64 string
            byte[] text = ConvertStreamToByte(file.InputStream);
            var str = Convert.ToBase64String(text);


            //Code....


            //base64 string to stream
            Stream stream = ConvertString2Stream(str);
            await PostFile(stream, Filename, FileType);

        }

        public async Task PostFile(Stream stream, string Filename, string FileType)
        {
            try
            {
                string file = Filename + FileType;
                HttpClient http = new HttpClient();
                string url = "https://localhost:44382/Home/RTLabReceiveFile";
                MultipartFormDataContent mulContent = new MultipartFormDataContent("----WebKitFormBoundaryrXRBKlhEeCbfHIY");
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                mulContent.Add(fileContent, "file", file);

                await http.PostAsync(url, mulContent);
            }
            catch (Exception) { 
                //ERROR log write here
                Debug.WriteLine("ERROR");
            }
        }
        public static Stream ConvertString2Stream(string StringFile) {

            Stream stream = new MemoryStream(Convert.FromBase64String(StringFile));

            return stream;
        }
        public static byte[] ConvertStreamToByte(Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
    }
}