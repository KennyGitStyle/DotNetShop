using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BugTrackerController : BaseApiController
    {
        private readonly StoreContext _context;
        public BugTrackerController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var check = _context.Products.Find(32);
            if (check == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();

        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var check = _context.Products.Find(34);

            var checkingServer = check.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest() => BadRequest(new ApiResponse(400));

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}