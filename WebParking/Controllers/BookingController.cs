using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebParking.Common.ViewModels.Booking;
using WebParking.Data.Repositories;
using WebParking.Service.Services;

namespace WebParking.Controllers
{
    [Route("api/booking")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IAccountService _accontService;
        public BookingController(IBookingService bookingService, IAccountService accontService)
        {
            _bookingService = bookingService;
            _accontService = accontService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetUserBooksAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            string jwt = Request.Headers.Authorization.ToString();
            string[] jwtArray = jwt.Split('.');
            //Decode from base64 string
            string jsonString = System.Text.Encoding.Default.GetString(Convert.FromBase64String(jwtArray[1].PadRight(jwtArray[1].Length + (jwtArray[1].Length * 3) % 4, '=')));
            //convert json to key value pair
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

            var user = await _accontService.GetUserByEmail(values["email"]);

            return Ok( _bookingService.GetUserBooks(user.UserId));
        }

        [HttpPost()]
        public async Task<IActionResult> CreateBookAsync([FromBody] CreateBookingViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            string jwt = Request.Headers.Authorization.ToString();
            string[] jwtArray = jwt.Split('.');
            //Decode from base64 string
            string jsonString = System.Text.Encoding.Default.GetString(Convert.FromBase64String(jwtArray[1].PadRight(jwtArray[1].Length + (jwtArray[1].Length * 3) % 4, '=')));
            //convert json to key value pair
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

            var user = await _accontService.GetUserByEmail(values["email"]);

            BookingViewModel book = new BookingViewModel() { EndBookedTime = model.EndBookedTime, StartBookedTime =model.StartBookedTime, IdLots = model.IdLots, IdUsers= user.UserId };

            await _bookingService.AddBook(book);

            return StatusCode(201);
        }

        [HttpDelete("{id:int}/book")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            var delete = await _bookingService.DeleteBook(id);

            if (delete == null)
                return BadRequest("Не удалось удалить бронь");

            return Ok();
        }
    }
}
