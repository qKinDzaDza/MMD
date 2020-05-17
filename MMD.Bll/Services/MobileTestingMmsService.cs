using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;

namespace MMD.Bll
{
    public class MobileTestingMmsService : IMobileTestingMmsService
    {
        private readonly IMobileTestingMmsRepository _mobileTestingMmsRepository;
        private readonly IConfiguringMmsRepository _configuringMmsRepository;
        private readonly ICalibrationMmsService _calibrationMmsService;
        private readonly IAuthorRepository _authorRepository;

        public MobileTestingMmsService(IMobileTestingMmsRepository mobileTestingMmsRepository,
            IConfiguringMmsRepository configuringMmsRepository,
            ICalibrationMmsService calibrationMmsService,
            IAuthorRepository authorRepository)
        {
            _mobileTestingMmsRepository = mobileTestingMmsRepository;
            _configuringMmsRepository = configuringMmsRepository;
            _calibrationMmsService = calibrationMmsService;
            _authorRepository = authorRepository;
        }

        public List<MobileTestingMms> GetMobileTestingMmsByIds(IEnumerable<int> ids)
        {
            return _mobileTestingMmsRepository.GetMobileTestingMmsByIds(ids);
        }

        public MobileTestingMms CreateMobileTestingMms(MobileTestingMms mobileTestingMms)
        {

            if (mobileTestingMms.ConfiguringMmsId != 0)
            {
                var configuringMms = _configuringMmsRepository.
                    GetConfiguringMms(mobileTestingMms.ConfiguringMmsId);
                if (configuringMms.MobileTestingMms != null) throw new Exception();
                mobileTestingMms.ConfiguringMms = configuringMms;
            }
            else throw new ArgumentException($"Please, enter ID Configuring ");
            if (mobileTestingMms.AuthorId != null)
            {
                mobileTestingMms.Author = _authorRepository
                    .GetAuthor(mobileTestingMms.AuthorId.Value);
            }

            return _mobileTestingMmsRepository.CreateMobileTestingMms(mobileTestingMms);
        }
        public MobileTestingMms UpdateMobileTestingMms
            (UpdateMobileTestingMms updateMobileTestingMms)
        {
            if (updateMobileTestingMms.ConfiguringMmsId != 0)
            {
                var configuringMms = _configuringMmsRepository.
                   GetConfiguringMms(updateMobileTestingMms.ConfiguringMmsId);
                if (configuringMms.MobileTestingMms != null) throw new Exception();
                updateMobileTestingMms.ConfiguringMms = configuringMms;
            }
            if (updateMobileTestingMms.AuthorId != null)
            {
                updateMobileTestingMms.Author = _authorRepository
                    .GetAuthor(updateMobileTestingMms.AuthorId.Value);
            }
            return _mobileTestingMmsRepository.
                UpdateMobileTestingMms(updateMobileTestingMms);
        }

        public void DeleteMobileTestingMms(int id)
        {
            var mobileTestingMms = GetMobileTestingMms(id);
            if (mobileTestingMms is null) throw new ArgumentException
                 ($"MobileTestingMms with id = {id} doesn't exist");
            if (mobileTestingMms != null)
            {
                _calibrationMmsService.DeleteCalibrationMms
                        (mobileTestingMms.CalibrationMms.Id);
            }         
            _mobileTestingMmsRepository.DeleteMobileTestingMms(id);
        }

        public MobileTestingMms GetMobileTestingMms(int id)
        {
            return _mobileTestingMmsRepository.GetMobileTestingMms(id);
        }

        
    }
}
