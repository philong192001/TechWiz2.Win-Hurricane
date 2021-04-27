using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebApplication.Services.Convertmd5
{
    public class Convertmd5 : IConvertmd5
    {
        public string ConvertService(string code)
        {
            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(code);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            var sb = "";

            for (int i = 0; i < hash.Length; i++)
            {
                sb += (hash[i].ToString("X2")).ToString();
            }

            return sb;
        }
    }
}
