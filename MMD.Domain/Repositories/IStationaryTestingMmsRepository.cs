using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Repositories
{
    public interface IStationaryTestingMmsRepository
    {
        StationaryTestingMms CreateStationaryTestingMms(StationaryTestingMms stationaryTestingMms);
        List<StationaryTestingMms> GetStationaryTestingMmsByIds(IEnumerable<int> ids);
        StationaryTestingMms GetStationaryTestingMms(int id);
        StationaryTestingMms UpdateStationaryTestingMms(UpdateStationaryTestingMms updateStationaryTestingMmsModel);
        void DeleteStationaryTestingMms(int id);
    }
}
