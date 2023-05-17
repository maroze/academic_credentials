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
    //    private readonly IParkingService _parkService;

    //    public ParkingController(IParkingService parkService)
    //    {
    //        _parkService = parkService;
    //    }
    //    /// <summary>
    //    /// Таймер для разбронирования места
    //    /// </summary> 
    //    /// <param name="user"></param>
    //    /// <returns></returns>

        

    //    /// <summary>
    //    /// Получение всех id парк. мест и их состояние(заблокированны)
    //    /// </summary>
    //    /// <param name="park"></param>
    //    /// <returns></returns>
    //    [HttpPost("getparkslot")]
    //    public IActionResult GetLots([FromForm] ParkingViewModel park)
    //    {
    //        try
    //        {
    //            if (!ModelState.IsValid)
    //                return BadRequest("Invalid request data");


    //            return Ok();
    //        }
    //        catch (Exception e)
    //        {
    //            return BadRequest(e.Message);
    //        }
    //    }

    //    /// <summary>
    //    /// Получение id парк. места, название, пользователя
    //    /// </summary>
    //    /// <param name="user"></param>
    //    /// <returns></returns>
    //    [HttpPost("booklot")]
    //    public IActionResult BookLot([FromForm] ParkingViewModel park)
    //    {
    //        try
    //        {
    //            if (!ModelState.IsValid)
    //                return BadRequest("Invalid request data");


    //            return Ok();
    //        }
    //        catch (Exception e)
    //        {
    //            return BadRequest(e.Message);
    //        }
    //    }

    //    /// <summary>
    //    /// Вывод адреса, места и времени парковки забронированной пользователем
    //    /// </summary>
    //    /// <param name="park"></param>
    //    /// <returns></returns>
    //    [HttpPost("getlot")]
    //    public IActionResult GetLot([FromForm] ParkingViewModel park)
    //    {
    //        try
    //        {
    //            if (!ModelState.IsValid)
    //                return BadRequest("Invalid request data");


    //            return Ok();
    //        }
    //        catch (Exception e)
    //        {
    //            return BadRequest(e.Message);
    //        }
    //    }

    //    /// <summary>
    //    /// Получение картинки, адреса и названия парковки
    //    /// </summary>
    //    /// <param name="park">парковка</param>
    //    /// <returns></returns>
    //    [HttpPost("imagepark")]
    //    public IActionResult CreateParkingImg([FromForm] ParkingViewModel park)
    //    {
    //        try
    //        {
    //            if (!ModelState.IsValid)
    //                return BadRequest("Invalid request data");


    //            return Ok();
    //        }
    //        catch (Exception e)
    //        {
    //            return BadRequest(e.Message);
    //        }
    //    }
        
    //    /// <summary>
    //    /// Информация о названии и адресе парковки и картинка парковки
    //    /// </summary>
    //    /// <param name="park">парковка</param>
    //    /// <returns></returns>
    //    [HttpGet("getimage")]
    //    public IActionResult GetParkingImg([FromForm] ParkingViewModel park)
    //    {
    //        try
    //        {
    //            if (!ModelState.IsValid)
    //                return BadRequest("Invalid request data");


    //            return Ok();
    //        }
    //        catch (Exception e)
    //        {
    //            return BadRequest(e.Message);
    //        }
    //    }
    }
}
