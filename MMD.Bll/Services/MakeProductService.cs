using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;

namespace MMD.Bll
{
    public class MakeProductService : IMakeProductService
    {
        private readonly IMakeProductRepository _makeProductRepository;
        private readonly IAssemblyMmsRepository _assemblyMmsRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IWarehouseRepository _warehouseRepository;

        public MakeProductService(IMakeProductRepository makeProductRepository,
            IAssemblyMmsRepository assemblyMmsRepository,
            IAuthorRepository authorRepository,
            IWarehouseRepository warehouseRepository)
        {
            _makeProductRepository = makeProductRepository;
            _assemblyMmsRepository = assemblyMmsRepository;
            _authorRepository = authorRepository;
            _warehouseRepository = warehouseRepository;
        }
        public List<MakeProduct> GetMakeProductByIds(IEnumerable<string> ids)
        {
            return _makeProductRepository.GetMakeProductByIds(ids);
        }

        public MakeProduct CreateMakeProduct(MakeProduct makeProduct)
        {
            if (makeProduct.AssemblyMmsId != null)
            {
                makeProduct.AssemblyMms = _assemblyMmsRepository
                    .GetAssemblyMms(makeProduct.AssemblyMmsId);
            }
            else throw new ArgumentException($"Please, enter ID Assembly Mms ");           
            if (makeProduct.AuthorId != null)
            {
                makeProduct.Author = _authorRepository
                    .GetAuthor(makeProduct.AuthorId.Value);
            }
            if (makeProduct.WarehouseId != null)
            {
                makeProduct.Warehouse = _warehouseRepository
                    .GetWarehouse(makeProduct.WarehouseId.Value);
            }

            return _makeProductRepository.CreateMakeProduct(makeProduct);
        }
        public MakeProduct UpdateMakeProduct(UpdateMakeProduct updateMakeProduct)
        {
            if (updateMakeProduct.AssemblyMmsId != null)
            {
                updateMakeProduct.AssemblyMms = _assemblyMmsRepository.
                    GetAssemblyMms(updateMakeProduct.AssemblyMmsId);
            }
            if (updateMakeProduct.AuthorId != null)
            {
                updateMakeProduct.Author = _authorRepository
                    .GetAuthor(updateMakeProduct.AuthorId.Value);
            }
            if (updateMakeProduct.WarehouseId != null)
            {
                updateMakeProduct.Warehouse = _warehouseRepository
                    .GetWarehouse(updateMakeProduct.WarehouseId.Value);
            }
            return _makeProductRepository.UpdateMakeProduct(updateMakeProduct);
        }

        public void DeleteMakeProduct(string id)
        {
            _makeProductRepository.DeleteMakeProduct(id);
        }

        public MakeProduct GetMakeProduct(string id)
        {
            return _makeProductRepository.GetMakeProduct(id);
        }

        
    }
}
