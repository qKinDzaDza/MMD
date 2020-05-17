using Microsoft.EntityFrameworkCore;
using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMD.Dal.Repositories
{
    public class AccelerometerRepository : IAccelerometerRepository
    {
        private readonly ApplicationContext _context;

        public AccelerometerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Accelerometer CreateAccelerometer(Accelerometer accelerometer)
        {
            _context.Accelerometers.Add(accelerometer);
            _context.SaveChanges();

            return accelerometer;
        }

        public void DeleteAccelerometer(string id)
        {
            var accelerometer = _context.Accelerometers.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();

            if (accelerometer is null) throw new ArgumentException
                   ($"Accelerometer with id = {id} doesn't exist");

            _context.Accelerometers.Remove(accelerometer);
            _context.SaveChanges();
        }

        public List<Accelerometer> GetAccelerometersByIds(IEnumerable<string> ids)
        {
            return _context.Accelerometers.Include(a => a.Plate)
                .Where(a => ids.Contains(a.Id)).ToList();
        }

        public Accelerometer GetAccelerometer(string id)
        {
            Accelerometer accelerometer = _context.Accelerometers
                .Include(a => a.AssemblyMms)
                .Where(a => a.Id.Equals(id))
                .SingleOrDefault();
            return accelerometer;
        }

        public Accelerometer UpdateAccelerometer(UpdateAccelerometer updateAccelerometer)
        {
            var accelerometer = _context.Accelerometers.Where(a => a.Id.Equals(updateAccelerometer.Id)).SingleOrDefault();

            if (accelerometer is null) throw new Exception("");
           
            if (updateAccelerometer.AssemblyMms != null)
            {
                accelerometer.AssemblyMms = updateAccelerometer.AssemblyMms;
            }
            if (updateAccelerometer.Plate != null)
            {
                accelerometer.Plate = updateAccelerometer.Plate;
            }
            if (updateAccelerometer.Ea1.HasValue)
            {
                accelerometer.Ea1 = updateAccelerometer.Ea1.Value;
            }
            if (updateAccelerometer.Ea1_3v.HasValue)
            {
                accelerometer.Ea1_3v = updateAccelerometer.Ea1_3v.Value;
            }
            if (updateAccelerometer.Ea2.HasValue)
            {
                accelerometer.Ea2 = updateAccelerometer.Ea2.Value;
            }
            if (updateAccelerometer.Ea2_3v.HasValue)
            {
                accelerometer.Ea2_3v = updateAccelerometer.Ea2_3v.Value;
            }
            if (updateAccelerometer.Ed1.HasValue)
            {
                accelerometer.Ed1 = updateAccelerometer.Ed1.Value;
            }
            if (updateAccelerometer.Ed1_3v.HasValue)
            {
                accelerometer.Ed1_3v = updateAccelerometer.Ed1_3v.Value;
            }
            if (updateAccelerometer.Ed2.HasValue)
            {
                accelerometer.Ed2 = updateAccelerometer.Ed2.Value;
            }
            if (updateAccelerometer.Ed2_3v.HasValue)
            {
                accelerometer.Ed2_3v = updateAccelerometer.Ed2_3v.Value;
            }
            

            _context.SaveChanges();

            return accelerometer;
        }
    }
}
