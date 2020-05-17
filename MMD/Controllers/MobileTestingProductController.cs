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
    public class MobileTestingProductController : ControllerBase
    {
        private readonly IMobileTestingProductService _mobileTestingProductService;
        public MobileTestingProductController(IMobileTestingProductService mobileTestingProductService)
        {
            _mobileTestingProductService = mobileTestingProductService;
        }

        [HttpPost]
        public MobileTestingProduct CreateMobileTestingProduct(MobileTestingProduct mobileTestingProduct)
        {
            return _mobileTestingProductService.CreateMobileTestingProduct(mobileTestingProduct);
        }

        [HttpGet]

        public MobileTestingProduct GetMobileTestingProduct(int id)
        {
           return _mobileTestingProductService.GetMobileTestingProduct(id);
        }

        [HttpPut]

        public MobileTestingProduct UpdateMobileTestingProduct(UpdateMobileTestingProduct mobileTestingProduct)
        {
           return _mobileTestingProductService.UpdateMobileTestingProduct(mobileTestingProduct);
        }

        [HttpDelete]
        public void DeleteMobileTestingProduct (int id)
        {
            _mobileTestingProductService.DeleteMobileTestingProduct(id);
        }

    }
}