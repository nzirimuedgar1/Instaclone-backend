using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

public interface HasId {
    int Id { get; set; }
}

public interface ICommentRepo : HasId { 
    Comment Create(Comment comment);
    Comment Read(int id);
    Comment Update(Comment comment, int id);
    void Delete(int id);
}

public class CommentRepo : ICommentRepo {

    [Required]
    public int Id { get; set; }
    [Required]
    public string Message { get; set; }
    [Required]
    public string ByUser { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Required]
    public int PostId { get; set; }


    public CommentRepo(int Id, string Message, string ByUser, DateTime CreatedAt, int PostId){
        this.Id = new Random().Next();
        this.Message = Message;
        this.ByUser = ByUser;
        this.CreatedAt = CreatedAt;
        this.GramId = GramId;
    }

    public Comment Create(Comment c){
        Comments.Add(c);
        return c;
    }


    public Comment Read(int id){
        return Comments.First(c => c.Id == id);
    }

    public Comment Update(Comment c, int id){
        var commentToUpdate = comments.First(c => c.Id == id);
        if (commentToUpdate != null){
            Comments.Remove(commentToUpdate);
            Comments.Add(c);
            return c;
        }
        return null;
    }

    public void Delete(int id){
        var comment = Comments.First(c => c.Id == id);
        if (comment != null){
            Comments.Remove(comment);
        }
    }

    
    // // CRUD stuff
    // public T Create(T item){
    //     dbtable.Add(item);
    //     db.SaveChanges();
    //     return table.First(x => x.Id == item.Id);
    // }

    // public IEnumerable<T> Read(){
    //     return table.ToList();
    // }
    
    // public IEnumerable<T> Read(Func<DbSet<T>, IEnumerable<T>> fn){
    //     return fn(dbtable).ToList();
    // }
    
    // public T Read(int id){
    //     return table.First(x => x.Id == id);
    // }
    
    // public bool Update(T item){
    //     T actual = table.First(x => x.Id == item.Id);
    //     if(actual != null) {
    //         dbtable.Remove(actual);
    //         item.Id = actual.Id;
    //         dbtable.Add(item);
    //         db.SaveChanges();
    //         return true;
    //     }
    //     return false;
    // }
    
    // public T Delete(int id){
    //     T actual = table.First(x => x.Id == id);
    //     if(actual != null) {
    //         dbtable.Remove(actual);
    //         db.SaveChanges();
    //         return actual;
    //     }
    //     return null;
    // }

}
