using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace teamakari2018.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Connect 2018 in Koriyama, with UDC （ハッカソン） チームあかり<br>https://www.techno-media.net6.or.jp/newmedia/human/1474";
        }
    }
}
