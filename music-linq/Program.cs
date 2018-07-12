using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var ArtistFromVernon = 
                from artist in Artists 
                where artist.Hometown == "Mount Vernon" 
                select artist;

            foreach(var artist in ArtistFromVernon)
            {
            // System.Console.WriteLine(artist.ArtistName + " " + artist.Age);
            }

            //Who is the youngest artist in our collection of artists?
            var YoungestArtist =
                from artist in Artists
                orderby artist.Age ascending
                // where artist.Age == 46
                select artist;
            var youngest = YoungestArtist.Take(1);

            foreach(var artist in youngest)
            {
            // System.Console.WriteLine(artist.ArtistName);
            }

            //Display all artists with 'William' somewhere in their real name
            var NameWilliam =
                from artist in Artists
                where artist.RealName.Contains("William")
                select artist;
            
            foreach(var artist in NameWilliam)
            {
            // System.Console.WriteLine(artist.ArtistName);
            }

            //Display the 3 oldest artist from Atlanta
            var AtlantaOldest =
                from artist in Artists
                where artist.Hometown == "Atlanta"
                orderby artist.Age descending
                select artist;
            var Elders = AtlantaOldest.Take(3);

            foreach(var artist in Elders)
            {
            System.Console.WriteLine(artist.ArtistName);
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
