using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace PetProject.Models
{
    public class QueryContext:ApplicationDbContext
    {

        /*  public virtual DbSet<Album> Albums { get; set; }


          public List<Album> GetAlbums()
          {

              var res = (from a in Albums
                         select a).ToList();

              return res;
          }*/
       // public virtual DbSet<Play> Plays { get; set; }
       // public virtual DbSet<Song> Songs { get; set; }

        public virtual DbSet<Rating> Ratings { get; set; }
        public int GetCountBySong(int songId)
        {
            return (from p in Plays
                    where p.song.Id == songId
                    select p).Count();
        }

      
            public dynamic GetTopSongs(DateTime? earliest, DateTime? latest, int limit)
        {

        
            var test = Plays.Where(p => p.CreatedAt >= earliest && p.CreatedAt <= latest).GroupBy(p => p.song.Id).Select(lg => new { songId = lg.Key, count = lg.Count() }).OrderByDescending(g => g.count).Join(Songs,h=>h.songId,j=>j.Id,(h,j)=>new {songName= j.Title, playsCount= h.count }).Take(limit).ToList();
           

            Console.Out.WriteLine("dokimi");
            
         

             
            
                    
            return test;


        }
        
        public dynamic GetHistory(int songId)
        {

            
            var res = Plays.Where(g => g.song.Id == songId).GroupBy(g => DbFunctions.TruncateTime(g.CreatedAt)).Select(lg=> new { date=lg.Key, count = lg.Count()}).OrderBy(lg=>lg.date).ToList();


            
            /*var songName = (from s in Songs
                            where s.Id == songId
                            select s.Title).Distinct();

            
            var res = (from p in Plays
                       where p.song.Equals(songName)
                       group p by p.CreatedAt into g
                       orderby g.Key
                       select new  { created = g.Key, count = g.Count() }
                       ).ToList();*/

            return res;
        }

        //ratings context


        public dynamic GetAverageBySong(int songId) {

             var res = Ratings.Where(p => p.song.Id == songId).Select(p=>p.RatingValue).Average();
           // var res = (from r in Ratings
                           // where r.Id == songId
             //          select r);
            //.Average();
            return res;

        }


        public dynamic GetBySongAndUser(int songId, string userId)
        {

            
            var res = Ratings.Where(p => p.UserId == userId && p.song.Id == songId).Select(p=>p.RatingValue).FirstOrDefault();
            return res;
        }


        public dynamic GetByUser(int userId) {
            var test = Ratings.Where(p => p.UserId == userId.ToString()).Select(p => new { songId = p.song.Id, rating =p.RatingValue }).ToList();
            return test;
        }

        /*public dynamic GetHistory(int rating, int songId) {
            var res = Ratings.Where(p => p.RatingValue == rating && p.song.Id == songId).ToList();
            return res;
        }*/



        public dynamic GetAverageHistory(int songId) {

            var res = Ratings.Where(p => p.song.Id == songId).GroupBy(g => DbFunctions.TruncateTime(g.CreatedAt)).Select(g => new { date = g.Key, average = g.Select(p => p.RatingValue).Average() }).ToList();

            return res;
        }

        public dynamic GetHistory(int rating, int songId) {
            var res = Ratings.Where(p => p.RatingValue == rating && p.song.Id == songId).GroupBy(p => p.CreatedAt).Select(p => new { date = p.Key, count = p.Select(g => g.RatingValue).Count() }).OrderBy(p => p.date).ToList();

            return res;
        }

        public dynamic GetForNUsers(int limit) {

            var res = Ratings.Select(p => p.UserId).Distinct().Take(limit).Join(Ratings, p=>p, c=>c.UserId, (p,c)=> new { userId = c.UserId, songId = c.song.Id, rating = c.RatingValue}).OrderBy(p=>p.userId).GroupBy(p=> p.userId).ToList();
            return res;
        }


        public IList<result> GetTopSongs1(DateTime? earliest, DateTime? latest, int limit)
        {


            IList<result> test = Ratings.Where(p => p.CreatedAt >= earliest && p.CreatedAt <= latest).GroupBy(p => p.song.Id).Select(lg => new { songId = lg.Key, average = lg.Select(p => p.RatingValue).Average() }).Join(Songs, h => h.songId, j => j.Id, (h, j) => new result { songName = j.Title, playsCount = h.average }).OrderByDescending(p=>p.playsCount).Take(limit).ToList();





            return test;


        }

    }

    public class result {
      /*  public result(string songName, decimal playsCount) {
            this.songName = songName;
            this.playsCount = playsCount;
        }*/

        public string songName { get; set; }
        public decimal playsCount { get; set; }

    }
}