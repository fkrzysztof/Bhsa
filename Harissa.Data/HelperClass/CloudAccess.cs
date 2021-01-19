using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harissa.Data.HelperClass
{
    public class CloudAccess
    {
        public static Cloudinary GetCloud()
        {
        Account account = new Account(
            //private

          );

        Cloudinary cloudinary = new Cloudinary(account);
        
        return cloudinary;
        }
    }
}
