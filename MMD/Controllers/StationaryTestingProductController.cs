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
    public class StationaryTestingProductController : ControllerBase
    {
        private readonly IStationaryTestingProductService _stationaryTestingProductService;
        public StationaryTestingProductController
            (IStationaryTestingProductService stationaryTestingProductService)
        {
            _stationaryTestingProductService = stationaryTestingProductService;
        }

        [HttpPost]
        public StationaryTestingProduct CreateStationaryTestingProduct
            (StationaryTestingProduct stationaryTestingProduct)
        {
            return _stationaryTestingProductService
                .CreateStationaryTestingProduct(stationaryTestingProduct);
        }

        [HttpGet]

        public StationaryTestingProduct GetStationaryTestingProduct(int id)
        {
           return _stationaryTestingProductService.GetStationaryTestingProduct(id);
        }

        [HttpPut]

        public StationaryTestingProduct UpdateStationaryTestingProduct
            (UpdateStationaryTestingProduct stationaryTestingProduct)
        {
           return _stationaryTestingProductService.UpdateStationaryTestingProduct
                (stationaryTestingProduct);
        }

        [HttpDelete]
        public void DeleteStationaryTestingProduct (int id)
        {
            _stationaryTestingProductService.DeleteStationaryTestingProduct(id);
        }

    }
}