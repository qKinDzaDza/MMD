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
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpPost]
        public Warehouse CreateWarehouse(Warehouse warehouse)
        {
            return _warehouseService.CreateWarehouse(warehouse);
        }

        [HttpGet]

        public Warehouse GetWarehouse(int id)
        {
           return _warehouseService.GetWarehouse(id);
        }

        [HttpPut]

        public Warehouse UpdateWarehouse(UpdateWarehouse warehouse)
        {
           return _warehouseService.UpdateWarehouse(warehouse);
        }

        [HttpDelete]
        public void DeleteWarehouse (int id)
        {
            _warehouseService.DeleteWarehouse(id);
        }

    }
}