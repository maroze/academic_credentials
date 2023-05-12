using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebParking.Service.Services;
using WebParking.Service;
using Library.Common.ViewModels;
using WebParking.Service.Services.Implementations;
using static System.Net.Mime.MediaTypeNames;
using WebParking.Data.Entities;

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

        //    [HttpPost("image")]
        //    public IActionResult CreateParking([FromForm] ParkingViewModel park)
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
        //}
    }
}