using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("/")]
public class HomeController : Controller
{
    private IRepository<Gram> grams;
    private IRepository<Like> likes;
    private IRepository<Comment> comments;
    public HomeController(IRepository<Gram> grams, IRepository<Like> likes, IRepository<Comment> comments){
        this.grams = grams;
        this.likes = likes;
        this.comments = comments;
    }

    [HttpGet("/{username?}")]
    [HttpGet("Home/Index/{username?}")]
    public IActionResult Root(string username = "you")
    {
        ViewData["Message"] = "Some extra info can be sent to the view";
        ViewData["Username"] = username;
        return View("Index"); // View(new Student) method takes an optional object as a "model", typically called a ViewModel
    }

    // [HttpGet("sql/cards")] // ?sql=....
    // public IActionResult SqlCards([FromQuery]string sql) => Ok(cards.FromSql(sql));

    // [HttpGet("sql/lists")] // ?sql=....
    // public IActionResult SqlLists([FromQuery]string sql) => Ok(lists.FromSql(sql));

    // [HttpGet("sql/boards")] // ?sql=....
    // public IActionResult SqlBoards([FromQuery]string sql) => Ok(boards.FromSql(sql));
}