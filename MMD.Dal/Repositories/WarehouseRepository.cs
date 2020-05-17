using Microsoft.EntityFrameworkCore;
using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace MMD.Dal.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationContext _context;

        public WarehouseRepository(ApplicationContext context)
        {
            _context = context;
        }
        public List<Warehouse> GetWarehouseByIds(IEnumerable<int> ids)
        {
            return _context.Warehouses.Include(a => a.Author)
                .Where(a => ids.Contains(a.Id)).ToList();
        }
        public Warehouse CreateWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            _context.SaveChanges();
            
            return warehouse;
        }

        public void DeleteWarehouse(int id)
        {
            var warehouse = _context.Warehouses.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();

            if (warehouse is null) throw new ArgumentException
                ($"Warehouse with id = {id} doesn't exist");

            var makeProducts = _context.MakeProducts.Where(a => a.WarehouseId == id);
            foreach (var makeProduct in makeProducts)
            {
                makeProduct.WarehouseId= null;
            }

            _context.Warehouses.Remove(warehouse);
            _context.SaveChanges();
        }

        public Warehouse GetWarehouse(int id)
        {
            Warehouse warehouse = _context.Warehouses.Where(a => a.Id.Equals(id))
                                                          .SingleOrDefault();
            warehouse.MakeProductIds = _context.MakeProducts.
                Where(a => a.Author.Id.Equals(id)).Select(a => a.Id).ToList();

            return warehouse;
        }

        public Warehouse UpdateWarehouse(UpdateWarehouse updateWarehouse)
        {
            var warehouse = _context.Warehouses.Where(a => a.Id.Equals(updateWarehouse.Id)).SingleOrDefault();
            if (warehouse is null) throw new Exception("");

            if (updateWarehouse.Author != null)
            {
                warehouse.Author = updateWarehouse.Author;
            }
            if (updateWarehouse.MakeProduct != null)
            {
                warehouse.MakeProduct = updateWarehouse.MakeProduct;
            }


            if (updateWarehouse.Date.HasValue)
            {
                warehouse.Date = updateWarehouse.Date.Value;
            }

            _context.SaveChanges();

            return warehouse;
        }
    }
}
