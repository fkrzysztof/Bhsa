using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Harissa.Data.HelperClass
{

    public class CloudAccess
    {
        private readonly Account account;
        private readonly Cloudinary cloudinary;

        public CloudAccess()
        {
            account = 
            cloudinary = new Cloudinary(account);
        }

        public string AddPic(IFormFile formFile, string folderName)
        {
            string filename = formFile.FileName.Split('.')[0];
            var uploadParams = new ImageUploadParams()
            {
                UseFilename = true,
                UniqueFilename = true,
                Overwrite = false,
                File = new FileDescription(filename, formFile.OpenReadStream()),
                Folder = folderName
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            JToken token = JObject.Parse(uploadResult.JsonObj.ToString());
            return Convert.ToString(token.SelectToken("public_id"));
        }

        public void Remove(string id)
        {
            var delResParams = new DelResParams()
            {
                PublicIds = new List<string> { id }
            };
            cloudinary.DeleteResources(delResParams);
        }

        public string GetImg(string img)
        {
            string urlImg = cloudinary.Api.UrlImgUp.BuildUrl(img);
            if (urlImg != null)
                return urlImg;
            else
                return "";
        }

    }
}







