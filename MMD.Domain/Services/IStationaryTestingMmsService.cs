using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Services
{
        public interface IStationaryTestingMmsService
        {
            StationaryTestingMms CreateStationaryTestingMms(StationaryTestingMms stationaryTestingMms);
            List<StationaryTestingMms> GetStationaryTestingMmsByIds(IEnumerable<int> ids);
            StationaryTestingMms GetStationaryTestingMms(int id);
            StationaryTestingMms UpdateStationaryTestingMms(UpdateStationaryTestingMms updateStationaryTestingMmsModel);
            void DeleteStationaryTestingMms(int id);
        }
}
