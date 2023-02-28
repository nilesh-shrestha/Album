using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using McRobbie.Com;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public string Heading { get; set; }
        public IList<Album> albums { get; set; }

        public void OnGet()
        {
            Heading = "Chinook Albums";
            Chinook db = new Chinook();
            albums = db.albums.ToList();
        }

        public void OnPost()
        {
            Heading = "Chinook Albums";
            Chinook db = new Chinook();

            string title = Request.Form["title"];
            int artistId = int.Parse(Request.Form["artistID"]);

            Album newRecord = new Album
            {
                Title = title,
                ArtistId = artistId
            };

            db.albums.Add(newRecord);
            db.SaveChanges();

            albums = db.albums.ToList();
        }
    }
}