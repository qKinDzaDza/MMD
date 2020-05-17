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
    public class StationaryTestingMmsController : ControllerBase
    {
        private readonly IStationaryTestingMmsService _stationaryTestingMmsService;
        public StationaryTestingMmsController(IStationaryTestingMmsService stationaryTestingMmsService)
        {
            _stationaryTestingMmsService = stationaryTestingMmsService;
        }

        [HttpPost]
        public StationaryTestingMms CreateStationaryTestingMms(StationaryTestingMms stationaryTestingMms)
        {
            return _stationaryTestingMmsService.CreateStationaryTestingMms(stationaryTestingMms);
        }

        [HttpGet]

        public StationaryTestingMms GetStationaryTestingMms(int id)
        {
           return _stationaryTestingMmsService.GetStationaryTestingMms(id);
        }

        [HttpPut]

        public StationaryTestingMms UpdateStationaryTestingMms(UpdateStationaryTestingMms stationaryTestingMms)
        {
           return _stationaryTestingMmsService.UpdateStationaryTestingMms(stationaryTestingMms);
        }

        [HttpDelete]
        public void DeleteStationaryTestingMms (int id)
        {
            _stationaryTestingMmsService.DeleteStationaryTestingMms(id);
        }

    }
}