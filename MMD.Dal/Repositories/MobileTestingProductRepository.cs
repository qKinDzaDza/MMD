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
    public class MobileTestingProductRepository : IMobileTestingProductRepository
    {
        private readonly ApplicationContext _context;

        public MobileTestingProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        public List<MobileTestingProduct> GetMobileTestingProductByIds(IEnumerable<int> ids)
        {
            return _context.MobileTestingProducts.Include(a => a.Author)
                .Where(a => ids.Contains(a.Id)).ToList();
        }

        public MobileTestingProduct CreateMobileTestingProduct(MobileTestingProduct mobileTestingProduct)
        {
            _context.MobileTestingProducts.Add(mobileTestingProduct);
            _context.SaveChanges();

            return mobileTestingProduct;
        }

        public void DeleteMobileTestingProduct(int id)
        {
            var mobileTestingProduct = _context.MobileTestingProducts.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();


            if (mobileTestingProduct is null) throw new ArgumentException
                 ($"MobileTestingProduct with id = {id} doesn't exist");


            _context.MobileTestingProducts.Remove(mobileTestingProduct);
            _context.SaveChanges();
        }

        public MobileTestingProduct GetMobileTestingProduct(int id)
        {
            MobileTestingProduct mobileTestingProduct = _context.MobileTestingProducts
                .Include(a => a.CalibrationProduct)
                .Where(a => a.Id.Equals(id))
                .SingleOrDefault();
            return mobileTestingProduct;
        }

        public MobileTestingProduct UpdateMobileTestingProduct(UpdateMobileTestingProduct updateMobileTestingProduct)
        {
            var mobileTestingProduct = _context.MobileTestingProducts.Where(a => a.Id.Equals(updateMobileTestingProduct.Id)).SingleOrDefault();
            if (mobileTestingProduct is null) throw new Exception("");

            if (updateMobileTestingProduct.Author != null)
            {
                mobileTestingProduct.Author = updateMobileTestingProduct.Author;
            }
            if (updateMobileTestingProduct.ConfiguringProduct != null)
            {
                mobileTestingProduct.ConfiguringProduct = updateMobileTestingProduct.ConfiguringProduct;
            }
            if (updateMobileTestingProduct.Place != null)
            {
                mobileTestingProduct.Place = updateMobileTestingProduct.Place;
            }
            if (updateMobileTestingProduct.CalibrationProduct != null)
            {
                mobileTestingProduct.CalibrationProduct = updateMobileTestingProduct.CalibrationProduct;
            }

            if (updateMobileTestingProduct.Date.HasValue)
            {
                mobileTestingProduct.Date = updateMobileTestingProduct.Date.Value;
            }
            if (updateMobileTestingProduct.Nonlinearity.HasValue)
            {
                mobileTestingProduct.Nonlinearity = updateMobileTestingProduct.Nonlinearity.Value;
            }
            if (updateMobileTestingProduct.Inaccuracy.HasValue)
            {
                mobileTestingProduct.Inaccuracy = updateMobileTestingProduct.Inaccuracy.Value;
            }
            if (updateMobileTestingProduct.СhangeShiftZero.HasValue)
            {
                mobileTestingProduct.СhangeShiftZero = updateMobileTestingProduct.СhangeShiftZero.Value;
            }
            if (updateMobileTestingProduct.СhangeTransformation.HasValue)
            {
                mobileTestingProduct.СhangeTransformation = updateMobileTestingProduct.СhangeTransformation.Value;
            }
            if (updateMobileTestingProduct.HysteresisShiftZero.HasValue)
            {
                mobileTestingProduct.HysteresisShiftZero = updateMobileTestingProduct.HysteresisShiftZero.Value;
            }
            if (updateMobileTestingProduct.HysteresisTransformation.HasValue)
            {
                mobileTestingProduct.HysteresisTransformation = updateMobileTestingProduct.HysteresisTransformation.Value;
            }

            _context.SaveChanges();

            return mobileTestingProduct;
        }
    }
}
