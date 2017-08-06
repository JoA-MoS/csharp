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
            Artist mv = Artists.Where(x => x.Hometown == "Mount Vernon").SingleOrDefault();
            Console.WriteLine($"{mv.ArtistName} - {mv.Age}");
            //Who is the youngest artist in our collection of artists?
            Artist youngest = Artists.OrderBy(x => x.Age).First();
            Console.WriteLine($"{youngest.ArtistName}");
            //Display all artists with 'William' somewhere in their real name
            List<Artist> williamArtists = Artists.Where(x => x.RealName.Contains("William")).ToList();
            foreach (Artist a in williamArtists)
            {
                Console.WriteLine(a.RealName);
            }
            //Display the 3 oldest artist from Atlanta
            List<Artist> oldest3 = Artists.Where(x => x.Hometown == "Atlanta").OrderByDescending(x => x.Age).Take(3).ToList();
            foreach (Artist a in oldest3)
            {
                Console.WriteLine($"{a.ArtistName} - {a.Age}");
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            var groupsWithMemsNotFromNY = ( from a in Artists
                                            from g in Groups
                                            where a.GroupId == g.Id && a.Hometown != "New York City"
                                            select g).Distinct();
            System.Console.WriteLine("=======================================");
            foreach (Group g in groupsWithMemsNotFromNY)
            {
                Console.WriteLine(g.GroupName);
                // foreach (Artist a in g.Members)
                // {
                //     Console.WriteLine($"\t{a.ArtistName} - {a.Hometown}");
                // }
            }
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
             var wuTangArtists = ( from a in Artists
                                    from g in Groups
                                    where a.GroupId == g.Id && g.GroupName == "Wu-Tang Clan"
                                    select a);
            System.Console.WriteLine("=======================================");
            foreach (Artist a in wuTangArtists)
            {
                Console.WriteLine(a.ArtistName);
                // foreach (Artist a in g.Members)
                // {
                //     Console.WriteLine($"\t{a.ArtistName} - {a.Hometown}");
                // }
            }
        }
    }
}
