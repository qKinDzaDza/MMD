using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Services
{
        public interface IMobileTestingProductService
        {
            MobileTestingProduct CreateMobileTestingProduct(MobileTestingProduct mobileTestingProduct);
            List<MobileTestingProduct> GetMobileTestingProductByIds(IEnumerable<int> ids);
            MobileTestingProduct GetMobileTestingProduct(int id);
            MobileTestingProduct UpdateMobileTestingProduct(UpdateMobileTestingProduct updateMobileTestingProductModel);
            void DeleteMobileTestingProduct(int id);
        }

}
