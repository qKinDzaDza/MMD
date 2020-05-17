using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Repositories
{
    public interface IMobileTestingProductRepository
    {
        MobileTestingProduct CreateMobileTestingProduct(MobileTestingProduct mobileTestingProduct);
        List<MobileTestingProduct> GetMobileTestingProductByIds(IEnumerable<int> ids);
        MobileTestingProduct GetMobileTestingProduct(int id);
        MobileTestingProduct UpdateMobileTestingProduct(UpdateMobileTestingProduct updateMobileTestingProductModel);
        void DeleteMobileTestingProduct(int id);
    }
}
