using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_LZS.Models;

namespace WebAPI_LZS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _dbContext;

        public BookController(BookContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
