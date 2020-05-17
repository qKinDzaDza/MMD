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
    public class MobileTestingMmsRepository : IMobileTestingMmsRepository
    {
        private readonly ApplicationContext _context;

        public MobileTestingMmsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public MobileTestingMms CreateMobileTestingMms(MobileTestingMms mobileTestingMms)
        {
            _context.MobileTestingMmses.Add(mobileTestingMms);
            _context.SaveChanges();
            
            return mobileTestingMms;
        }
        public List<MobileTestingMms> GetMobileTestingMmsByIds(IEnumerable<int> ids)
        {
            return _context.MobileTestingMmses.Include(a => a.Author)
                .Where(a => ids.Contains(a.Id)).ToList();
        }
        public void DeleteMobileTestingMms(int id)
        {
            var mobileTestingMms = _context.MobileTestingMmses.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();

            if (mobileTestingMms is null) throw new ArgumentException
                 ($"MobileTestingMms with id = {id} doesn't exist");

            _context.MobileTestingMmses.Remove(mobileTestingMms);
            _context.SaveChanges();
        }

        public MobileTestingMms GetMobileTestingMms(int id)
        {
            MobileTestingMms mobileTestingMms = _context.MobileTestingMmses
                .Include(a => a.CalibrationMms)
                .Where(a => a.Id.Equals(id))
                .SingleOrDefault();
            return mobileTestingMms;
        }

        public MobileTestingMms UpdateMobileTestingMms(UpdateMobileTestingMms updateMobileTestingMms)
        {
            var mobileTestingMms = _context.MobileTestingMmses.Where(a => a.Id.Equals(updateMobileTestingMms.Id)).SingleOrDefault();
           
            if (mobileTestingMms is null) throw new Exception("");
            
            if (updateMobileTestingMms.Author != null)
            {
                mobileTestingMms.Author = updateMobileTestingMms.Author;
            }
            
            if (updateMobileTestingMms.ConfiguringMms != null)
            {
                mobileTestingMms.ConfiguringMms = updateMobileTestingMms.ConfiguringMms;
            }
            if (updateMobileTestingMms.CalibrationMms != null)
            {
                mobileTestingMms.CalibrationMms = updateMobileTestingMms.CalibrationMms;
            }

            if (updateMobileTestingMms.Place != null)
            {
                mobileTestingMms.Place = updateMobileTestingMms.Place;
            }
            
            if (updateMobileTestingMms.Date.HasValue)
            {
                mobileTestingMms.Date = updateMobileTestingMms.Date.Value;
            }
            if (updateMobileTestingMms.Nonlinearity.HasValue)
            {
                mobileTestingMms.Nonlinearity = updateMobileTestingMms.Nonlinearity.Value;
            }
            if (updateMobileTestingMms.Inaccuracy.HasValue)
            {
                mobileTestingMms.Inaccuracy = updateMobileTestingMms.Inaccuracy.Value;
            }
            if (updateMobileTestingMms.СhangeShiftZero.HasValue)
            {
                mobileTestingMms.СhangeShiftZero = updateMobileTestingMms.СhangeShiftZero.Value;
            }
            if (updateMobileTestingMms.СhangeTransformation.HasValue)
            {
                mobileTestingMms.СhangeTransformation = updateMobileTestingMms.СhangeTransformation.Value;
            }
            if (updateMobileTestingMms.HysteresisShiftZero.HasValue)
            {
                mobileTestingMms.HysteresisShiftZero = updateMobileTestingMms.HysteresisShiftZero.Value;
            }
            if (updateMobileTestingMms.HysteresisTransformation.HasValue)
            {
                mobileTestingMms.HysteresisTransformation = updateMobileTestingMms.HysteresisTransformation.Value;
            }

            _context.SaveChanges();

            return mobileTestingMms;
        }
    }
}
