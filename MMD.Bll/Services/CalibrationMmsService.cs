using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;

namespace MMD.Bll
{
    public class CalibrationMmsService : ICalibrationMmsService
    {
        private readonly ICalibrationMmsRepository _calibrationMmsRepository;
        private readonly IMobileTestingMmsRepository _mobileTestingMmsRepository;
        private readonly IStationaryTestingMmsService _stationaryTestingMmsService;
        private readonly IAuthorRepository _authorRepository;
        public CalibrationMmsService(ICalibrationMmsRepository calibrationMmsRepository,
           IMobileTestingMmsRepository mobileTestingMmsRepository,
           IStationaryTestingMmsService stationaryTestingMmsService,
           IAuthorRepository authorRepository)
        {
            _calibrationMmsRepository = calibrationMmsRepository;
            _mobileTestingMmsRepository = mobileTestingMmsRepository;
            _stationaryTestingMmsService = stationaryTestingMmsService;
            _authorRepository = authorRepository;
        }
        public List<CalibrationMms> GetCalibrationMmsByIds(IEnumerable<int> ids)
        {
            return _calibrationMmsRepository.GetCalibrationMmsByIds(ids);
        }

        public CalibrationMms CreateCalibrationMms(CalibrationMms calibrationMms)
        {
            if (calibrationMms.MobileTestingMmsId != 0)
            {
                var mobileTestingMms = _mobileTestingMmsRepository.
                    GetMobileTestingMms(calibrationMms.MobileTestingMmsId);
                if (mobileTestingMms.CalibrationMms != null) throw new Exception();
                calibrationMms.MobileTestingMms = mobileTestingMms;
            }
            else
                throw new ArgumentException($"Please, enter ID Mobile Testing ");
            if (calibrationMms.AuthorId != null)
            {
                calibrationMms.Author = _authorRepository.GetAuthor(calibrationMms.AuthorId.Value);
            }

            return _calibrationMmsRepository.CreateCalibrationMms(calibrationMms);
        }
        public CalibrationMms UpdateCalibrationMms
            (UpdateCalibrationMms updateCalibrationMms)
        {
            if (updateCalibrationMms.MobileTestingMmsId != 0)
            {
                var mobileTestingMms = _mobileTestingMmsRepository.
                    GetMobileTestingMms(updateCalibrationMms.MobileTestingMmsId);
                if (mobileTestingMms.CalibrationMms != null) throw new Exception();
                updateCalibrationMms.MobileTestingMms = mobileTestingMms;
            }
            if (updateCalibrationMms.AuthorId != null)
            {
                updateCalibrationMms.Author = _authorRepository
                    .GetAuthor(updateCalibrationMms.AuthorId.Value);
            }

            return _calibrationMmsRepository.UpdateCalibrationMms(updateCalibrationMms);
        }

        public void DeleteCalibrationMms(int id)
        {
            var сalibrationMms = GetCalibrationMms(id);
            
            if (сalibrationMms is null) throw new ArgumentException
                   ($"CalibrationMms with id = {id} doesn't exist");

            if (сalibrationMms.StationaryTestingMms != null)
            {     
                _stationaryTestingMmsService.DeleteStationaryTestingMms
                     (сalibrationMms.StationaryTestingMms.Id);
            }

            _calibrationMmsRepository.DeleteCalibrationMms(id);
        }

        public CalibrationMms GetCalibrationMms(int id)
        {
            return _calibrationMmsRepository.GetCalibrationMms(id);
        }

        
    }
}
