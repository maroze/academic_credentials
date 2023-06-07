using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebParking.Common.ViewModels.Booking;
using WebParking.Data.Repositories;
using WebParking.Service.Services;

namespace WebParking.Controllers
{
    [Route("api/booking")]
    [ApiController]
    //[Authorize]
    [AllowAnonymous]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("lots/{user:int}/book")]
        public async Task<IActionResult> GetUserBooksAsync([FromRoute] int user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");

                 return Ok( _bookingService.GetUserBooks(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("book")]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookingViewModel book)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");
                await _bookingService.AddBook(book);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("book")]
        public async Task<IActionResult> UpdateBookAsync([FromForm] ChangeBookingViewModel book)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");
                var update = await _bookingService.UpdateBook(book);
                if (update == null)
                    return BadRequest("Book doesn't update");
                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("book/{book:int}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] int book)
        {
            var delete = await _bookingService.DeleteBook(book);
            if (delete == null)
                return BadRequest("Book doesn't delete");
            return Ok();
        }
    }
}
