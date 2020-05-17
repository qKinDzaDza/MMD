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
    public class StationaryTestingProductRepository : IStationaryTestingProductRepository
    {
        private readonly ApplicationContext _context;

        public StationaryTestingProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        public List<StationaryTestingProduct> GetStationaryTestingProductByIds(IEnumerable<int> ids)
        {
            return _context.StationaryTestingProducts.Include(a => a.Author)
                .Where(a => ids.Contains(a.Id)).ToList();
        }
        public StationaryTestingProduct CreateStationaryTestingProduct(StationaryTestingProduct stationaryTestingProduct)
        {
            _context.StationaryTestingProducts.Add(stationaryTestingProduct);
            _context.SaveChanges();
            
            return stationaryTestingProduct;
        }

        public void DeleteStationaryTestingProduct(int id)
        {
            var stationaryTestingProduct = _context.StationaryTestingProducts.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();

            if (stationaryTestingProduct is null) throw new ArgumentException
                ($"StationaryTestingProduct with id = {id} doesn't exist");


            _context.StationaryTestingProducts.Remove(stationaryTestingProduct);
            _context.SaveChanges();
        }

        public StationaryTestingProduct GetStationaryTestingProduct(int id)
        {
            StationaryTestingProduct stationaryTestingProduct = _context.StationaryTestingProducts.Where(a => a.Id.Equals(id))
                                                          .SingleOrDefault();
            return stationaryTestingProduct;
        }

        public StationaryTestingProduct UpdateStationaryTestingProduct(UpdateStationaryTestingProduct updateStationaryTestingProduct)
        {
            var stationaryTestingProduct = _context.StationaryTestingProducts.Where(a => a.Id.Equals(updateStationaryTestingProduct.Id)).SingleOrDefault();
            if (stationaryTestingProduct is null) throw new Exception("");

            if (updateStationaryTestingProduct.Author != null)
            {
                stationaryTestingProduct.Author = updateStationaryTestingProduct.Author;
            }
            if (updateStationaryTestingProduct.CalibrationProduct != null)
            {
                stationaryTestingProduct.CalibrationProduct = updateStationaryTestingProduct.CalibrationProduct;
            }
            if (updateStationaryTestingProduct.Place != null)
            {
                stationaryTestingProduct.Place = updateStationaryTestingProduct.Place;
            }


            if (updateStationaryTestingProduct.Date.HasValue)
            {
                stationaryTestingProduct.Date = updateStationaryTestingProduct.Date.Value;
            }
            if (updateStationaryTestingProduct.AlanInstability.HasValue)
            {
                stationaryTestingProduct.AlanInstability = updateStationaryTestingProduct.AlanInstability.Value;
            }
            if (updateStationaryTestingProduct.PowerDensity.HasValue)
            {
                stationaryTestingProduct.PowerDensity = updateStationaryTestingProduct.PowerDensity.Value;
            }
            _context.SaveChanges();

            return stationaryTestingProduct;
        }
    }
}
