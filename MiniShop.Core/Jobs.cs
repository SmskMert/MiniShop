using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MiniShop.Core
{
    public static class Jobs
    {
        public static string MakeUrl(string productName)
        {
            productName = productName.Replace("I", "i");
            productName = productName.Replace("ı", "i");
            productName = productName.Replace("İ", "i");

            productName = productName.ToLower();

            productName = productName.Replace("ö", "o");
            productName = productName.Replace("ü", "u");
            productName = productName.Replace("ğ", "g");
            productName = productName.Replace("ç", "c");
            productName = productName.Replace("ş", "s");

            productName = productName.Replace("/", "");
            productName = productName.Replace("\\", "");
            productName = productName.Replace(".", "");
            productName = productName.Replace(" ", "-");
            return productName;
        }

        public static string UploadImage(IFormFile file, string url)
        {
            var extension = Path.GetExtension(file.FileName);
            var randomName= $"{url}-{Guid.NewGuid()}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images",randomName);
            using(var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return randomName;
        }
        public static string CreateMessage(string title, string message, string alertType)
        {
            var msg = new AlertMessage(){
                Title=title,
                Message = message,
                AlertType=alertType
            };
            return JsonConvert.SerializeObject(msg);
        }
    }
}