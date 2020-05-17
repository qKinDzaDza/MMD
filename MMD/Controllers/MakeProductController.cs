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
    public class MakeProductController : ControllerBase
    {
        private readonly IMakeProductService _makeProductService;
        public MakeProductController(IMakeProductService makeProductService)
        {
            _makeProductService = makeProductService;
        }

        [HttpPost]
        public MakeProduct CreateMakeProduct(MakeProduct makeProduct)
        {
            return _makeProductService.CreateMakeProduct(makeProduct);
        }

        [HttpGet]

        public MakeProduct GetMakeProduct(string id)
        {
           return _makeProductService.GetMakeProduct(id);
        }

        [HttpPut]

        public MakeProduct UpdateMakeProduct(UpdateMakeProduct makeProduct)
        {
           return _makeProductService.UpdateMakeProduct(makeProduct);
        }

        [HttpDelete]
        public void DeleteMakeProduct (string id)
        {
            _makeProductService.DeleteMakeProduct(id);
        }

    }
}