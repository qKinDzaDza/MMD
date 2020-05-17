using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMD.Dal.Repositories
{
    public class ConsignmentRepository : IConsignmentRepository
    {
        private readonly ApplicationContext _context;

        public ConsignmentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Consignment CreateConsignment(Consignment consignment)
        {
            _context.Consignments.Add(consignment);
            _context.SaveChanges();
            
            return consignment;
        }

        public void DeleteConsignment(string id)
        {
            var consignment = _context.Consignments.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();

            if (consignment is null) throw new ArgumentException
                   ($"Consignment with id = {id} doesn't exist");

            var assemblyMmses = _context.AssemblyMms.Where(a => a.ConsignmentId == id);
            foreach (var assemblyMms in assemblyMmses)
            {
                assemblyMms.ConsignmentId = null;
            }

            _context.Consignments.Remove(consignment);
            _context.SaveChanges();
        }

        public Consignment GetConsignment(string id)
        {
            Consignment consignment = _context.Consignments.Where(a => a.Id.Equals(id))
                                                          .SingleOrDefault();
            return consignment;
        }

        public Consignment UpdateConsignment(UpdateConsignment updateConsignment)
        {
            var consignment = _context.Consignments.Where(a => a.Id.Equals(updateConsignment.Id)).SingleOrDefault();
            if (consignment is null) throw new Exception("");
            
            if (updateConsignment.AssemblyMms != null)
            {
                consignment.AssemblyMms = updateConsignment.AssemblyMms;
            }


            _context.SaveChanges();

            return consignment;
        }
    }
}
