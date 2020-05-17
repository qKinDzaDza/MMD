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
    public class StationaryTestingMmsRepository : IStationaryTestingMmsRepository
    {
        private readonly ApplicationContext _context;

        public StationaryTestingMmsRepository(ApplicationContext context)
        {
            _context = context;
        }
        public List<StationaryTestingMms> GetStationaryTestingMmsByIds(IEnumerable<int> ids)
        {
            return _context.StationaryTestingMms.Include(a => a.Author)
                .Where(a => ids.Contains(a.Id)).ToList();
        }
        public StationaryTestingMms CreateStationaryTestingMms(StationaryTestingMms stationaryTestingMms)
        {
            _context.StationaryTestingMms.Add(stationaryTestingMms);
            _context.SaveChanges();
            
            return stationaryTestingMms;
        }

        public void DeleteStationaryTestingMms(int id)
        {
            var stationaryTestingMms = _context.StationaryTestingMms.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();

            if (stationaryTestingMms is null) throw new ArgumentException
                ($"StationaryTestingMms with id = {id} doesn't exist");

            _context.StationaryTestingMms.Remove(stationaryTestingMms);
            _context.SaveChanges();
        }

        public StationaryTestingMms GetStationaryTestingMms(int id)
        {
            StationaryTestingMms stationaryTestingMms = _context.StationaryTestingMms.Where(a => a.Id.Equals(id))
                                                          .SingleOrDefault();
            return stationaryTestingMms;
        }

        public StationaryTestingMms UpdateStationaryTestingMms(UpdateStationaryTestingMms updateStationaryTestingMms)
        {
            var stationaryTestingMms = _context.StationaryTestingMms.Where(a => a.Id.Equals(updateStationaryTestingMms.Id)).SingleOrDefault();
            if (stationaryTestingMms is null) throw new Exception("");

            if (updateStationaryTestingMms.Author != null)
            {
                stationaryTestingMms.Author = updateStationaryTestingMms.Author;
            }
            if (updateStationaryTestingMms.CalibrationMms != null)
            {
                stationaryTestingMms.CalibrationMms = updateStationaryTestingMms.CalibrationMms;
            }
            if (updateStationaryTestingMms.Place != null)
            {
                stationaryTestingMms.Place = updateStationaryTestingMms.Place;
            }

            if (updateStationaryTestingMms.Date.HasValue)
            {
                stationaryTestingMms.Date = updateStationaryTestingMms.Date.Value;
            }
            if (updateStationaryTestingMms.AlanInstability.HasValue)
            {
                stationaryTestingMms.AlanInstability = updateStationaryTestingMms.AlanInstability.Value;
            }
            if (updateStationaryTestingMms.PowerDensity.HasValue)
            {
                stationaryTestingMms.PowerDensity = updateStationaryTestingMms.PowerDensity.Value;
            }

            _context.SaveChanges();

            return stationaryTestingMms;
        }
    }
}
