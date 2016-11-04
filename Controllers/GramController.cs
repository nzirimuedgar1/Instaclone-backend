using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

[Route("api/gram")]
class GramController : Controller {
protected IGram grams;  
public GramController(IGram g){ 
        grams = g;
}
[HttpGet]
public IActionResult GetAll() {
    return Ok(grams);
}
[HttpGet("{id}")]
public IActionResult Get(int id) {
    var gram = grams.Get(id);
    return Ok(gram);
}
[HttpGetAttribute("/search/{term}")]

[HttpGet("search")]
    public IActionResult Search([FromQuery]string term, int id = -1){
        return Ok(grams.Where(g => 
            g.Title.IndexOf(term) != -1)
           //  && grams.Id == id
        );
    }

[HttpPost]
 public IActionResult Create(Gram g) { 
        if(!ModelState.IsValid)
            return BadRequest(ModelState.ToErrorObject());

        return Ok(grams.Create(g)); 
    }

[HttpDelete("{id}")]
public IActionResult Delete(int id){
        var gram = grams.Get(id);
        if(gram != null)
            return NotFound();

        grams.Delete(id);
        return Ok();
    
    }

[HttpPut("{id}")]

public IActionResult Update(Gram g, int id) {
        
        var gram = grams.Get(id);
        if(gram != null)
            return NotFound();

        
        return Ok(gram.Edit(gram, id));
    }
}
