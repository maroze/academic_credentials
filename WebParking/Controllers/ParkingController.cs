using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebParking.Service.Services;
using WebParking.Service.Services.Implementations;
using static System.Net.Mime.MediaTypeNames;
using WebParking.Data.Entities;
using WebParking.Common.ViewModels.LotParking;
using WebParking.Common.ViewModels.Parking;
using AutoMapper;
using Microsoft.AspNet.Identity;
using WebParking.Service.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebParking.Controllers
{
    [Route("api/parkings")]
    [ApiController]
    [Authorize]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkService;
        private readonly ILotService _lotService;
        private readonly IMapper _mapper;

        public ParkingController(IParkingService parkService, ILotService lotService, IMapper mapper)
        {
            _parkService = parkService;
            _lotService = lotService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение всех id парк. мест и их состояние(заблокированны)
        /// </summary>
        /// <param name="park"></param>
        /// <returns></returns>
        [HttpGet("lots/{id:int}/park")]
        public IActionResult GetLots([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            return Ok(_lotService.GetLots(id));
        }

        [HttpGet("lots/{id:int}")]
        public async Task<IActionResult> GetLotAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            var result = await _lotService.GetLot(id);

            return Ok(result);
        }
        /// <summary>
        /// Создание парк места
        /// </summary>
        /// <param name="park">парковка</param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost("lots")]
        public async Task<IActionResult> CreateLotAsync([FromBody] LotViewModel lot)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            var result = await _lotService.AddLot(_mapper.Map<LotViewModel>(lot));

            if (result == null)
                return BadRequest("Не удалось создать парковочное место");

            return StatusCode(201);
        }

        [HttpPut("lots")]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> UpdateLotAsync([FromBody] LotUpdateViewModel lot)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            var result = await _lotService.UpdateLot(lot);

            if (result == null)
                return BadRequest("Не удалось сохранить изменения");

            return Ok(result);
        }

        [HttpDelete("lots/{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteLotAsync([FromRoute] int id)
        {
            var delete = await _lotService.DeleteLot(id);

            if (delete == null)
                return BadRequest("Не удалось удалить парковочное место");

            return Ok();
        }
        /// <summary>
        /// Создание картинки, адреса и названия парковки
        /// </summary>
        /// <param name="park">парковка</param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost("parks")]
        public async Task<IActionResult> CreateParkingAsync([FromForm] ParkingViewModel park)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            var result = await _parkService.AddParking(park);

            if (result == null)
                return BadRequest("Не удалось создать парковку");

            return StatusCode(201);
        }

        /// <summary>
        /// Информация о названии и адресе парковки и картинка парковки
        /// </summary>
        /// <param name="id">парковка</param>
        /// <returns></returns>

        [HttpGet("parks/{id:int}")]
        public async Task<IActionResult> GetParkingAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            var result = await _parkService.GetParking(id);

            return Ok(result);
        }

        [HttpGet("parks/all")]
        public async Task<IActionResult> GetParkingsAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            return Ok(_parkService.GetParkins());
        }

        [HttpPut("parks")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateParkingAsync([FromForm] ParkingUpdateViewModel park)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            var result = await _parkService.UpdateParking(park);

            if (result == null)
                return BadRequest("Не удалось сохранить изменения");

            return Ok(result);
        }

        [HttpDelete("parks/{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteParkingAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Неверные данные запроса");

            var delete = await _parkService.DeleteParking(id);

            if (delete == null)
                return BadRequest("Не удалось удалить парковку");

            return Ok();
        }
    }
}
