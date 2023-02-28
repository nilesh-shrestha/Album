using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using McRobbie.Com;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Pages
{
    public class DeleteModel : PageModel
    {
        public string Heading { get; set; }
        public Album delRecord { get; set; }

        public IActionResult OnGet()
        {
            Heading = "Chinook Albums";
            int albumId = int.Parse(HttpContext.Request.Query["albumId"]);
            Chinook db = new Chinook();
            delRecord = db.albums.First(c => c.AlbumId == albumId);

            db.albums.Remove(delRecord);
            db.SaveChanges();

            return Redirect("~/Index");
        }


    }
}