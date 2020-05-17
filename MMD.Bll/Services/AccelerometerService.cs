using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;

namespace MMD.Bll.Services
{
    public class AccelerometerService : IAccelerometerService
    {
        private readonly IAccelerometerRepository _accelerometerRepository;
        private readonly IAssemblyMmsService _assemblyMmsService;
        private readonly IPlateRepository _plateRepository;

        public AccelerometerService(IAccelerometerRepository accelerometerRepository,
            IAssemblyMmsService assemblyMmsService,
            IPlateRepository plateRepository)
        {
            _accelerometerRepository = accelerometerRepository;
            _assemblyMmsService = assemblyMmsService;
            _plateRepository = plateRepository;
        }

        public Accelerometer CreateAccelerometer(Accelerometer accelerometer)
        {
            if (accelerometer.PlateId != null)
            {
                accelerometer.Plate = _plateRepository.GetPlate(accelerometer.PlateId);
            }
            return _accelerometerRepository.CreateAccelerometer(accelerometer);
        }

        public Accelerometer UpdateAccelerometer(UpdateAccelerometer updateAccelerometer)
        {
            if (updateAccelerometer.PlateId != null)
            {
                updateAccelerometer.Plate = _plateRepository.GetPlate(updateAccelerometer.PlateId);
            }
            return _accelerometerRepository.UpdateAccelerometer(updateAccelerometer);
        }

        public void DeleteAccelerometer(string id)
        {
            var accelerometer = GetAccelerometer(id);

            if (accelerometer is null)
            {
                throw new ArgumentException($"AssemblyMms with id = {id} doesn't exist");
            }
            if (accelerometer.AssemblyMms != null)
            {
                _assemblyMmsService.DeleteAssemblyMms(accelerometer.AssemblyMms.Id);
            }


            _accelerometerRepository.DeleteAccelerometer(id);
        }

        public Accelerometer GetAccelerometer(string id)
        {
            return _accelerometerRepository.GetAccelerometer(id);
        }

        
        public List<Accelerometer> GetAccelerometersByIds(IEnumerable<string> ids)
        {
            return _accelerometerRepository.GetAccelerometersByIds(ids);
        }
    }
}
