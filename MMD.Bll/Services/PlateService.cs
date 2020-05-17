using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Linq;

namespace MMD.Bll
{
    public class PlateService : IPlateService
    {
        private readonly IPlateRepository _plateRepository;
        private readonly IAccelerometerService _accelerometerService;
        private readonly IGyroscopeService _gyroscopeService;

        public PlateService(IPlateRepository plateRepository, IAccelerometerService accelerometerService,
            IGyroscopeService gyroscopeService)
        {
            _plateRepository = plateRepository;
            _accelerometerService = accelerometerService;
            _gyroscopeService = gyroscopeService;
        }

        public Plate CreatePlate(Plate plate)
        {
            if (plate.AccelerometerIds != null)
            {
                var accelerometers = _accelerometerService.GetAccelerometersByIds
                    (plate.AccelerometerIds);
                if (accelerometers.Any(a => a.Plate != null)) throw new Exception();
                plate.Accelerometer = accelerometers;
            }

            if (plate.GyroscopeIds!= null)
            {
                var gyroscopes = _gyroscopeService.GetGyroscopeByIds(plate.GyroscopeIds);
                if(gyroscopes.Any(a=>a.Plate !=null)) throw new Exception();
                plate.Gyroscope = gyroscopes;
            }

            return _plateRepository.CreatePlate(plate);
        }

        public void DeletePlate(string id)
        {
            var plate = GetPlate(id);
            if (plate is null) throw new ArgumentException
                ($"MobileTestingProduct with id = {id} doesn't exist");
           
            if(plate.Gyroscope != null)
            {
                foreach (var gyroscopeId in plate.Gyroscope.Select(g => g.Id).ToList())
                    _gyroscopeService.DeleteGyroscope(gyroscopeId);
            }

            if (plate.Accelerometer != null)
            {
                foreach (var accelerometerId in plate.Accelerometer.Select(a => a.Id).ToList())
                    _accelerometerService.DeleteAccelerometer(accelerometerId);
            }

            _plateRepository.DeletePlate(id);
        }

        public Plate GetPlate(string id)
        {
            return _plateRepository.GetPlate(id);
        }

        public Plate UpdatePlate(UpdatePlate updatePlate)
        {
            if (updatePlate.AccelerometerIds != null)
            {
                var accelerometers = _accelerometerService.GetAccelerometersByIds
                    (updatePlate.AccelerometerIds);
                if (accelerometers.Any(a => a.Plate != null)) throw new Exception();
                updatePlate.Accelerometer = accelerometers;
            }

            if (updatePlate.GyroscopeIds != null)
            {
                var gyroscopes = _gyroscopeService.GetGyroscopeByIds(updatePlate.GyroscopeIds);
                if (gyroscopes.Any(a => a.Plate != null)) throw new Exception();
                updatePlate.Gyroscope = gyroscopes;
            }

            return _plateRepository.UpdatePlate(updatePlate);
        }
    }
}
