using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Repositories
{
    public interface IGyroscopeRepository
    {
        Gyroscope CreateGyroscope(Gyroscope gyroscope);
        Gyroscope GetGyroscope(string id);
        List<Gyroscope> GetGyroscopeByIds(IEnumerable<string> ids);
        Gyroscope UpdateGyroscope(UpdateGyroscope updateGyroscope);
        void DeleteGyroscope(string id);
    }
}
