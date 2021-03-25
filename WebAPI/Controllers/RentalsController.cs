using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
         IRentalService _rentalService;

         public RentalsController(IRentalService rentalService)
         {
             _rentalService = rentalService;
         }


         [HttpPost("add")]
         public IActionResult Add(Rental rental)
         {
             var result = _rentalService.Add(rental);
             if (result.Success == true)
             {
                 return Ok(result);
             }

             return BadRequest(result);
         }

    }
}
