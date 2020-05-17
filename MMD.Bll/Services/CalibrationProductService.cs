using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;

namespace MMD.Bll
{
    public class CalibrationProductService : ICalibrationProductService
    {
        private readonly ICalibrationProductRepository _calibrationProductRepository;
        private readonly IMobileTestingProductRepository _mobileTestingProductRepository;
        private readonly IStationaryTestingProductService _stationaryTestingProductService;
        private readonly IAuthorRepository _authorRepository;
        public CalibrationProductService(ICalibrationProductRepository calibrationProductRepository,
            IMobileTestingProductRepository mobileTestingProductRepository,
            IStationaryTestingProductService stationaryTestingProductService,
            IAuthorRepository authorRepository)
        {
            _calibrationProductRepository = calibrationProductRepository;
            _mobileTestingProductRepository = mobileTestingProductRepository;
            _stationaryTestingProductService = stationaryTestingProductService;
            _authorRepository = authorRepository;
        }
        public List<CalibrationProduct> GetCalibrationProductByIds(IEnumerable<int> ids)
        {
            return _calibrationProductRepository.GetCalibrationProductByIds(ids);
        }

        public CalibrationProduct CreateCalibrationProduct(CalibrationProduct calibrationProduct)
        {
            if (calibrationProduct.MobileTestingProductId != 0)
            {
                var mobileTestingProduct = _mobileTestingProductRepository
                    .GetMobileTestingProduct(calibrationProduct.MobileTestingProductId);
                if (mobileTestingProduct.CalibrationProduct != null) throw new Exception();
                    calibrationProduct.MobileTestingProduct = mobileTestingProduct;            
            }
            else
                throw new ArgumentException($"Please, enter ID Mobile Testing ");
            if (calibrationProduct.AuthorId != null)
            {
                calibrationProduct.Author = _authorRepository
                    .GetAuthor(calibrationProduct.AuthorId.Value);
            }

            return _calibrationProductRepository.CreateCalibrationProduct(calibrationProduct);
        }
        public CalibrationProduct UpdateCalibrationProduct
            (UpdateCalibrationProduct updateCalibrationProduct)
        {
            if (updateCalibrationProduct.MobileTestingProductId != 0)
            {
                var mobileTestingProduct = _mobileTestingProductRepository
                    .GetMobileTestingProduct(updateCalibrationProduct.MobileTestingProductId);
                if (mobileTestingProduct.CalibrationProduct != null) throw new Exception();
                updateCalibrationProduct.MobileTestingProduct = mobileTestingProduct;
            }
            if (updateCalibrationProduct.AuthorId != null)
            {
                updateCalibrationProduct.Author = _authorRepository
                    .GetAuthor(updateCalibrationProduct.AuthorId.Value);
            }

            return _calibrationProductRepository.
                UpdateCalibrationProduct(updateCalibrationProduct);
        }

        public void DeleteCalibrationProduct(int id)
        {
            var сalibrationProduct = GetCalibrationProduct(id);

            if (сalibrationProduct is null) throw new ArgumentException
                   ($"CalibrationProduct with id = {id} doesn't exist");

            if (сalibrationProduct.StationaryTestingProduct != null)
            {
                _stationaryTestingProductService.DeleteStationaryTestingProduct
                    (сalibrationProduct.StationaryTestingProduct.Id);
            }
                
            _calibrationProductRepository.DeleteCalibrationProduct(id);
        }

        public CalibrationProduct GetCalibrationProduct(int id)
        {
            return _calibrationProductRepository.GetCalibrationProduct(id);
        }

        
    }
}
