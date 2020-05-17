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
    public class ConfiguringMmsRepository : IConfiguringMmsRepository
    {
        private readonly ApplicationContext _context;

        public ConfiguringMmsRepository(ApplicationContext context)
        {
            _context = context;
        }
        public List<ConfiguringMms> GetConfiguringMmsByIds(IEnumerable<int> ids)
        {
            return _context.ConfiguringMmses.Include(a => a.Author)
                .Where(a => ids.Contains(a.Id)).ToList();
        }

        public ConfiguringMms CreateConfiguringMms(ConfiguringMms configuringMms)
        {
            _context.ConfiguringMmses.Add(configuringMms);
            _context.SaveChanges();
            
            return configuringMms;
        }

        public void DeleteConfiguringMms(int id)
        {
            var configuringMms = _context.ConfiguringMmses.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();

            if (configuringMms is null) throw new ArgumentException
                   ($"ConfiguringMms with id = {id} doesn't exist");

            _context.ConfiguringMmses.Remove(configuringMms);
            _context.SaveChanges();
        }

        public ConfiguringMms GetConfiguringMms(int id)
        {
            var configuringMms = _context.ConfiguringMmses.Include(a=>a.MobileTestingMms).
                Where(a => a.Id.Equals(id)).SingleOrDefault();
            return configuringMms;
        }

        public ConfiguringMms UpdateConfiguringMms(UpdateConfiguringMms updateConfiguringMms)
        {
            var configuringMms = _context.ConfiguringMmses.Where(a => a.Id.Equals(updateConfiguringMms.Id)).SingleOrDefault();
            if (configuringMms is null) throw new Exception("");

            if (updateConfiguringMms.Author != null)
            {
                configuringMms.Author = updateConfiguringMms.Author;
            }
            if (updateConfiguringMms.ReasonDefects != null)
            {
                configuringMms.ReasonDefects = updateConfiguringMms.ReasonDefects;
            }
            if (updateConfiguringMms.AssemblyMms != null)
            {
                configuringMms.AssemblyMms = updateConfiguringMms.AssemblyMms;
            }
            if (updateConfiguringMms.MobileTestingMms != null)
            {
                configuringMms.MobileTestingMms = updateConfiguringMms.MobileTestingMms;
            }


            if (updateConfiguringMms.Date.HasValue)
            {
                configuringMms.Date = updateConfiguringMms.Date.Value;
            }
            if (updateConfiguringMms.ResultConfiguring.HasValue)
            {
                configuringMms.ResultConfiguring = updateConfiguringMms.ResultConfiguring.Value;
            }

            _context.SaveChanges();

            return configuringMms;
        }
    }
}
