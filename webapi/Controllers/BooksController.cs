using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Identity;

namespace webapi.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class BooksController : ControllerBase
{
    private const string TokenSecret = "this is my custom Secret key for authentication";
    private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(8);
    private const string AdminEmail = "admin@bookstore.com";

    private IBookRepository _repo;
    public BooksController(IBookRepository repo)
    {
        _repo = repo;

    }

    [HttpGet(Name = "Get")]
    public IEnumerable<Book> Get(string title=null, int? priceFrom = null, int? priceTo = null)
   {
        return _repo.GetAllBooks(title,priceFrom,priceTo)
        .ToArray();
    }
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpPost(Name = "Save")]
    public void Save(Book book)
    {
        _repo.AddOrUpdateBook(book);
    }
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpDelete(Name = "Delete/{*id:int}")]
    public void Delete(int id)
    {
        _repo.DeleteBook(id);
    }
}
