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
    public class GyroscopeController : ControllerBase
    {
        private readonly IGyroscopeService _gyroscopeService;
        public GyroscopeController(IGyroscopeService gyroscopeService)
        {
            _gyroscopeService = gyroscopeService;
        }

        [HttpPost]
        public Gyroscope CreateGyroscope(Gyroscope gyroscope)
        {
            return _gyroscopeService.CreateGyroscope(gyroscope);
        }

        [HttpGet]

        public Gyroscope GetGyroscope(string id)
        {
           return _gyroscopeService.GetGyroscope(id);
        }

        [HttpPut]

        public Gyroscope UpdateGyroscope(UpdateGyroscope gyroscope)
        {
           return _gyroscopeService.UpdateGyroscope(gyroscope);
        }

        [HttpDelete]
        public void DeleteGyroscope (string id)
        {
            _gyroscopeService.DeleteGyroscope(id);
        }

    }
}