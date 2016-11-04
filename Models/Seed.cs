using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


public static class Seed
{
    public static void Initialize(IGram grams)
    {
        public static void Initialize(DB db, bool isDevEnvironment)
    {
        if(isDevEnvironment){
            // db.Database.EnsureDeleted(); // delete then, ...
        }

        db.Database.EnsureCreated(); // create the tables!!
        db.Database.Migrate(); // ensure migrations are registered
        
      //  if(repo.Likes.Any() || repo.Comments.Any()) return; // if there were any likes or comments, you would return the gram that those likes/comments were associated with 
        Gram gram = new Gram { ImageURL = "", Id = 0, }; 
        Gram g1 = new Gram { ImageURL = "http://bjstlh.com/data/wallpapers/165/WDF_2048218.png", Id = 0, };
        Gram g2 = new Gram { ImageURL = "https://files.slack.com/files-pri/T03FAV5N3-F2VHHAW1Z/mobile_mafia.jpg", Id = 0, };
        Gram g3 = new Gram { ImageURL = "http://landing.theironyard.com/images/home/tiy-logo.png", Id = 0, };

        Gram g4 = new Gram { ImageURL = "https://avatars0.githubusercontent.com/u/9850596?v=3&s=466", Id = 0, };
        Gram g5 = new Gram { ImageURL = "https://pbs.twimg.com/profile_images/713487228647956485/yjPRr0RZ.jpg", Id = 0, };
        Gram g6 = new Gram { ImageURL = "https://d262ilb51hltx0.cloudfront.net/fit/c/1024/1024/1*s4su3PQZdpO5vfBjehbJWw.png", Id = 0, };

        Gram g7 = new Gram { ImageURL = "https://avatars1.githubusercontent.com/u/18193236?v=3&s=466", Id = 0, };
        Gram g8 = new Gram { ImageURL = "https://pbs.twimg.com/profile_images/639810493314498560/1l0COtFf.jpg", Id = 0, };
        Gram g9 = new Gram { ImageURL = "https://media.licdn.com/mpr/mpr/shrinknp_200_200/AAEAAQAAAAAAAAUIAAAAJDRmYmM4NzM3LWI2MTctNGU5MC05OTkyLThjODllNWExOWIxMA.jpg", Id = 0, };
        
        Like l = new Like { Id = 0, GramId = 0, };
        Comment c = new Comment { Message = "", Id = 0, GramId = 0, };

            gram.Add(g1);
            gram.Add(g2);
            gram.Add(g3);
            gram.Add(g4);
            gram.Add(g5);
            gram.Add(g6);
            gram.Add(g7);
            gram.Add(g8);
            gram.Add(g9);


            
            
        //  Action createLike = () => {
      //      Like l = new Like { Id = 0, };
            

        // for(var i = 0; i < 10; i++)
        //        l.Likes.Add(new Like { Id = 0, });
        
        
  //   g.Grams.Add(new Comment { Id = 0, Message = "Test Comment"});
        
 //      };

  //      for(var j = 0; j<3; j++)
  //          createList();
        
    
      //  db.Likes.Add(l);
      //  db.Comments.Add(c);
      //  db.SaveChanges(); 
        Console.WriteLine("----------CARDS SEEDED-------------");
    
    public partial class DB : DbContext {
        public DbSet<Gram> Grams { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}