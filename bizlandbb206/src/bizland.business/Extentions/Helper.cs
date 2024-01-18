﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.business.Extentions
{
    public static class Helper
    {
       public static string SaveFile(this IFormFile file,string rootpath,string foldername)
        {
            var filename=file.FileName.Length>64
                ?file.FileName.Substring(file.FileName.Length - 64,64) 
                :file.FileName;
            filename = Guid.NewGuid().ToString() + filename;
            string path=Path.Combine(rootpath,foldername,filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return filename;
        }
        public static void DeleteFile(string rootpath,string foldername,string ImageUrl) 
        { 
            var deletefile=Path.Combine(rootpath, foldername,ImageUrl);
            if (File.Exists(deletefile))
            {
                File.Delete(deletefile);
            }

        } 
    }
}
