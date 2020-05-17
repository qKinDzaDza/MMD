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
    public class CalibrationMmsController : ControllerBase
    {
        private readonly ICalibrationMmsService _calibrationMmsService;
        public CalibrationMmsController(ICalibrationMmsService calibrationMmsService)
        {
            _calibrationMmsService = calibrationMmsService;
        }

        [HttpPost]
        public CalibrationMms CreateCalibrationMms(CalibrationMms calibrationMms)
        {
            return _calibrationMmsService.CreateCalibrationMms(calibrationMms);
        }

        [HttpGet]

        public CalibrationMms GetCalibrationMms(int id)
        {
           return _calibrationMmsService.GetCalibrationMms(id);
        }

        [HttpPut]

        public CalibrationMms UpdateCalibrationMms(UpdateCalibrationMms calibrationMms)
        {
           return _calibrationMmsService.UpdateCalibrationMms(calibrationMms);
        }

        [HttpDelete]
        public void DeleteCalibrationMms (int id)
        {
            _calibrationMmsService.DeleteCalibrationMms(id);
        }

    }
}