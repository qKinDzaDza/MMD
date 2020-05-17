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
    public class GyroscopeRepository : IGyroscopeRepository
    {
        private readonly ApplicationContext _context;

        public GyroscopeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Gyroscope CreateGyroscope(Gyroscope gyroscope)
        {
            _context.Gyroscopes.Add(gyroscope);
            _context.SaveChanges();
            
            return gyroscope;
        }
        public List<Gyroscope> GetGyroscopeByIds(IEnumerable<string> ids)
        {
            return _context.Gyroscopes.Include(a => a.Plate)
                .Where(a => ids.Contains(a.Id)).ToList();
        }

        // _context.Gyroscope.Where(a => ids.Contains(a.Id)).ToList();

        public void DeleteGyroscope(string id)
        {
            var gyroscope = _context.Gyroscopes.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();

            if (gyroscope is null) throw new ArgumentException
                 ($"Gyroscope with id = {id} doesn't exist");

            _context.Gyroscopes.Remove(gyroscope);
            _context.SaveChanges();
        }

        public Gyroscope GetGyroscope(string id)
        {
            Gyroscope gyroscope = _context.Gyroscopes
                .Include(a => a.AssemblyMms)
                .Where(a => a.Id.Equals(id))
                .SingleOrDefault();
            return gyroscope;
        }

        public Gyroscope UpdateGyroscope(UpdateGyroscope updateGyroscope)
        {
            var gyroscope = _context.Gyroscopes.Where(a => a.Id.Equals(updateGyroscope.Id)).SingleOrDefault();
           // var gyroscope = _context.Gyroscopes.Where(a =>l ids.Contains(a.Id)).ToList();
            if (gyroscope is null) throw new Exception("");

            if (updateGyroscope.AssemblyMms != null)
            {
                gyroscope.AssemblyMms = updateGyroscope.AssemblyMms;
            }
            if (updateGyroscope.Plate != null)
            {
                gyroscope.Plate = updateGyroscope.Plate;
            }

            if (updateGyroscope.ParameterF1.HasValue)
            {
                gyroscope.ParameterF1 = updateGyroscope.ParameterF1.Value;
            }
            if (updateGyroscope.ParameterF2.HasValue)
            {
                gyroscope.ParameterF2 = updateGyroscope.ParameterF2.Value;
            }
            if (updateGyroscope.ParameterQ1.HasValue)
            {
                gyroscope.ParameterQ1 = updateGyroscope.ParameterQ1.Value;
            }
            if (updateGyroscope.ParameterQ2.HasValue)
            {
                gyroscope.ParameterQ2 = updateGyroscope.ParameterQ2.Value;
            }
            if (updateGyroscope.ParameterQ.HasValue)
            {
                gyroscope.ParameterQ = updateGyroscope.ParameterQ.Value;
            }
            if (updateGyroscope.DifferentialF.HasValue)
            {
                gyroscope.DifferentialF = updateGyroscope.DifferentialF.Value;
            }
            if (updateGyroscope.DifferentialFQ.HasValue)
            {
                gyroscope.DifferentialFQ = updateGyroscope.DifferentialFQ.Value;
            }

            _context.SaveChanges();

            return gyroscope;
        }
    }
}
