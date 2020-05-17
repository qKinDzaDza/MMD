using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;

namespace MMD.Bll
{
    public class ConfiguringProductService : IConfiguringProductService
    {
        private readonly IConfiguringProductRepository _configuringProductRepository;
        private readonly IMakeProductRepository _makeProductRepository;
        private readonly IMobileTestingProductService _mobileTestingProductService;
        private readonly IAuthorRepository _authorRepository;
        public ConfiguringProductService(IConfiguringProductRepository configuringProductRepository,
            IMakeProductRepository makeProductRepository,
            IMobileTestingProductService mobileTestingProductService,
            IAuthorRepository authorRepository)
        {
            _configuringProductRepository = configuringProductRepository;
            _makeProductRepository = makeProductRepository;
            _mobileTestingProductService = mobileTestingProductService;
            _authorRepository = authorRepository;
        }
        public List<ConfiguringProduct> GetConfiguringProductByIds(IEnumerable<int> ids)
        {
            return _configuringProductRepository.GetConfiguringProductByIds(ids);
        }
        public ConfiguringProduct CreateConfiguringProduct(ConfiguringProduct configuringProduct)
        {
            if (configuringProduct.MakeProductId != null)
            {
               var makeProduct = _makeProductRepository.
                    GetMakeProduct(configuringProduct.MakeProductId);
                if (makeProduct.ConfiguringProduct != null) throw new Exception();
                configuringProduct.MakeProduct = makeProduct;
            }
            else
                throw new ArgumentException($"Please, enter ID Make Product ");
            
            if (configuringProduct.AuthorId != null)
            {
                configuringProduct.Author = _authorRepository
                    .GetAuthor(configuringProduct.AuthorId.Value);
            }

            return _configuringProductRepository.CreateConfiguringProduct(configuringProduct);
        }
        public ConfiguringProduct UpdateConfiguringProduct
            (UpdateConfiguringProduct updateConfiguringProduct)
        {
            if (updateConfiguringProduct.MakeProductId != null)
            {
                var makeProduct = _makeProductRepository.
                    GetMakeProduct(updateConfiguringProduct.MakeProductId);
                if (makeProduct.ConfiguringProduct != null) throw new Exception();
                updateConfiguringProduct.MakeProduct = makeProduct;
            }
            if (updateConfiguringProduct.AuthorId != null)
            {
                updateConfiguringProduct.Author = _authorRepository
                    .GetAuthor(updateConfiguringProduct.AuthorId.Value);
            }
            return _configuringProductRepository.UpdateConfiguringProduct
                (updateConfiguringProduct);
        }

        public void DeleteConfiguringProduct(int id)
        {
            var configuringProduct = GetConfiguringProduct(id);

            if (configuringProduct is null) throw new ArgumentException
                   ($"ConfiguringProduct with id = {id} doesn't exist");
            if (configuringProduct.MobileTestingProduct !=null)
            {
                _mobileTestingProductService.DeleteMobileTestingProduct
                    (configuringProduct.MobileTestingProduct.Id);
            }

            _configuringProductRepository.DeleteConfiguringProduct(id);
        }

        public ConfiguringProduct GetConfiguringProduct(int id)
        {
            return _configuringProductRepository.GetConfiguringProduct(id);
        }

        
    }
}
