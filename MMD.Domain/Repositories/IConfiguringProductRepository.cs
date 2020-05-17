using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Repositories
{
    public interface IConfiguringProductRepository
    {
        ConfiguringProduct CreateConfiguringProduct(ConfiguringProduct configuringProduct);
        List<ConfiguringProduct> GetConfiguringProductByIds(IEnumerable<int> ids);
        ConfiguringProduct GetConfiguringProduct(int id);
        ConfiguringProduct UpdateConfiguringProduct(UpdateConfiguringProduct updateConfiguringProductModel);
        void DeleteConfiguringProduct(int id);
    }
}
