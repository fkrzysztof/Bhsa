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
            ImageUploadParams uploadParams;
            string filename = formFile.FileName.Split('.')[0];
            uploadParams = new ImageUploadParams()
            {
                UseFilename = true,
                UniqueFilename = true,
                Overwrite = false,
                File = new FileDescription(filename, formFile.OpenReadStream()),
                Folder = folderName,
                Tags = folderName

            };
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
            if (string.IsNullOrEmpty(img))
                return noPic();
            string rezult = cloudinary.ListResourcesByPublicIds(new[] { img }).Resources[0].Url.ToString();
            if (string.IsNullOrEmpty(rezult))
               return noPic();
            else
               return rezult;
        }

        private string noPic()
        {
            return GetPicByTag("noPictureFile")[0].ToString();
        }

        public string GetLogo()
        {
            return GetPicByTag("Logo")[0];
        }
        public List<string> GetPicByTag(string tag)
        {
            var rezult = cloudinary.ListResourcesByTag(tag).Resources;
            return getRezult(rezult);
        }

        private List<string> getRezult(Resource[] resource)
        {
            List<string> list = new List<String>();
            string temp;
            foreach (var item in resource)
            {
                temp = item.Url.ToString();
                if (!string.IsNullOrEmpty(temp))
                    list.Add(temp);
                else
                    list.Add(noPic());
            }
            return list;
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







