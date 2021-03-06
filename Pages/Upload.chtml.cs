﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Web;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace teamakari2018.Pages
{
    public class UploadModel : PageModel
    {
        public void OnGet()
        {
            
        }

    
        [HttpPost]
        [RequestSizeLimit(100000000)]
        public void OnPost(IFormFile uploadFile){
            if (uploadFile != null) {
                Console.Write("\n\n\n\n\n\n\n==================\n");
                Console.Write("FileName: {0}",uploadFile.FileName);//Gets the file name from the Content-Disposition header.
                Console.Write("\nHeader: {0}",uploadFile.Headers);//Gets the header dictionary of the uploaded file
                Console.Write("\nLength: {0}",uploadFile.Length);//Gets the file length in bytes.
                Console.Write("\nName: {0}",uploadFile.Name);//Gets the form field name from the Content-Disposition header.
                Console.Write("\nContent-type: {0}",uploadFile.ContentType);//Gets the raw Content-Type header of the uploaded file.
                Console.Write("\n==================\n\n\n\n\n\n");
                // full path to file in temp location
                var uploadfilePath = Path.GetTempPath() + uploadFile.FileName;

                using (var stream = new FileStream(uploadfilePath, FileMode.Create))
                {
                    uploadFile.CopyToAsync(stream).Wait();
                }

                Anaryze an = new Anaryze();
                an.TranslationWithFileAsync( uploadfilePath,resultMessage).Wait();
            }
            else{
                Console.Write("\n\n\n\n\n\n\n==================\n");
                Console.Write("File not found");
                Console.Write("\n==================\n\n\n\n\n\n");
            }

        }

        public string resultMessage {get;set;} = "音声ファイルをアップロードしてください";

    }
}
