using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMD.Domain.Model;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;

namespace MMD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccelerometerController : ControllerBase
    {
        private readonly IAccelerometerService _accelerometerService;
        public AccelerometerController(IAccelerometerService accelerometerService)
        {
            _accelerometerService = accelerometerService;
        }

        [HttpPost]
        public Accelerometer CreateAccelerometer(Accelerometer accelerometer)
        {
            return _accelerometerService.CreateAccelerometer(accelerometer);
        }

        [HttpGet]

        public Accelerometer GetAccelerometer(string id)
        {
           return _accelerometerService.GetAccelerometer(id);
        }

        [HttpPut]

        public Accelerometer UpdateAccelerometer(UpdateAccelerometer accelerometer)
        {
           return _accelerometerService.UpdateAccelerometer(accelerometer);
        }

        [HttpDelete]
        public void DeleteAccelerometer (string id)
        {
            _accelerometerService.DeleteAccelerometer(id);
        }

    }
}