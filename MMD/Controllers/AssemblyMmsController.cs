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
    public class AssemblyMmsController : ControllerBase
    {
        private readonly IAssemblyMmsService _assemblyMmsService;
        public AssemblyMmsController(IAssemblyMmsService assemblyMmsService)
        {
            _assemblyMmsService = assemblyMmsService;
        }

        [HttpPost]
        public AssemblyMms CreateAssemblyMms(AssemblyMms assemblyMms)
        {
            return _assemblyMmsService.CreateAssemblyMms(assemblyMms);
        }

        [HttpGet]

        public AssemblyMms GetAssemblyMms(string id)
        {
           return _assemblyMmsService.GetAssemblyMms(id);
        }

        [HttpPut]

        public AssemblyMms UpdateAssemblyMms(UpdateAssemblyMms assemblyMms)
        {
           return _assemblyMmsService.UpdateAssemblyMms(assemblyMms);
        }

        [HttpDelete]
        public void DeleteAssemblyMms(string id)
        {
            _assemblyMmsService.DeleteAssemblyMms(id);
        }

    }
}