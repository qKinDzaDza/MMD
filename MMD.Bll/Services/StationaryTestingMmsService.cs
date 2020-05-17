using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;

namespace MMD.Bll
{
    public class StationaryTestingMmsService : IStationaryTestingMmsService
    {
        private readonly IStationaryTestingMmsRepository _stationaryTestingMmsRepository;
        private readonly ICalibrationMmsRepository _calibrationMmsRepository;
        private readonly IAuthorRepository _authorRepository;

        public StationaryTestingMmsService
            (IStationaryTestingMmsRepository stationaryTestingMmsRepository,
            ICalibrationMmsRepository calibrationMmsRepository,
            IAuthorRepository authorRepository)
        {
            _stationaryTestingMmsRepository = stationaryTestingMmsRepository;
            _calibrationMmsRepository = calibrationMmsRepository;
            _authorRepository = authorRepository;
        }

        public StationaryTestingMms CreateStationaryTestingMms
            (StationaryTestingMms stationaryTestingMms)
        {
            if (stationaryTestingMms.CalibrationMmsId != 0)
            {
                var calibrationMms = _calibrationMmsRepository.
                    GetCalibrationMms(stationaryTestingMms.CalibrationMmsId);
                if (calibrationMms.StationaryTestingMms != null) throw new Exception();
                stationaryTestingMms.CalibrationMms = calibrationMms;
            }
            else throw new ArgumentException($"Please, enter ID Calibration ");
            if (stationaryTestingMms.AuthorId != null)
            {
                stationaryTestingMms.Author = _authorRepository
                    .GetAuthor(stationaryTestingMms.AuthorId.Value);
            }
            return _stationaryTestingMmsRepository.CreateStationaryTestingMms
                (stationaryTestingMms);
        }
        public StationaryTestingMms UpdateStationaryTestingMms
           (UpdateStationaryTestingMms updateStationaryTestingMms)
        {
            if (updateStationaryTestingMms.CalibrationMmsId != 0)
            {
                var calibrationMms = _calibrationMmsRepository.
                    GetCalibrationMms(updateStationaryTestingMms.CalibrationMmsId);
                if (calibrationMms.StationaryTestingMms != null) throw new Exception();
                updateStationaryTestingMms.CalibrationMms = calibrationMms;
            }
            if (updateStationaryTestingMms.AuthorId != null)
            {
                updateStationaryTestingMms.Author = _authorRepository
                    .GetAuthor(updateStationaryTestingMms.AuthorId.Value);
            }
            return _stationaryTestingMmsRepository.UpdateStationaryTestingMms
                (updateStationaryTestingMms);
        }
        public List<StationaryTestingMms> GetStationaryTestingMmsByIds(IEnumerable<int> ids)
        {
            return _stationaryTestingMmsRepository.GetStationaryTestingMmsByIds(ids);
        }

        public void DeleteStationaryTestingMms(int id)
        {
            _stationaryTestingMmsRepository.DeleteStationaryTestingMms(id);
        }

        public StationaryTestingMms GetStationaryTestingMms(int id)
        {
            return _stationaryTestingMmsRepository.GetStationaryTestingMms(id);
        }

       
    }
}
