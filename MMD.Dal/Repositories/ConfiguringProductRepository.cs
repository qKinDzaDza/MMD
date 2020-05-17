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
    public class ConfiguringProductRepository : IConfiguringProductRepository
    {
        private readonly ApplicationContext _context;

        public ConfiguringProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ConfiguringProduct CreateConfiguringProduct(ConfiguringProduct configuringProduct)
        {
            _context.ConfiguringProducts.Add(configuringProduct);
            _context.SaveChanges();
            
            return configuringProduct;
        }
        public List<ConfiguringProduct> GetConfiguringProductByIds(IEnumerable<int> ids)
        {
            var configuringProduct = _context.ConfiguringProducts
                .Include(a => a.Author)
                .Where(a => ids.Contains(a.Id)).ToList();
            return configuringProduct;
        }

        public void DeleteConfiguringProduct(int id)
        {
            var configuringProduct = _context.ConfiguringProducts.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();

            if (configuringProduct is null) throw new ArgumentException
                   ($"ConfiguringProduct with id = {id} doesn't exist");

            _context.ConfiguringProducts.Remove(configuringProduct);
            _context.SaveChanges();
        }

        public ConfiguringProduct GetConfiguringProduct(int id)
        {
            ConfiguringProduct configuringProduct = _context.ConfiguringProducts
                .Include(a => a.MobileTestingProduct)
                .Where(a => a.Id.Equals(id))
                .SingleOrDefault();
            return configuringProduct;
        }

        public ConfiguringProduct UpdateConfiguringProduct(UpdateConfiguringProduct updateConfiguringProduct)
        {
            var configuringProduct = _context.ConfiguringProducts.Where(a => a.Id.Equals(updateConfiguringProduct.Id)).SingleOrDefault();
            if (configuringProduct is null) throw new Exception("");

            if (updateConfiguringProduct.Author != null)
            {
                configuringProduct.Author = updateConfiguringProduct.Author;
            }
            if (updateConfiguringProduct.ReasonDefects != null)
            {
                configuringProduct.ReasonDefects = updateConfiguringProduct.ReasonDefects;
            }
            if (updateConfiguringProduct.MakeProduct != null)
            {
                configuringProduct.MakeProduct = updateConfiguringProduct.MakeProduct;
            }
            if (updateConfiguringProduct.MobileTestingProduct != null)
            {
                configuringProduct.MobileTestingProduct 
                    = updateConfiguringProduct.MobileTestingProduct;
            }


            if (updateConfiguringProduct.Date.HasValue)
            {
                configuringProduct.Date = updateConfiguringProduct.Date.Value;
            }
            if (updateConfiguringProduct.ResultConfiguring.HasValue)
            {
                configuringProduct.ResultConfiguring = updateConfiguringProduct.ResultConfiguring.Value;
            }
            _context.SaveChanges();

            return configuringProduct;
        }
    }
}
