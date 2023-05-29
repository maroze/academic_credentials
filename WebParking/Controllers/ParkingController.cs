using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebParking.Service.Services;
using WebParking.Service;
using Library.Common.ViewModels;
using WebParking.Service.Services.Implementations;
using static System.Net.Mime.MediaTypeNames;
using WebParking.Data.Entities;
using WebParking.Common.ViewModels;

namespace WebParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkService;
        private readonly ILotService _lotService;

        public ParkingController(IParkingService parkService, ILotService lotService)
        {
            _parkService = parkService;
            _lotService = lotService;
        }


        /// <summary>
        /// Получение всех id парк. мест и их состояние(заблокированны)
        /// </summary>
        /// <param name="park"></param>
        /// <returns></returns>
        [HttpGet("getparkslot")]
        public IActionResult GetLots([FromForm] LotViewModel lot)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");

                return Ok(_lotService.GetLots());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Получение id парк. места, название, пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("booklot")]
        public IActionResult BookLot([FromForm] int lot)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");
                var result = _lotService.BookLot(lot);
                if (result == null)
                    return BadRequest("Lot unavailable for book");
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Вывод адреса, места и времени парковки забронированной пользователем
        /// </summary>
        /// <param name="park"></param>
        /// <returns></returns>
        [HttpGet("getlot")]
        public IActionResult GetLot([FromForm] int lot)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");
                var result = _lotService.GetLot(lot);
                if (result == null)
                    return BadRequest("Lot doesn't exists");
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        ///// <summary>
        ///// Создание парк места
        ///// </summary>
        ///// <param name="park">парковка</param>
        ///// <returns></returns>
        //[HttpPost("create_lot")]
        //public async Task<IActionResult> CreateLotAsync([FromForm] LotViewModel lot, int idpark)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest("Invalid request data");
        //        var park = await _parkService.GetParking(idpark);
        //        if (park == null)
        //            return BadRequest("Парковки с таким id не существует");
        //        else
        //        {
        //            var result = await _lotService.AddLot(lot, idpark);
        //            return Ok();
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        /// <summary>
        /// Создание картинки, адреса и названия парковки
        /// </summary>
        /// <param name="park">парковка</param>
        /// <returns></returns>
        [HttpPost("create_imagepark")]
        public IActionResult CreateParkingImg([FromForm] ParkingViewModel park)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");

                var result = _parkService.AddParking(park);
                if (result == null)
                {
                    return BadRequest("Parking doesn't create");
                }
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Информация о названии и адресе парковки и картинка парковки
        /// </summary>
        /// <param name="parkId">парковка</param>
        /// <returns></returns>
        [HttpGet("getimage")]
        public async Task<IActionResult> GetParkingImgAsync([FromForm] int parkId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");
                var result = await _parkService.GetParking(parkId);
                if (result == null)
                {
                    return BadRequest("Parking doesn't exists");
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
