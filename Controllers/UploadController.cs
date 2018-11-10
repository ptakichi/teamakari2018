using System;
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
    public class UploadController : Controller
    {

         
        public ActionResult OnGet()
        {
            UploadModel model = new UploadModel();
            return View("Upload", model);
        }

    
        [HttpPost]
        [RequestSizeLimit(100000000)]
        public ActionResult OnPost(IFormFile uploadFile){

            UploadModel model = new UploadModel();

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

                string resultMessage = "";

                Anaryze an = new Anaryze();
                an.TranslationWithFileAsync( uploadfilePath,resultMessage).Wait();

                model.resultMessage = resultMessage;
            }

            return View("Upload", model);
        }


    }
}