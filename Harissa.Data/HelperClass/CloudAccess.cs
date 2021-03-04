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
            account = cxz
            cloudinary = new Cloudinary(account);
        }

        public string AddPic(IFormFile formFile, string folderName, bool noImgPicture = false)
        {
            ImageUploadParams uploadParams;
            string filename = formFile.FileName.Split('.')[0];
            if (noImgPicture == true)
            {
                uploadParams = new ImageUploadParams()
                {
                    Tags = "noPictureFile",
                    Overwrite = true,
                    File = new FileDescription(filename, formFile.OpenReadStream()),
                    Folder = folderName
                };
            }
            else
            {
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
            if (!string.IsNullOrEmpty(img))
                return cloudinary.Api.UrlImgUp.BuildUrl(img);
            else
            {
                var listResourcesByTagParams = new ListResourcesByTagParams()
                {
                    Tag = " noPictureFile ",
                    MaxResults = 1
                };
                var listResourcesResult = cloudinary.ListResources(listResourcesByTagParams);
                return listResourcesResult.Resources[0].Url.ToString();

                //zmienic reszte na takie
            }
        }

        public string ChangeItem(string oldItem, IFormFile newItem, string folderName)
        {

            if (newItem == null)
                return oldItem;
            
            if(!string.IsNullOrEmpty(oldItem))
            {
                Remove(oldItem);
                return AddPic(newItem, folderName);
            }
            else
                return AddPic(newItem, folderName);
        }
    }
}







