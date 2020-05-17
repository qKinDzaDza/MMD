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
    public class ConfiguringProductController : ControllerBase
    {
        private readonly IConfiguringProductService _configuringProductService;
        public ConfiguringProductController(IConfiguringProductService configuringProductService)
        {
            _configuringProductService = configuringProductService;
        }

        [HttpPost]
        public ConfiguringProduct CreateConfiguringProduct(ConfiguringProduct configuringProduct)
        {
            return _configuringProductService.CreateConfiguringProduct(configuringProduct);
        }

        [HttpGet]

        public ConfiguringProduct GetConfiguringProduct(int id)
        {
           return _configuringProductService.GetConfiguringProduct(id);
        }

        [HttpPut]

        public ConfiguringProduct UpdateConfiguringProduct(UpdateConfiguringProduct configuringProduct)
        {
           return _configuringProductService.UpdateConfiguringProduct(configuringProduct);
        }

        [HttpDelete]
        public void DeleteConfiguringProduct (int id)
        {
            _configuringProductService.DeleteConfiguringProduct(id);
        }

    }
}