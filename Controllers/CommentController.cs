using System;
using Microsoft.AspNetCore.Mvc;


[Route("/api/comment")]
class CommentController : Controller {

    private ICommentRepo comments;

    public void ICommentRepo(ICommentRepo c){
        comments = c;
    }

    [HttpGet]
    public IActionResult GetAll(){
        return Ok(comments);
    }

    [HttpPost]
    public IActionResult Post([FromBody]Comment comment){
        if(!ModelState.IsValid)
            return BadRequest(ModelState.ToErrorObject());
        return Ok(comments.Create(comment));
    }


    [HttpGet("{id}")]
    public IActionResult Get(int id){
        var comment = comments.Read(id);
        if(comment == null)
            return NotFound();
        return Ok(comment);
    }


    [HttpPut("{id}")]
    public IActionResult Put([FromBody] Comment comment, int id){
        comment = comment.Read(id);
        if (comment != null)
            return Ok(comment.Update(comment, id));

        return BadRequest(ModelState.ToErrorObject());
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var comment = comments.Read(id);
        if(comment != null)
            comments.Delete(id);
            return Ok(comments);
        return BadRequest(ModelState.ToErrorObject());
    }

}