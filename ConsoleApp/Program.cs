using System;
using System.Linq;
using McRobbie.Com;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Chinook db = new Chinook();

            // Console.WriteLine("BEFORE INSERT");
            // Console.WriteLine("BEFORE DELETE");
            Console.WriteLine("BEFORE UPDATE");

            IQueryable<Album> albums = db.albums;

            foreach (Album c in albums)
            {
                Console.WriteLine($"{c.AlbumId}. {c.Title} {c.ArtistId}");
            }




            Console.Write("AlbumId: ");
            int albumId = int.Parse(Console.ReadLine());

            Album upRecord = db.albums.First(c => c.AlbumId == albumId);
            Console.WriteLine($"You selected {upRecord.AlbumId}. {upRecord.Title} {upRecord.ArtistId}");

            Console.Write("Title: ");
            string Title = Console.ReadLine();
            Console.Write("ArtistId: ");
            int artistId = int.Parse(Console.ReadLine());

            upRecord.Title = Title;
            upRecord.ArtistId = artistId;

            db.albums.Update(upRecord);
            db.SaveChanges();


            Console.WriteLine("AFTER UPDATE");

            albums = db.albums;

            foreach (Album c in albums)
            {
                Console.WriteLine($"{c.AlbumId}. {c.Title} {c.ArtistId}");
            }

        }
    }
}
