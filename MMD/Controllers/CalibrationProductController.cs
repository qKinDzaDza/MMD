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
    public class CalibrationProductController : ControllerBase
    {
        private readonly ICalibrationProductService _calibrationProductService;
        public CalibrationProductController(ICalibrationProductService calibrationProductService)
        {
            _calibrationProductService = calibrationProductService;
        }

        [HttpPost]
        public CalibrationProduct CreateCalibrationProduct(CalibrationProduct calibrationProduct)
        {
            return _calibrationProductService.CreateCalibrationProduct(calibrationProduct);
        }

        [HttpGet]

        public CalibrationProduct GetCalibrationProduct(int id)
        {
           return _calibrationProductService.GetCalibrationProduct(id);
        }

        [HttpPut]

        public CalibrationProduct UpdateCalibrationProduct(UpdateCalibrationProduct calibrationProduct)
        {
           return _calibrationProductService.UpdateCalibrationProduct(calibrationProduct);
        }

        [HttpDelete]
        public void DeleteCalibrationProduct (int id)
        {
            _calibrationProductService.DeleteCalibrationProduct(id);
        }

    }
}