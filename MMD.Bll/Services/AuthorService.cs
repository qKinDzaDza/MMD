using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Linq;

namespace MMD.Bll
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;   
        private readonly IAssemblyMmsService _assemblyMmsService;
        private readonly ICalibrationMmsService _calibrationMmsService;
        private readonly ICalibrationProductService _calibrationProductService;
        private readonly IConfiguringMmsService _configuringMmsService;
        private readonly IConfiguringProductService _configuringProductService;
        private readonly IMakeProductService _makeProductService;
        private readonly IMobileTestingMmsService _mobileTestingMmsService;
        private readonly IMobileTestingProductService _mobileTestingProductService;
        private readonly IStationaryTestingMmsService _stationaryTestingMmsService;
        private readonly IStationaryTestingProductService _stationaryTestingProductService;
        private readonly IWarehouseService _warehouseService;

        public AuthorService(IAuthorRepository authorRepository,
            IAssemblyMmsService assemblyMmsService, ICalibrationMmsService calibrationMmsService,
            ICalibrationProductService calibrationProductService, 
            IConfiguringMmsService configuringMmsService, IConfiguringProductService configuringProductService,
            IMakeProductService makeProductService, IMobileTestingMmsService mobileTestingMmsService,
            IMobileTestingProductService mobileTestingProductService,
            IStationaryTestingMmsService stationaryTestingMmsService,
            IStationaryTestingProductService stationaryTestingProduct,
            IWarehouseService warehouseService            
            )
        {
            _authorRepository = authorRepository;
            _assemblyMmsService = assemblyMmsService;
            _calibrationMmsService = calibrationMmsService;
            _calibrationProductService = calibrationProductService;
            _configuringMmsService = configuringMmsService;
            _configuringProductService = configuringProductService;
            _makeProductService = makeProductService;
            _mobileTestingMmsService = mobileTestingMmsService;
            _mobileTestingProductService = mobileTestingProductService;
            _stationaryTestingMmsService = stationaryTestingMmsService;
            _stationaryTestingProductService = stationaryTestingProduct;
            _warehouseService = warehouseService;
        }

        public Author CreateAuthor(Author author)
        {
             
            if (author.AssemblyMmsIds != null)
            {
                var assemblyMmses = _assemblyMmsService.GetAssemblyMmsByIds(author.AssemblyMmsIds);
                if (assemblyMmses.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                author.AssemblyMms = assemblyMmses;
            }

            if (author.CalibrationMmsIds != null)
            {
                var calibrationMmses = _calibrationMmsService.GetCalibrationMmsByIds
                    (author.CalibrationMmsIds);
                if (calibrationMmses.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                author.CalibrationMms = calibrationMmses;
            }

            if (author.CalibrationProductIds != null)
            {
                var calibrationProducts = _calibrationProductService.GetCalibrationProductByIds
                    (author.CalibrationProductIds);
                if (calibrationProducts.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                author.CalibrationProduct = calibrationProducts;
            }

            if (author.ConfiguringMmsIds != null)
            {
                var configuringMmses = _configuringMmsService.GetConfiguringMmsByIds
                     (author.ConfiguringMmsIds);
                if (configuringMmses.Any(a => a.Author != null)) throw new ArgumentException
                    ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                author.ConfiguringMms = configuringMmses;
            }

            if (author.ConfiguringProductIds != null)
            {
                var configuringProducts = _configuringProductService.GetConfiguringProductByIds
                    (author.ConfiguringProductIds);
                if (configuringProducts.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST"); ;
                author.ConfiguringProduct = configuringProducts;
            }

            if (author.MakeProductIds != null)
            {
               var makeProducts = _makeProductService.GetMakeProductByIds
                    (author.MakeProductIds);
              if (makeProducts.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                author.MakeProduct = makeProducts;
            }

            if (author.MobileTestingMmsIds != null)
            {
                var mobileTestingMmses = _mobileTestingMmsService.GetMobileTestingMmsByIds
                    (author.MobileTestingMmsIds);
                if (mobileTestingMmses.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                author.MobileTestingMms = mobileTestingMmses;
            }
            
            if (author.MobileTestingProductIds != null)
            {
                var mobileTestingProducts = _mobileTestingProductService
                    .GetMobileTestingProductByIds(author.MobileTestingProductIds);
                if (mobileTestingProducts.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                author.MobileTestingProduct = mobileTestingProducts;              
            }

            if (author.StationaryTestingMmsIds != null)
            {
                var stationaryTestingMmses = _stationaryTestingMmsService
                    .GetStationaryTestingMmsByIds(author.StationaryTestingMmsIds);
                if (stationaryTestingMmses.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                author.StationaryTestingMms = stationaryTestingMmses;
            }

            if (author.StationaryTestingProductIds != null)
            {
                var stationaryTestingProducts = _stationaryTestingProductService
                   .GetStationaryTestingProductByIds(author.StationaryTestingProductIds);
                if (stationaryTestingProducts.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                author.StationaryTestingProduct = stationaryTestingProducts;
            }

            if (author.WarehouseIds != null)
            {
                var warehouses = _warehouseService.GetWarehouseByIds(author.WarehouseIds);
                if (warehouses.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                author.Warehouse = warehouses;
            }

            return _authorRepository.CreateAuthor(author);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.DeleteAuthor(id);
        }

        public Author GetAuthor(int id)
        {
            return _authorRepository.GetAuthor(id);
        }

        public Author UpdateAuthor(UpdateAuthor updateAuthor)
        {
            if (updateAuthor.AssemblyMmsIds != null)
            {
                var assemblyMmses = _assemblyMmsService.GetAssemblyMmsByIds(updateAuthor.AssemblyMmsIds);
                if (assemblyMmses.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                updateAuthor.AssemblyMms = assemblyMmses;
            }

            if (updateAuthor.CalibrationMmsIds != null)
            {
                var calibrationMmses = _calibrationMmsService.GetCalibrationMmsByIds
                    (updateAuthor.CalibrationMmsIds);
                if (calibrationMmses.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                updateAuthor.CalibrationMms = calibrationMmses;
            }

            if (updateAuthor.CalibrationProductIds != null)
            {
                var calibrationProducts = _calibrationProductService.GetCalibrationProductByIds
                    (updateAuthor.CalibrationProductIds);
                if (calibrationProducts.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                updateAuthor.CalibrationProduct = calibrationProducts;
            }

            if (updateAuthor.ConfiguringMmsIds != null)
            {
                var configuringMmses = _configuringMmsService.GetConfiguringMmsByIds
                     (updateAuthor.ConfiguringMmsIds);
                if (configuringMmses.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                updateAuthor.ConfiguringMms = configuringMmses;
            }

            if (updateAuthor.ConfiguringProductIds != null)
            {
                var configuringProducts = _configuringProductService.GetConfiguringProductByIds
                    (updateAuthor.ConfiguringProductIds);
                if (configuringProducts.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                updateAuthor.ConfiguringProduct = configuringProducts;
            }

            if (updateAuthor.MakeProductIds != null)
            {
               var makeProducts = _makeProductService.GetMakeProductByIds
                    (updateAuthor.MakeProductIds);
              if (makeProducts.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                updateAuthor.MakeProduct = makeProducts;
            }

            if (updateAuthor.MobileTestingMmsIds != null)
            {
                var mobileTestingMmses = _mobileTestingMmsService.GetMobileTestingMmsByIds
                    (updateAuthor.MobileTestingMmsIds);
                if (mobileTestingMmses.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                updateAuthor.MobileTestingMms = mobileTestingMmses;
            }
            
            if (updateAuthor.MobileTestingProductIds != null)
            {
                var mobileTestingProducts = _mobileTestingProductService
                    .GetMobileTestingProductByIds(updateAuthor.MobileTestingProductIds);
                if (mobileTestingProducts.Any(a => a.Author != null)) throw new ArgumentException
                    ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                updateAuthor.MobileTestingProduct = mobileTestingProducts;              
            }

            if (updateAuthor.StationaryTestingMmsIds != null)
            {
                var stationaryTestingMmses = _stationaryTestingMmsService
                    .GetStationaryTestingMmsByIds(updateAuthor.StationaryTestingMmsIds);
                if (stationaryTestingMmses.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                updateAuthor.StationaryTestingMms = stationaryTestingMmses;
            }

            if (updateAuthor.StationaryTestingProductIds != null)
            {
                var stationaryTestingProducts = _stationaryTestingProductService
                   .GetStationaryTestingProductByIds(updateAuthor.StationaryTestingProductIds);
                if (stationaryTestingProducts.Any(a => a.Author != null)) throw new ArgumentException
                   ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                updateAuthor.StationaryTestingProduct = stationaryTestingProducts;
            }

            if (updateAuthor.WarehouseIds != null)
            {
                var warehouses = _warehouseService.GetWarehouseByIds(updateAuthor.WarehouseIds);
                if (warehouses.Any(a => a.Author != null)) throw new ArgumentException
                    ($"THERE IS ANOTHER AUTHOR FROM SOMEONE ON THE LIST");
                updateAuthor.Warehouse = warehouses;
            }

            return _authorRepository.UpdateAuthor(updateAuthor);
        }
    }
}
