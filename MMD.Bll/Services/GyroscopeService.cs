using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;

namespace MMD.Bll
{
    public class GyroscopeService : IGyroscopeService
    {
        private readonly IGyroscopeRepository _gyroscopeRepository;
        private readonly IAssemblyMmsService _assemblyMmsService;
        private readonly IPlateRepository _plateRepository;

        public GyroscopeService(IGyroscopeRepository gyroscopeRepository,
            IAssemblyMmsService assemblyMmsService,
            IPlateRepository plateRepository)
        {
            _gyroscopeRepository = gyroscopeRepository;
            _assemblyMmsService = assemblyMmsService;
            _plateRepository = plateRepository;
        }

        public Gyroscope CreateGyroscope(Gyroscope gyroscope)
        {
            if (gyroscope.PlateId != null)
            {
                gyroscope.Plate = _plateRepository.GetPlate(gyroscope.PlateId);
            }

            return _gyroscopeRepository.CreateGyroscope(gyroscope);
        }
        public Gyroscope UpdateGyroscope(UpdateGyroscope updateGyroscope)
        {
            if (updateGyroscope.PlateId != null)
            {
                updateGyroscope.Plate = _plateRepository.GetPlate(updateGyroscope.PlateId);
            }

            return _gyroscopeRepository.UpdateGyroscope(updateGyroscope);
        }
        public List<Gyroscope> GetGyroscopeByIds(IEnumerable<string> ids)
        {
            return _gyroscopeRepository.GetGyroscopeByIds(ids);
        }

        public void DeleteGyroscope(string id)
        {
            var gyroscope = GetGyroscope(id);

            if (gyroscope is null)
            {
                throw new ArgumentException($"AssemblyMms with id = {id} doesn't exist");
            }
            if (gyroscope.AssemblyMms != null)
            {
                _assemblyMmsService.DeleteAssemblyMms(gyroscope.AssemblyMms.Id);
            }

            _gyroscopeRepository.DeleteGyroscope(id);
        }

        public Gyroscope GetGyroscope(string id)
        {
            return _gyroscopeRepository.GetGyroscope(id);
        }

       
    }
}
