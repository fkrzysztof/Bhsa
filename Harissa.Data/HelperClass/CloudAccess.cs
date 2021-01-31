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
            account = xxxx;
            cloudinary = new Cloudinary(account);
        }

        public string AddPic(IFormFile formFile, string folderName,bool noImgPicture = false)
        {
            if(formFile == null)
            {
                return "PageSettings/noImg";
            }

            ImageUploadParams uploadParams;
            if(noImgPicture == true)
            {
                uploadParams = new ImageUploadParams()
                {
                    UseFilename = true,
                    UniqueFilename = false,
                    Overwrite = true,
                    File = new FileDescription("noImg", formFile.OpenReadStream()),
                    Folder = folderName
                };
            }
            else
            {
                string filename = formFile.FileName.Split('.')[0];
                uploadParams = new ImageUploadParams()
                {
                    UseFilename = true,
                    UniqueFilename = true,
                    Overwrite = false,
                    File = new FileDescription(filename, formFile.OpenReadStream()),
                    Folder = folderName
                };
            }

            var uploadResult = cloudinary.Upload(uploadParams);
            JToken token = JObject.Parse(uploadResult.JsonObj.ToString());
            return Convert.ToString(token.SelectToken("public_id"));
        }

        public void Remove(string id)
        {
            var delResParams = new DelResParams()
            {
                PublicIds = new List<string> { id },
                KeepOriginal = false,
                Invalidate = true
            };
            cloudinary.DeleteResources(delResParams);
        }

        public string GetImg(string img)
        {
            string urlImg = cloudinary.Api.UrlImgUp.BuildUrl(img);
            if (urlImg != null)
                return urlImg;
            else
                return "";//cloudinary.Api.UrlImgUp.BuildUrl("PageSettings/noImg");
        }
        
    }
}







