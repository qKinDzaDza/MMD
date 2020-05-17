using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Repositories
{
    public interface IMobileTestingMmsRepository
    {
        MobileTestingMms CreateMobileTestingMms(MobileTestingMms mobileTestingMms);
        List<MobileTestingMms> GetMobileTestingMmsByIds(IEnumerable<int> ids);
        MobileTestingMms GetMobileTestingMms(int id);
        MobileTestingMms UpdateMobileTestingMms(UpdateMobileTestingMms updateMobileTestingMms);
        void DeleteMobileTestingMms(int id);
    }
}
