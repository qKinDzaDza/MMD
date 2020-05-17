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
    public class ConfiguringMmsController : ControllerBase
    {
        private readonly IConfiguringMmsService _configuringMmsService;
        public ConfiguringMmsController(IConfiguringMmsService configuringMmsService)
        {
            _configuringMmsService = configuringMmsService;
        }

        [HttpPost]
        public ConfiguringMms CreateConfiguringMms(ConfiguringMms configuringMms)
        {
            return _configuringMmsService.CreateConfiguringMms(configuringMms);
        }

        [HttpGet]

        public ConfiguringMms GetConfiguringMms(int id)
        {
           return _configuringMmsService.GetConfiguringMms(id);
        }

        [HttpPut]

        public ConfiguringMms UpdateConfiguringMms(UpdateConfiguringMms configuringMms)
        {
           return _configuringMmsService.UpdateConfiguringMms(configuringMms);
        }

        [HttpDelete]
        public void DeleteConfiguringMms (int id)
        {
            _configuringMmsService.DeleteConfiguringMms(id);
        }

    }
}