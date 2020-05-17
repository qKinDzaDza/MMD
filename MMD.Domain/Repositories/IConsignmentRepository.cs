using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Repositories
{
    public interface IConsignmentRepository
    {
        Consignment CreateConsignment(Consignment consignment);
        Consignment GetConsignment(string id);
        Consignment UpdateConsignment(UpdateConsignment updateConsignmentModel);
        void DeleteConsignment(string id);
    }
}
