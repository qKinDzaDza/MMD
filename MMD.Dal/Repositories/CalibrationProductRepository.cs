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
    public class CalibrationProductRepository : ICalibrationProductRepository
    {
        private readonly ApplicationContext _context;

        public CalibrationProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public CalibrationProduct CreateCalibrationProduct(CalibrationProduct calibrationProduct)
        {
            _context.CalibrationProducts.Add(calibrationProduct);
            _context.SaveChanges();
            
            return calibrationProduct;
        }
        public List<CalibrationProduct> GetCalibrationProductByIds(IEnumerable<int> ids)
        {
            return _context.CalibrationProducts.Include(a => a.Author)
                .Where(a => ids.Contains(a.Id)).ToList();
        }

        public void DeleteCalibrationProduct(int id)
        {
            var calibrationProduct = _context.CalibrationProducts.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();

            if (calibrationProduct is null) throw new ArgumentException
                   ($"CalibrationProduct with id = {id} doesn't exist");

            _context.CalibrationProducts.Remove(calibrationProduct);
            _context.SaveChanges();
        }

        public CalibrationProduct GetCalibrationProduct(int id)
        {
            var calibrationProduct = _context.CalibrationProducts
                .Include(a => a.StationaryTestingProduct)
                .Where(a => a.Id.Equals(id))
                .SingleOrDefault();
            return calibrationProduct;
        }

        public CalibrationProduct UpdateCalibrationProduct(UpdateCalibrationProduct updateCalibrationProduct)
        {
            var calibrationProduct = _context.CalibrationProducts.Where(a => a.Id.Equals(updateCalibrationProduct.Id)).SingleOrDefault();
            if (calibrationProduct is null) throw new Exception("");
            if (updateCalibrationProduct.Author != null)
            {
                calibrationProduct.Author = updateCalibrationProduct.Author;
            }
            if (updateCalibrationProduct.MobileTestingProduct != null)
            {
                calibrationProduct.MobileTestingProduct = updateCalibrationProduct.MobileTestingProduct;
            }
            if (updateCalibrationProduct.Place != null)
            {
                calibrationProduct.Place = updateCalibrationProduct.Place;
            }
            if (updateCalibrationProduct.Date.HasValue)
            {
                calibrationProduct.Date = updateCalibrationProduct.Date.Value;
            }
            if (updateCalibrationProduct.Nonlinearity.HasValue)
            {
                calibrationProduct.Nonlinearity = updateCalibrationProduct.Nonlinearity.Value;
            }
            if (updateCalibrationProduct.Inaccuracy.HasValue)
            {
                calibrationProduct.Inaccuracy = updateCalibrationProduct.Inaccuracy.Value;
            }
            if (updateCalibrationProduct.СhangeShiftZero.HasValue)
            {
                calibrationProduct.СhangeShiftZero = updateCalibrationProduct.СhangeShiftZero.Value;
            }
            if (updateCalibrationProduct.СhangeTransformation.HasValue)
            {
                calibrationProduct.СhangeTransformation = updateCalibrationProduct.СhangeTransformation.Value;
            }
            if (updateCalibrationProduct.HysteresisShiftZero.HasValue)
            {
                calibrationProduct.HysteresisShiftZero = updateCalibrationProduct.HysteresisShiftZero.Value;
            }
            if (updateCalibrationProduct.HysteresisTransformation.HasValue)
            {
                calibrationProduct.HysteresisTransformation = updateCalibrationProduct.HysteresisTransformation.Value;
            }

            if (updateCalibrationProduct.StationaryTestingProduct != null)
            {
                calibrationProduct.StationaryTestingProduct = updateCalibrationProduct.StationaryTestingProduct;
            }



            _context.SaveChanges();

            return calibrationProduct;
        }
    }
}
