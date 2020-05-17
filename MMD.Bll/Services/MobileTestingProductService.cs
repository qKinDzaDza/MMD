using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;

namespace MMD.Bll
{
    public class MobileTestingProductService : IMobileTestingProductService
    {
        private readonly IMobileTestingProductRepository _mobileTestingProductRepository;
        private readonly IConfiguringProductRepository _configuringProductRepository;
        private readonly ICalibrationProductService _calibrationProductService;
        private readonly IAuthorRepository _authorRepository;
        public MobileTestingProductService(IMobileTestingProductRepository 
            mobileTestingProductRepository,
            IConfiguringProductRepository configuringProductRepository,
            ICalibrationProductService calibrationProductService,
            IAuthorRepository authorRepository)
        {
            _mobileTestingProductRepository = mobileTestingProductRepository;
            _configuringProductRepository = configuringProductRepository;
            _calibrationProductService = calibrationProductService;
            _authorRepository = authorRepository;
        }

        public MobileTestingProduct CreateMobileTestingProduct
            (MobileTestingProduct mobileTestingProduct)
        {
            if (mobileTestingProduct.ConfiguringProductId != 0)
            {
               var configurongProduct = _configuringProductRepository.
                   GetConfiguringProduct(mobileTestingProduct.ConfiguringProductId);
                if (configurongProduct.MobileTestingProduct != null) throw new Exception();
                mobileTestingProduct.ConfiguringProduct = configurongProduct;
            }
            else throw new ArgumentException($"Please, enter ID Configuring ");
            if (mobileTestingProduct.AuthorId != null)
            {
                mobileTestingProduct.Author = _authorRepository
                    .GetAuthor(mobileTestingProduct.AuthorId.Value);
            }

            return _mobileTestingProductRepository.
                CreateMobileTestingProduct(mobileTestingProduct);
        }
        public MobileTestingProduct UpdateMobileTestingProduct
            (UpdateMobileTestingProduct updateMobileTestingProduct)
        {
            if (updateMobileTestingProduct.ConfiguringProductId != 0)
            {
                var configurongProduct = _configuringProductRepository.
                   GetConfiguringProduct(updateMobileTestingProduct.ConfiguringProductId);
                if (configurongProduct.MobileTestingProduct != null) throw new Exception();
                updateMobileTestingProduct.ConfiguringProduct = configurongProduct;
            }
            if (updateMobileTestingProduct.AuthorId != null)
            {
                updateMobileTestingProduct.Author = _authorRepository
                    .GetAuthor(updateMobileTestingProduct.AuthorId.Value);
            }

            return _mobileTestingProductRepository.UpdateMobileTestingProduct
                (updateMobileTestingProduct);
        }
        public List<MobileTestingProduct> GetMobileTestingProductByIds(IEnumerable<int> ids)
        {
            return _mobileTestingProductRepository.GetMobileTestingProductByIds(ids);
        }

        public void DeleteMobileTestingProduct(int id)
        {
            var mobileTestingProduct = GetMobileTestingProduct(id);
            if (mobileTestingProduct is null) throw new ArgumentException
                ($"MobileTestingProduct with id = {id} doesn't exist");
            if (mobileTestingProduct.CalibrationProduct !=null)
            {
                _calibrationProductService.DeleteCalibrationProduct
                (mobileTestingProduct.CalibrationProduct.Id);
            }          
            _mobileTestingProductRepository.DeleteMobileTestingProduct(id);
        }

        public MobileTestingProduct GetMobileTestingProduct(int id)
        {
            return _mobileTestingProductRepository.GetMobileTestingProduct(id);
        }

        
    }
}
