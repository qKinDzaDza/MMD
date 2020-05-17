using Microsoft.EntityFrameworkCore;
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
    public class AssemblyMmsRepository : IAssemblyMmsRepository
    {
        private readonly ApplicationContext _context;

        public AssemblyMmsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public AssemblyMms CreateAssemblyMms(AssemblyMms assemblyMms)
        {
            _context.AssemblyMms.Add(assemblyMms);
            _context.SaveChanges();
            
            return assemblyMms;
        }

        public void DeleteAssemblyMms(string id)
        {
            var assemblyMms = _context.AssemblyMms.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();

            if (assemblyMms is null)
            {
                throw new ArgumentException($"AssemblyMms with id = {id} doesn't exist");
            }

            _context.AssemblyMms.Remove(assemblyMms);
            _context.SaveChanges();
        }

        public AssemblyMms GetAssemblyMms(string id)
        {
            var assemblyMms = _context.AssemblyMms.Include(a => a.ConfiguringMms)
                                                  .Include(a=>a.MakeProduct)
                                                  .Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();
            return assemblyMms;
        }
        public List<AssemblyMms> GetAssemblyMmsByIds(IEnumerable<string> ids)
        {
            return _context.AssemblyMms.Include(a => a.Author)
                .Where(a => ids.Contains(a.Id)).ToList();
        }
        public AssemblyMms UpdateAssemblyMms(UpdateAssemblyMms updateAssemblyMmsModel)
        {
            var assemblyMms = _context.AssemblyMms.Where(a => a.Id.Equals(updateAssemblyMmsModel.Id)).SingleOrDefault();
            if (assemblyMms is null) throw new Exception("");

            if (updateAssemblyMmsModel.Accelerometer != null)
            {
                assemblyMms.Accelerometer = updateAssemblyMmsModel.Accelerometer;
            }

            if (updateAssemblyMmsModel.Gyroscope != null)
            {
                assemblyMms.Gyroscope = updateAssemblyMmsModel.Gyroscope;
            }

            if (updateAssemblyMmsModel.TypeOfIc != null)
            {
                assemblyMms.TypeOfIc = updateAssemblyMmsModel.TypeOfIc;
            }

            if (updateAssemblyMmsModel.StructureOfSensor != null)
            {
                assemblyMms.StructureOfSensor = updateAssemblyMmsModel.StructureOfSensor;
            }
            if (updateAssemblyMmsModel.Substrate.HasValue)
            {
                assemblyMms.Substrate = updateAssemblyMmsModel.Substrate.Value;
            }
            if (updateAssemblyMmsModel.Date.HasValue)
            {
                assemblyMms.Date = updateAssemblyMmsModel.Date.Value;
            }

            if (updateAssemblyMmsModel.Consignment != null)
            {
                assemblyMms.Consignment = updateAssemblyMmsModel.Consignment;
            }

            if (updateAssemblyMmsModel.Author != null)
            {
                assemblyMms.Author = updateAssemblyMmsModel.Author;
            }

            if (updateAssemblyMmsModel.ConfiguringMms != null)
            {
                assemblyMms.ConfiguringMms = updateAssemblyMmsModel.ConfiguringMms;
            }

            if (updateAssemblyMmsModel.MakeProduct != null)
            {
                assemblyMms.MakeProduct = updateAssemblyMmsModel.MakeProduct;
            }

            if (updateAssemblyMmsModel.ConfiguringMms != null)
            {
                assemblyMms.ConfiguringMms = updateAssemblyMmsModel.ConfiguringMms;
            }

            _context.SaveChanges();

            return assemblyMms;
        }
    }
}
