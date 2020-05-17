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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext _context;

        public AuthorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Author CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            
            return author;
        }

        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.Where(a => a.Id.Equals(id))
                                                  .SingleOrDefault();
            if (author is null) throw new ArgumentException
                   ($"Author with id = {id} doesn't exist");

            var assemblyMmses = _context.AssemblyMms.Where(a => a.AuthorId == id);
            foreach(var assemblyMms in assemblyMmses)
            {
                assemblyMms.AuthorId = null;
            }

            var makeProducts = _context.MakeProducts.Where(a => a.AuthorId == id);
            foreach (var makeProduct in makeProducts)
            {
                makeProduct.AuthorId = null;
            }

            var calibrationMmses = _context.CalibrationMmses.Where(a => a.AuthorId == id);
            foreach (var calibrationMms in calibrationMmses)
            {
                calibrationMms.AuthorId = null;
            }

            var calibrationProducts = _context.CalibrationProducts.Where(a => a.AuthorId == id);
            foreach (var calibrationProduct in calibrationProducts)
            {
                calibrationProduct.AuthorId = null;
            }

            var configuringMmses = _context.ConfiguringMmses.Where(a => a.AuthorId == id);
            foreach (var configuringMms in configuringMmses)
            {
                configuringMms.AuthorId = null;
            }

            var configuringProducts = _context.ConfiguringProducts.Where(a => a.AuthorId == id);
            foreach (var configuringProduct in configuringProducts)
            {
                configuringProduct.AuthorId = null;
            }

            var mobileTestingMmses = _context.MobileTestingMmses.Where(a => a.AuthorId == id);
            foreach (var mobileTestingMms in mobileTestingMmses)
            {
                mobileTestingMms.AuthorId = null;
            }

            var mobileTestingProducts = _context.MobileTestingProducts.Where(a => a.AuthorId == id);
            foreach (var mobileTestingProduct in mobileTestingProducts)
            {
                mobileTestingProduct.AuthorId = null;
            }

            var stationaryTestingProducts = _context.StationaryTestingProducts.Where(a => a.AuthorId == id);
            foreach (var stationaryTestingProduct in stationaryTestingProducts)
            {
                stationaryTestingProduct.AuthorId = null;
            }

            var stationaryTestingMmses= _context.StationaryTestingMms.Where(a => a.AuthorId == id);
            foreach (var stationaryTestingMms in stationaryTestingMmses)
            {
                stationaryTestingMms.AuthorId = null;
            }

            var warehouses = _context.Warehouses.Where(a => a.AuthorId == id);
            foreach (var warehouse in warehouses)
            {
                warehouse.AuthorId = null;
            }


            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public Author GetAuthor(int id)
        {
            Author author = _context.Authors.Where(a => a.Id.Equals(id))
                                                          .SingleOrDefault();
            author.AssemblyMmsIds = _context.AssemblyMms.
                Where(a => a.Author.Id.Equals(id)).Select(a => a.Id).ToList();
           
            author.MakeProductIds = _context.MakeProducts.
                Where(a => a.Author.Id.Equals(id)).Select(a => a.Id).ToList();
            
            author.CalibrationMmsIds = _context.CalibrationMmses.
                Where(a => a.Author.Id.Equals(id)).Select(a => a.Id).ToList();
            
            author.CalibrationProductIds = _context.CalibrationProducts.
                Where(a => a.Author.Id.Equals(id)).Select(a => a.Id).ToList();
            
            author.ConfiguringMmsIds = _context.ConfiguringMmses.
                Where(a => a.Author.Id.Equals(id)).Select(a => a.Id).ToList();
            
            author.ConfiguringProductIds = _context.ConfiguringProducts.
                Where(a => a.Author.Id.Equals(id)).Select(a => a.Id).ToList();
            
            author.MobileTestingMmsIds = _context.MobileTestingMmses.
                Where(a => a.Author.Id.Equals(id)).Select(a => a.Id).ToList();

            author.MobileTestingProductIds = _context.MobileTestingProducts.
                Where(a => a.Author.Id.Equals(id)).Select(a => a.Id).ToList();

            author.StationaryTestingMmsIds = _context.StationaryTestingMms.
                Where(a => a.Author.Id.Equals(id)).Select(a => a.Id).ToList();

            author.StationaryTestingProductIds = _context.StationaryTestingProducts.
                Where(a => a.Author.Id.Equals(id)).Select(a => a.Id).ToList();

            author.WarehouseIds = _context.Warehouses.
                Where(a => a.Author.Id.Equals(id)).Select(a => a.Id).ToList();

            return author;
        }

        public Author UpdateAuthor(UpdateAuthor updateAuthor)
        {
            var author = _context.Authors.Where(a => a.Id.Equals(updateAuthor.Id)).SingleOrDefault();
            if (author is null) throw new Exception("");

            if (updateAuthor.Name != null)
            {
                author.Name = updateAuthor.Name;
            }
            if (updateAuthor.AssemblyMms != null)
            {
                author.AssemblyMms = updateAuthor.AssemblyMms;
            }
            if (updateAuthor.MakeProduct != null)
            {
                author.MakeProduct = updateAuthor.MakeProduct;
            }
            if (updateAuthor.CalibrationMms != null)
            {
                author.CalibrationMms = updateAuthor.CalibrationMms;
            }
            if (updateAuthor.CalibrationProduct != null)
            {
                author.CalibrationProduct = updateAuthor.CalibrationProduct;
            }
            if (updateAuthor.ConfiguringMms != null)
            {
                author.ConfiguringMms = updateAuthor.ConfiguringMms;
            }
            if (updateAuthor.ConfiguringProduct != null)
            {
                author.ConfiguringProduct = updateAuthor.ConfiguringProduct;
            }
            if (updateAuthor.MobileTestingProduct != null)
            {
                author.MobileTestingProduct = updateAuthor.MobileTestingProduct;
            }

            if (updateAuthor.MobileTestingMms != null)
            {
                author.MobileTestingMms = updateAuthor.MobileTestingMms;
            }
            if (updateAuthor.StationaryTestingMms != null)
            {
                author.StationaryTestingMms = updateAuthor.StationaryTestingMms;
            }
            if (updateAuthor.StationaryTestingProduct != null)
            {
                author.StationaryTestingProduct = updateAuthor.StationaryTestingProduct;
            }
            if (updateAuthor.Warehouse != null)
            {
                author.Warehouse = updateAuthor.Warehouse;
            }

            _context.SaveChanges();

            return author;
        }
    }
}
