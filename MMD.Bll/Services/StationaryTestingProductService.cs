using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;

namespace MMD.Bll
{
    public class StationaryTestingProductService : IStationaryTestingProductService
    {
        private readonly IStationaryTestingProductRepository _stationaryTestingProductRepository;
        private readonly ICalibrationProductRepository _calibrationProductRepository;
        private readonly IAuthorRepository _authorRepository;
        public StationaryTestingProductService(
            IStationaryTestingProductRepository stationaryTestingProductRepository,
            ICalibrationProductRepository calibrationProductRepository,
            IAuthorRepository authorRepository)
        {
            _stationaryTestingProductRepository = stationaryTestingProductRepository;
            _calibrationProductRepository = calibrationProductRepository;
            _authorRepository = authorRepository;
    }
        public List<StationaryTestingProduct> GetStationaryTestingProductByIds
            (IEnumerable<int> ids)
        {
            return _stationaryTestingProductRepository
                .GetStationaryTestingProductByIds(ids);
        }
        public StationaryTestingProduct CreateStationaryTestingProduct
            (StationaryTestingProduct stationaryTestingProduct)
        {
            if (stationaryTestingProduct.CalibrationProductId != 0)
            {
                var calibrationProduct = _calibrationProductRepository.
                    GetCalibrationProduct(stationaryTestingProduct.CalibrationProductId);
                if (calibrationProduct.StationaryTestingProduct != null) throw new Exception();
                stationaryTestingProduct.CalibrationProduct = calibrationProduct;
            }
            else throw new ArgumentException($"Please, enter ID Calibration ");
            if (stationaryTestingProduct.AuthorId != null)
            {
                stationaryTestingProduct.Author = _authorRepository
                    .GetAuthor(stationaryTestingProduct.AuthorId.Value);
            }
            return _stationaryTestingProductRepository.CreateStationaryTestingProduct
                (stationaryTestingProduct);
        }
        public StationaryTestingProduct UpdateStationaryTestingProduct
            (UpdateStationaryTestingProduct updateStationaryTestingProduct)
        {
            if (updateStationaryTestingProduct.CalibrationProductId != 0)
            {
                var calibrationProduct = _calibrationProductRepository.
                    GetCalibrationProduct(updateStationaryTestingProduct.CalibrationProductId);
                if (calibrationProduct.StationaryTestingProduct != null) throw new Exception();
                updateStationaryTestingProduct.CalibrationProduct = calibrationProduct;
            }
            if (updateStationaryTestingProduct.AuthorId != null)
            {
                updateStationaryTestingProduct.Author = _authorRepository
                    .GetAuthor(updateStationaryTestingProduct.AuthorId.Value);
            }
            return _stationaryTestingProductRepository.UpdateStationaryTestingProduct
                (updateStationaryTestingProduct);
        }

        public void DeleteStationaryTestingProduct(int  id)
        {
            _stationaryTestingProductRepository.DeleteStationaryTestingProduct(id);
        }

        public StationaryTestingProduct GetStationaryTestingProduct(int id)
        {
            return _stationaryTestingProductRepository.GetStationaryTestingProduct(id);
        }

        
    }
}
