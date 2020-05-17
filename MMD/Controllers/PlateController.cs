using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMD.Domain.Model;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using OfficeOpenXml;

namespace MMD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateController : ControllerBase
    {
        private readonly IPlateService _plateService;
        public PlateController(IPlateService plateService)
        {
            _plateService = plateService;
        }

        [HttpPost]
        public Plate CreatePlate(Plate plate)
        {
            return _plateService.CreatePlate(plate);
        }

        [HttpPost("excel")]
        public Plate CreatePlate(IFormFile file)
        {
            var excel = new ExcelPackage(file.OpenReadStream());
            return _plateService.CreatePlate(new Plate());
        }

        [HttpGet]
        public Plate GetPlate(string id)
        {
           return _plateService.GetPlate(id);
        }

        [HttpPut]
        public Plate UpdatePlate(UpdatePlate plate)
        {
           return _plateService.UpdatePlate(plate);
        }

        [HttpDelete]
        public void DeletePlate (string id)
        {
            _plateService.DeletePlate(id);
        }

    }
}