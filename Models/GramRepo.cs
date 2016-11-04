using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
public interface IGram  {
    Gram Create(Gram gram);
    Gram Get(int id);
    List<Gram> GetAll();
    Gram Edit(Gram gram, int id);
    void Delete(int id);
    void Add(Gram grams);
}
public class Gram : IGram {
    public int Id { get; set; } = 0;
    [Required]
    public string ImageURL { get; set; }
    [Required]
    public DateTime createdAt { get; set; }
    [Required]
    public List<Like> Likes { get; set; }
    [Required]
    [StringLengthAttribute(250)]
    public List<Comment> Comments { get; set; }
    [StringLength(250)]
    public string Message { get; set; } 
    public string Title { get; set; }
    private int GramCount = 0;
    List<Gram> grams = new List<Gram>();
    public void Add(Gram grams){
        grams.Id = GramCount++;
        grams.createdAt = DateTime.Now;
        grams.Add(grams);
    }
    public Gram Get(int id){
        return grams.First(x => x.Id == id);
        
    }
    public List<Gram> GetAll() {
        return grams;
    }
    public Gram Edit(Gram gram, int id){
        var gramToUpdate = grams.First(x => x.Id == id);
        if(gramToUpdate != null) {
            grams.Remove(gramToUpdate);
            gram.Id = id;
            grams.Add(gram);
            return gram;
        }
        return null;
    }
    public void Delete(int id){
          var gramToDelete = grams.First(x => x.Id == id);
        if(gramToDelete != null) {
            grams.Remove(gramToDelete);
        }
    }
   public Gram Create(Gram gram){
        grams.Add(gram);
        return gram;
    }

    
}