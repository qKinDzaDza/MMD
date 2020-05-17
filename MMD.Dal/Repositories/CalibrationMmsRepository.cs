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
    public class CalibrationMmsRepository : ICalibrationMmsRepository
    {
        private readonly ApplicationContext _context;

        public CalibrationMmsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public CalibrationMms CreateCalibrationMms(CalibrationMms calibrationMms)
        {
            _context.CalibrationMmses.Add(calibrationMms);
            _context.SaveChanges();
            
            return calibrationMms;
        }
        public List<CalibrationMms> GetCalibrationMmsByIds(IEnumerable<int> ids)
        {
            return _context.CalibrationMmses.Include(a => a.Author)
                .Where(a => ids.Contains(a.Id)).ToList();
        }

        public void DeleteCalibrationMms(int id)
        {
            var calibrationMms = _context.CalibrationMmses.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();

            if (calibrationMms is null) throw new ArgumentException
                   ($"CalibrationMms with id = {id} doesn't exist");

            _context.CalibrationMmses.Remove(calibrationMms);
            _context.SaveChanges();
        }

        public CalibrationMms GetCalibrationMms(int id)
        {
            var calibrationMms = _context.CalibrationMmses
                .Include(a => a.StationaryTestingMms)
                .Where(a => a.Id.Equals(id))
                .SingleOrDefault();
            return calibrationMms;
        }

        public CalibrationMms UpdateCalibrationMms(UpdateCalibrationMms updateCalibrationMms)
        {
            var calibrationMms = _context.CalibrationMmses.Where(a => a.Id.Equals(updateCalibrationMms.Id)).SingleOrDefault();
            if (calibrationMms is null) throw new Exception("");

            if (updateCalibrationMms.Author != null)
            {
                calibrationMms.Author = updateCalibrationMms.Author;
            }
            if (updateCalibrationMms.MobileTestingMms != null)
            {
                calibrationMms.MobileTestingMms = updateCalibrationMms.MobileTestingMms;
            }
            if (updateCalibrationMms.Place != null)
            {
                calibrationMms.Place = updateCalibrationMms.Place;
            }
            if (updateCalibrationMms.Date.HasValue)
            {
                calibrationMms.Date = updateCalibrationMms.Date.Value;
            }
            if (updateCalibrationMms.Nonlinearity.HasValue)
            {
                calibrationMms.Nonlinearity = updateCalibrationMms.Nonlinearity.Value;
            }
            if (updateCalibrationMms.Inaccuracy.HasValue)
            {
                calibrationMms.Inaccuracy = updateCalibrationMms.Inaccuracy.Value;
            }
            if (updateCalibrationMms.СhangeShiftZero.HasValue)
            {
                calibrationMms.СhangeShiftZero = updateCalibrationMms.СhangeShiftZero.Value;
            }
            if (updateCalibrationMms.СhangeTransformation.HasValue)
            {
                calibrationMms.СhangeTransformation = updateCalibrationMms.СhangeTransformation.Value;
            }
            if (updateCalibrationMms.HysteresisShiftZero.HasValue)
            {
                calibrationMms.HysteresisShiftZero = updateCalibrationMms.HysteresisShiftZero.Value;
            }
            if (updateCalibrationMms.HysteresisTransformation.HasValue)
            {
                calibrationMms.HysteresisTransformation = updateCalibrationMms.HysteresisTransformation.Value;
            }
            if (updateCalibrationMms.StationaryTestingMms != null)
            {
                calibrationMms.StationaryTestingMms = updateCalibrationMms.StationaryTestingMms;
            }

            _context.SaveChanges();

            return calibrationMms;
        }
    }
}
