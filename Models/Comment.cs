using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public interface IComment : HasId
{
    void Create(Comment c);           // POST
    Comment Read(int id);    // GET
    Comment Update(Comment c, int id);     // PUT
    void Delete(int id);     // DELETE
}

public class Comment : IComment {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Message { get; set; }
    [Required]
    public string ByUser { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Required]
    public int GramId { get; set; }
    
    public int CommentCount = 0;


    public Comment(int Id, string Message, string ByUser, DateTime CreatedAt, int PostId){
        this.Id = Id;
        this.Message = Message;
        this.ByUser = ByUser;
        this.CreatedAt = CreatedAt;
        this.GramId = GramId;
    }

    public void Create(Comment c){
        c.CommentCount++;
        c.CreatedAt = DateTime.Now;
        comments.Add(c);
    }


    public Comment Read(int id){
        return comments.First(c => c.Id == id);
    }

    public Comment Update(Comment c, int id){
        var commentToUpdate = comments.First(c => c.Id == id);
        if (commentToUpdate != null){
            comments.Remove(commentToUpdate);
            comments.Add(c);
            return c;
        }
        return null;
    }

    public void Delete(int id){
        var comment = comments.First(c => c.Id == id);
        if (comment != null){
            comments.Remove(comment);
        }
    }
}

