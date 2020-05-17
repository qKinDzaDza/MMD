using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Services
{
    public interface IAccelerometerService
    {
        Accelerometer CreateAccelerometer(Accelerometer accelerometer);
        Accelerometer GetAccelerometer(string id);
        Accelerometer UpdateAccelerometer(UpdateAccelerometer updateAccelerometer);
        List<Accelerometer> GetAccelerometersByIds(IEnumerable<string> ids);
       // List<Accelerometer> UpdateAccelerometersByIds(IEnumerable<string> ids);
        void DeleteAccelerometer(string id);
    }
}
