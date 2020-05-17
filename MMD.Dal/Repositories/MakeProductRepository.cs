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
    public class MakeProductRepository : IMakeProductRepository
    {
        private readonly ApplicationContext _context;

        public MakeProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public MakeProduct CreateMakeProduct(MakeProduct makeProduct)
        {
            _context.MakeProducts.Add(makeProduct);
            _context.SaveChanges();
            
            return makeProduct;
        }
        public List<MakeProduct> GetMakeProductByIds(IEnumerable<string> ids)
        {
            return _context.MakeProducts.Include(a => a.Author)
                .Where(a => ids.Contains(a.Id)).ToList();
        }

        public void DeleteMakeProduct(string id)
        {
            var makeProduct = _context.MakeProducts.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();

            if (makeProduct is null) throw new ArgumentException
                 ($"MakeProduct with id = {id} doesn't exist");

            _context.MakeProducts.Remove(makeProduct);
            _context.SaveChanges();
        }

        public MakeProduct GetMakeProduct(string id)
        {
            MakeProduct makeProduct = _context.MakeProducts.Where(a => a.Id.Equals(id))
                                                          .SingleOrDefault();
            return makeProduct;
        }

        public MakeProduct UpdateMakeProduct(UpdateMakeProduct updateMakeProduct)
        {
            var makeProduct = _context.MakeProducts.Where(a => a.Id.Equals(updateMakeProduct.Id)).SingleOrDefault();
            if (makeProduct is null) throw new Exception("");

            if (updateMakeProduct.Author != null)
            {
                makeProduct.Author = updateMakeProduct.Author;
            }
            if (updateMakeProduct.AssemblyMms != null)
            {
                makeProduct.AssemblyMms = updateMakeProduct.AssemblyMms;
            }
            if (updateMakeProduct.Warehouse != null)
            {
                makeProduct.Warehouse = updateMakeProduct.Warehouse;
            }
            if (updateMakeProduct.ConfiguringProduct != null)
            {
                makeProduct.ConfiguringProduct = 
                    updateMakeProduct.ConfiguringProduct;
            }


            if (updateMakeProduct.Date.HasValue)
            {
                makeProduct.Date = updateMakeProduct.Date.Value;
            }
            if (updateMakeProduct.NumberOfApplication != null)
            {
                makeProduct.NumberOfApplication = updateMakeProduct.NumberOfApplication;
            }


            _context.SaveChanges();

            return makeProduct;
        }
    }
}
