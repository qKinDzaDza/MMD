using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Services
{
        public interface IStationaryTestingProductService
        {
            StationaryTestingProduct CreateStationaryTestingProduct(StationaryTestingProduct stationaryTestingProduct);
            List<StationaryTestingProduct> GetStationaryTestingProductByIds(IEnumerable<int> ids);
            StationaryTestingProduct GetStationaryTestingProduct(int id);
            StationaryTestingProduct UpdateStationaryTestingProduct(UpdateStationaryTestingProduct updateStationaryTestingProductModel);
            void DeleteStationaryTestingProduct(int id);
        }
}
