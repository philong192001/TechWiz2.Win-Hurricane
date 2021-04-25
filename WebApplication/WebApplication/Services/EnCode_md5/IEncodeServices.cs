using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Services.EnCode_md5
{
    public interface IEncodeServices
    {
        public  string Encrypt(string text);
        public  string Decrypt(string cipher);


    }
}
