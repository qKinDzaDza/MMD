using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMD.Bll
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMakeProductService _makeProductService;

        public WarehouseService(IWarehouseRepository warehouseRepository,
            IMakeProductService makeProductService)
        {
            _warehouseRepository = warehouseRepository;
            _makeProductService = makeProductService;
        }
        public List<Warehouse> GetWarehouseByIds(IEnumerable<int> ids)
        {
            return _warehouseRepository.GetWarehouseByIds(ids);
        }

        public Warehouse CreateWarehouse(Warehouse warehouse)
        {
            if (warehouse.MakeProductIds != null)
            {
                var makeProducts = _makeProductService.GetMakeProductByIds
                    (warehouse.MakeProductIds);
                if (makeProducts.Any(a => a.Warehouse != null)) throw new Exception();
                warehouse.MakeProduct = makeProducts;
            }

            return _warehouseRepository.CreateWarehouse(warehouse);
        }

        public void DeleteWarehouse(int id)
        {
            _warehouseRepository.DeleteWarehouse(id);
        }

        public Warehouse GetWarehouse(int id)
        {
            return _warehouseRepository.GetWarehouse(id);
        }

        public Warehouse UpdateWarehouse(UpdateWarehouse updateWarehouse)
        {
            if (updateWarehouse.MakeProductIds != null)
            {
                var makeProducts = _makeProductService.GetMakeProductByIds
                   (updateWarehouse.MakeProductIds);
                if (makeProducts.Any(a => a.Warehouse != null)) throw new Exception();
                updateWarehouse.MakeProduct = makeProducts;
            }
            return _warehouseRepository.UpdateWarehouse(updateWarehouse);
        }
    }
}
