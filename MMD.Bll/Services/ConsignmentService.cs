using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Linq;

namespace MMD.Bll
{
    public class ConsignmentService : IConsignmentService
    
    {
        private readonly IConsignmentRepository _consignmentRepository;
        private readonly IAssemblyMmsService _assemblyMmsService;

        public ConsignmentService(IConsignmentRepository consignmentRepository,
            IAssemblyMmsService assemblyMmsService)
        {
            _consignmentRepository = consignmentRepository;
            _assemblyMmsService = assemblyMmsService;
        }

        public Consignment CreateConsignment(Consignment consignment)
        {
            if (consignment.AssemblyMmsIds != null)
            {
                var assemblyMmses = _assemblyMmsService
                    .GetAssemblyMmsByIds(consignment.AssemblyMmsIds);
                if (assemblyMmses.Any(a => a.Consignment!= null)) throw new Exception();
                consignment.AssemblyMms = assemblyMmses;
            }
            return _consignmentRepository.CreateConsignment(consignment);
        }

        public void DeleteConsignment(string id)
        {
            _consignmentRepository.DeleteConsignment(id);
        }

        public Consignment GetConsignment(string id)
        {
            return _consignmentRepository.GetConsignment(id);
        }

        public Consignment UpdateConsignment(UpdateConsignment updateConsignment)
        {
            if (updateConsignment.AssemblyMmsIds != null)
            {
                var assemblyMmses = _assemblyMmsService
                    .GetAssemblyMmsByIds(updateConsignment.AssemblyMmsIds);
                if (assemblyMmses.Any(a => a.Consignment != null)) throw new Exception();
                updateConsignment.AssemblyMms = assemblyMmses;
            }
            return _consignmentRepository.UpdateConsignment(updateConsignment);
        }
    }
}
