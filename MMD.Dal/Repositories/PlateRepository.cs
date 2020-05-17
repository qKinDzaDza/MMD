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
    public class PlateRepository : IPlateRepository
    {
        private readonly ApplicationContext _context;

        public PlateRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Plate CreatePlate(Plate plate)
        {
            _context.Plates.Add(plate);
            _context.SaveChanges();
            
            return plate;
        }

        public void DeletePlate(string id)
        {
            var plate = _context.Plates.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();


            if (plate is null) throw new ArgumentException
                 ($"Plate with id = {id} doesn't exist");


            _context.Plates.Remove(plate);
            _context.SaveChanges();
        }

        public Plate GetPlate(string id)
        {
            var ogo = _context.Plates.Include(p => p.Accelerometer).ToList();
            Plate plate = _context.Plates
                .Include(p => p.Gyroscope)
                .Include(p => p.Accelerometer)
                .Where(a => a.Id.Equals(id))
                .SingleOrDefault();

            plate.AccelerometerIds = _context.Accelerometers
                .Where(a => a.Plate.Id.Equals(id)).Select(a => a.Id).ToList();
            plate.GyroscopeIds = _context.Gyroscopes
                .Where(a => a.Plate.Id.Equals(id)).Select(a => a.Id).ToList();

            return plate;
        }

        public Plate UpdatePlate(UpdatePlate updatePlate)
        {
            var plate = _context.Plates.Where(a => a.Id.Equals(updatePlate.Id)).SingleOrDefault();
            if (plate is null) throw new Exception("");
            
            if (updatePlate.AccelerometerIds != null)
            {
                plate.AccelerometerIds = updatePlate.AccelerometerIds;
            }

            if (updatePlate.Accelerometer != null)
            {
                plate.Accelerometer = updatePlate.Accelerometer;
            }

            if (updatePlate.Gyroscope != null)
            {
                plate.Gyroscope = updatePlate.Gyroscope;
            }

            _context.SaveChanges();

            return plate;
        }
    }
}
