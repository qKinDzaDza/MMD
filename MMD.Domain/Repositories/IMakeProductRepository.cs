using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Repositories
{
    public interface IMakeProductRepository
    {
        MakeProduct CreateMakeProduct(MakeProduct makeProduct);
        List<MakeProduct> GetMakeProductByIds(IEnumerable<string> ids);
        MakeProduct GetMakeProduct(string id);
        MakeProduct UpdateMakeProduct(UpdateMakeProduct updateMakeProductModel);
        void DeleteMakeProduct(string id);
    }
}
