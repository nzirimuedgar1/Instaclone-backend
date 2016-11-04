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
        if(isDevEnvironment){
            repo.Database.EnsureDeleted(); // delete then, ...
        }

        repo.Database.EnsureCreated(); // create the tables!!
        // db.Database.Migrate(); // ensure migrations are registered (sqlite/postgres only, won't work with in-memory db)
        
        if(repo.Likes.Any() || repo.Comments.Any()) return; // if there were any likes or comments, you would return the gram that those likes/comments were associated with 
        Gram g = new Gram { ImageURL = "", Id = 0, }; 
        Like l = new Like { Id = 0, GramId = 0, };
        Comment c = new Comment { Message = "", Id = 0, GramId = 0, };

        grams.First(x => x.GramId == GramId);
        
        Action createGram = () => {
            
           
            for(var i = 0; i < 10; i++)
            repo.Add( new Gram { ImageURL = "http://bjstlh.com/data/wallpapers/165/WDF_2048218.png", Id = 0, });

            
            
        //  Action createLike = () => {
      //      Like l = new Like { Id = 0, };
            

        // for(var i = 0; i < 10; i++)
        //        l.Likes.Add(new Like { Id = 0, });
        
        
  //   g.Grams.Add(new Comment { Id = 0, Message = "Test Comment"});
        
 //      };

  //      for(var j = 0; j<3; j++)
  //          createList();
        
        db.Grams.Add(g);
        db.Likes.Add(l);
        db.Comments.Add(c);
        db.SaveChanges(); 
        Console.WriteLine("----------CARDS SEEDED-------------");
    
    public partial class DB : DbContext {
        public DbSet<Gram> Grams { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}