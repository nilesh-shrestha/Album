using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using McRobbie.Com;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Pages
{
    public class UpdateModel : PageModel
    {
        public string Heading { get; set; }
        public Album upRecord { get; set; }

        public void OnGet()
        {
            Heading = "Chinook Albums";
            int albumId = int.Parse(HttpContext.Request.Query["albumId"]);
            Chinook db = new Chinook();
            upRecord = db.albums.First(c => c.AlbumId == albumId);
        }

        public IActionResult OnPost()
        {
            Heading = "Chinook Albums";
            int albumId = int.Parse(Request.Form["albumId"]);
            Chinook db = new Chinook();
            upRecord = db.albums.First(c => c.AlbumId == albumId);
            string title = Request.Form["title"];
            int artistId = int.Parse(Request.Form["artistId"]);

            upRecord.Title = title;
            upRecord.ArtistId = artistId;

            db.albums.Update(upRecord);
            db.SaveChanges();

            return Redirect("~/Index");
        }
    }
}