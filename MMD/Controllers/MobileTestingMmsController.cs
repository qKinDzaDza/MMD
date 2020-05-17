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
    public class MobileTestingMmsController : ControllerBase
    {
        private readonly IMobileTestingMmsService _mobileTestingMmsService;
        public MobileTestingMmsController(IMobileTestingMmsService mobileTestingMmsService)
        {
            _mobileTestingMmsService = mobileTestingMmsService;
        }

        [HttpPost]
        public MobileTestingMms CreateMobileTestingMms(MobileTestingMms mobileTestingMms)
        {
            return _mobileTestingMmsService.CreateMobileTestingMms(mobileTestingMms);
        }

        [HttpGet]

        public MobileTestingMms GetMobileTestingMms(int id)
        {
           return _mobileTestingMmsService.GetMobileTestingMms(id);
        }

        [HttpPut]

        public MobileTestingMms UpdateMobileTestingMms(UpdateMobileTestingMms mobileTestingMms)
        {
           return _mobileTestingMmsService.UpdateMobileTestingMms(mobileTestingMms);
        }

        [HttpDelete]
        public void DeleteMobileTestingMms (int id)
        {
            _mobileTestingMmsService.DeleteMobileTestingMms(id);
        }

    }
}