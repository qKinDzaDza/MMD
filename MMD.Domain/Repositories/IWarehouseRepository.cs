using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Repositories
{
    public interface IWarehouseRepository
    {
        Warehouse CreateWarehouse(Warehouse warehouse);
        List<Warehouse> GetWarehouseByIds(IEnumerable<int> ids);
        Warehouse GetWarehouse(int id);
        Warehouse UpdateWarehouse(UpdateWarehouse updateWarehouseModel);
        void DeleteWarehouse(int id);
    }
}
