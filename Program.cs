using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;
namespace ConsoleApplication
{
    public class Programa
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
                // var vernon = Artists.Where(city => city.Hometown == "Mount Vernon").Select(p => new IEnumerable(p.RealName, p.Age));
                // System.Console.WriteLine(vernon.RealName + " " + vernon.Age);
 
                    
                var artistfromVernon = from p in Artists
                                        where p.Hometown == "Mount Vernon"
                                        select p.RealName;
                System.Console.WriteLine(artistfromVernon);
                foreach( var art in artistfromVernon){
                    System.Console.WriteLine(art);
                }
            //Who is the youngest artist in our collection of artists?
                var youngestArt = (from y in Artists
                                    // orderby y.Age ascending
                                    select y.Age).Min(); 
                System.Console.WriteLine(youngestArt);
                // foreach( var yong in youngestArt){
                //     System.Console.WriteLine(yong);
                // }
            //Display all artists with 'William' somewhere in their real name
            var WilliamArtists = from a in Artists
                                 where a.RealName.Contains("William")
                                 select a.ArtistName;
 
            foreach (var billy in WilliamArtists)
            {
                Console.WriteLine($"Billies: {billy}");
            }
                                                
            //Display the 3 oldest artist from Atlanta
            var oldArt = (from a in Artists
                        orderby a.Age descending
                        where a.Hometown == "Atlanta"
                        select new {a.ArtistName,a.Age,a.Hometown}).Take(3);
            System.Console.WriteLine("-------------------------------------------------");
            foreach (var billy in oldArt)
            {
                Console.WriteLine($"{billy}");
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
                 var nonNYC = (from g in Groups
                             join a in Artists on g.Id equals a.GroupId
                             where a.Hometown != "New York City"                                                                               
                             select g.GroupName).Distinct();   
                             
                foreach (var group in nonNYC)
                {                    
                    Console.WriteLine($"Groups: {group}");
                }                         
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
                var WuTang = from a in Artists
                             join g in Groups on a.GroupId equals g.Id
                             where g.Id == 1                                                                               
                             select a.ArtistName;
            foreach (var artist in WuTang)
            {
                Console.WriteLine($"Wutang Members: {artist}");
            }      
            var shortName = from g in Groups
                            where g.GroupName.Count()<8
                            select g.GroupName;
            foreach (var groups in shortName)
            {
                Console.WriteLine($"Short Names: {groups}");
            }                 
	    Console.WriteLine(Groups.Count);
        }
    }
}
