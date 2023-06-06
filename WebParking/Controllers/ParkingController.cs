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
        [HttpGet]
        [Route("lots/{parkId:int}/all")]
        public IActionResult GetLots([FromRoute] int parkId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");

                return Ok(_lotService.GetLots(parkId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

       
        [HttpGet]
        [Route("lots/{lot:int}")]
        public async Task<IActionResult> GetLotAsync([FromRoute] int lot)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");
                var result = await _lotService.GetLot(lot);
                if (result == null)
                    return BadRequest("Lot doesn't exists");
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Создание парк места
        /// </summary>
        /// <param name="park">парковка</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        [Route("lots")]
        public async Task<IActionResult> CreateLotAsync([FromBody] LotViewModel lot)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");
                var result = await _lotService.AddLot(_mapper.Map<LotViewModel>(lot));
                if (result == null)
                {
                    return BadRequest("doesn't create");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("lots")]
        public async Task<IActionResult> UpdateLotAsync([FromBody] LotUpdateViewModel lot)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");
                var result = await _lotService.UpdateLot(lot);
                if (result == null)
                {
                    return BadRequest("Parking doesn't update");
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("lots/{lotId:int}")]
        public async Task<IActionResult> DeleteLotAsync([FromRoute] int lotId)
        {
            var delete = await _lotService.DeleteLot(lotId);
            if (delete == null)
                return BadRequest("Lot doesn't delete");
            return Ok();
        }
        /// <summary>
        /// Создание картинки, адреса и названия парковки
        /// </summary>
        /// <param name="park">парковка</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("parks")]
        public async Task<IActionResult> CreateParkingAsync([FromForm] ParkingViewModel park)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");

                var result = await _parkService.AddParking(park);
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
        
        [HttpGet]
        [Route("parks/{parkId:int}")]
        public async Task<IActionResult> GetParkingAsync([FromRoute] int parkId)
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

        [HttpGet]
        [Route("parks/all")]
        public async Task<IActionResult> GetParkingsAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");

                return Ok(_parkService.GetParkins());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("parks/{parkId:int}")]
        public async Task<IActionResult> UpdateParkingAsync([FromBody] ParkingViewModel park)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid request data");
                var result = await _parkService.UpdateParking(park);
                if (result == null)
                {
                    return BadRequest("Parking doesn't update");
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("parks/{parkId:int}")]
        public async Task<IActionResult> DeleteParkingAsync([FromRoute] int parkId)
        {
            var delete = await _parkService.DeleteParking(parkId);
            if (delete == null)
                return BadRequest("Parking doesn't delete");
            return Ok();
        }
    }
}
