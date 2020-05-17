using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MMD.Bll.Services
{
    public class AssemblyMmsService : IAssemblyMmsService
    {
        private readonly IAssemblyMmsRepository _assemblyMmsRepository;
        private readonly IAccelerometerRepository _accelerometerRepository;
        private readonly IGyroscopeRepository _gyroscopeRepository;
        private readonly IConfiguringMmsService _configuringMmsService;
        private readonly IMakeProductService _makeProductService;
        private readonly IAuthorRepository _authorRepository;
        private readonly IConsignmentRepository _consignmentRepository;

        public AssemblyMmsService(
            IAssemblyMmsRepository assemblyMmsRepository,
            IAccelerometerRepository accelerometerRepository,
            IGyroscopeRepository gyroscopeRepository,
            IConfiguringMmsService configuringMmsService,
            IMakeProductService makeProductService,
            IAuthorRepository authorRepository,
            IConsignmentRepository consignmentRepository)
        {
            _assemblyMmsRepository = assemblyMmsRepository;
            _accelerometerRepository = accelerometerRepository;
            _gyroscopeRepository = gyroscopeRepository;
            _configuringMmsService = configuringMmsService;
            _makeProductService = makeProductService;
            _authorRepository = authorRepository;
            _consignmentRepository = consignmentRepository;
    }

        public AssemblyMms CreateAssemblyMms(AssemblyMms assemblyMms)
        {
            if((assemblyMms.AccelerometerId != null && assemblyMms.GyroscopeId != null) ||
               (assemblyMms.AccelerometerId is null && assemblyMms.GyroscopeId is null))
            {
                throw new ArgumentException($"Please, enter ID Accelerometer or Gyroscope ");
            }
            if (assemblyMms.AccelerometerId != null)
            {
                var accelerometer = _accelerometerRepository
                    .GetAccelerometer(assemblyMms.AccelerometerId);
                if(accelerometer.AssemblyMms !=null ) 
                    throw new ArgumentException($"У введенного вами акселерометра другой ММД ");
                assemblyMms.Accelerometer = accelerometer;
            }
            if (assemblyMms.GyroscopeId != null)
            {
                var gyroscope = _gyroscopeRepository
                       .GetGyroscope(assemblyMms.GyroscopeId);
                if (gyroscope.AssemblyMms !=null) 
                    throw new ArgumentException($"У введенного вами гироскопа другой ММД ");
                assemblyMms.Gyroscope = gyroscope;
            }
            if (assemblyMms.AuthorId != null)
            {
                assemblyMms.Author = _authorRepository.GetAuthor(assemblyMms.AuthorId.Value);
            }
            if (assemblyMms.ConsignmentId != null)
            {
                assemblyMms.Consignment = _consignmentRepository
                    .GetConsignment(assemblyMms.ConsignmentId);
            }

            return _assemblyMmsRepository.CreateAssemblyMms(assemblyMms);
        }

        public AssemblyMms UpdateAssemblyMms(UpdateAssemblyMms updateAssemblyMms)
        {
            if (updateAssemblyMms.AccelerometerId != null)
            {
                var accelerometer = _accelerometerRepository
                    .GetAccelerometer(updateAssemblyMms.AccelerometerId);
                if (accelerometer.AssemblyMms != null)
                    throw new ArgumentException($"У введенного вами акселерометра другой ММД ");
                updateAssemblyMms.Accelerometer = accelerometer;
            }
            if (updateAssemblyMms.GyroscopeId != null)
            {
                var gyroscope = _gyroscopeRepository
                       .GetGyroscope(updateAssemblyMms.GyroscopeId);
                if (gyroscope.AssemblyMms != null)
                    throw new ArgumentException($"У введенного вами гироскопа другой ММД ");
                updateAssemblyMms.Gyroscope = gyroscope;
            }

            if (updateAssemblyMms.AuthorId != null)
            {
                updateAssemblyMms.Author = _authorRepository.GetAuthor(updateAssemblyMms.AuthorId.Value);
            }
            if (updateAssemblyMms.ConsignmentId != null)
            {
                updateAssemblyMms.Consignment = _consignmentRepository
                    .GetConsignment(updateAssemblyMms.ConsignmentId);
            }

            return _assemblyMmsRepository.UpdateAssemblyMms(updateAssemblyMms);
        }

        public List<AssemblyMms> GetAssemblyMmsByIds(IEnumerable<string> ids)
        {
            return _assemblyMmsRepository.GetAssemblyMmsByIds(ids);
        }

        public void DeleteAssemblyMms(string id)
        {
            var assemblyMms = GetAssemblyMms(id);
            if (assemblyMms is null)
            {
                throw new ArgumentException($"AssemblyMms with id = {id} doesn't exist");
            }
            if (assemblyMms.ConfiguringMms != null)
            {
                _configuringMmsService.DeleteConfiguringMms(assemblyMms.ConfiguringMms.Id);
            }
            
            if (assemblyMms.MakeProduct != null)
            {
                _makeProductService.DeleteMakeProduct(assemblyMms.MakeProduct.Id);
            }
            _assemblyMmsRepository.DeleteAssemblyMms(id);
        }

        public AssemblyMms GetAssemblyMms(string id)
        {
            return _assemblyMmsRepository.GetAssemblyMms(id);
        }

      
    }
}
