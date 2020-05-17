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
    public class ConsignmentController : ControllerBase
    {
        private readonly IConsignmentService _consignmentService;
        public ConsignmentController(IConsignmentService consignmentService)
        {
            _consignmentService = consignmentService;
        }

        [HttpPost]
        public Consignment CreateConsignment(Consignment consignment)
        {
            return _consignmentService.CreateConsignment(consignment);
        }

        [HttpGet]

        public Consignment GetConsignment(string id)
        {
           return _consignmentService.GetConsignment(id);
        }

        [HttpPut]

        public Consignment UpdateConsignment(UpdateConsignment consignment)
        {
           return _consignmentService.UpdateConsignment(consignment);
        }

        [HttpDelete]
        public void DeleteConsignment (string id)
        {
            _consignmentService.DeleteConsignment(id);
        }

    }
}