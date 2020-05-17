using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Repositories
{
    public interface IAccelerometerRepository
    {
        Accelerometer CreateAccelerometer(Accelerometer accelerometer);
        Accelerometer GetAccelerometer(string id);
        Accelerometer UpdateAccelerometer(UpdateAccelerometer updateAccelerometer);
        List<Accelerometer> GetAccelerometersByIds(IEnumerable<string> ids);
      //  List<Accelerometer> UpdateAccelerometersByIds(IEnumerable<string> ids);
        void DeleteAccelerometer(string id);
    }
}
