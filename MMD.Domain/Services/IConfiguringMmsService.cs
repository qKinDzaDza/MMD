using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Services
{
    public interface IConfiguringMmsService
    {
        ConfiguringMms CreateConfiguringMms(ConfiguringMms configuringMms);
        List<ConfiguringMms> GetConfiguringMmsByIds(IEnumerable<int> ids);
        ConfiguringMms GetConfiguringMms(int id);
        ConfiguringMms UpdateConfiguringMms(UpdateConfiguringMms updateConfiguringMmsModel);
        void DeleteConfiguringMms(int id);
    }
}