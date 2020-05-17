using MMD.Domain;
using MMD.Domain.Model;
using MMD.Domain.Repositories;
using MMD.Domain.Services;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;

namespace MMD.Bll
{
    public class ConfiguringMmsService : IConfiguringMmsService
    {
        private readonly IConfiguringMmsRepository _configuringMmsRepository;
        private readonly IAssemblyMmsRepository _assemblyMmsRepository;
        private readonly IMobileTestingMmsService _mobileTestingMmsService;
        private readonly IAuthorRepository _authorRepository;
        public ConfiguringMmsService(IConfiguringMmsRepository configuringMmsRepository,
            IAssemblyMmsRepository assemblyMmsRepository,
            IMobileTestingMmsService mobileTestingMmsService,
            IAuthorRepository authorRepository)
        {
            _configuringMmsRepository = configuringMmsRepository;
            _assemblyMmsRepository = assemblyMmsRepository;
            _mobileTestingMmsService = mobileTestingMmsService;
            _authorRepository = authorRepository;
    }

        public ConfiguringMms CreateConfiguringMms(ConfiguringMms configuringMms)
        {
            if (configuringMms.AssemblyMmsId != null)
            {
                var assemblyMms = _assemblyMmsRepository.
                    GetAssemblyMms(configuringMms.AssemblyMmsId);
                if(assemblyMms.ConfiguringMms !=null) throw new Exception();
                configuringMms.AssemblyMms = assemblyMms;
            }
            else
                throw new ArgumentException($"Please, enter ID Assembly Mms ");
            if (configuringMms.AuthorId != null)
            {
                configuringMms.Author = _authorRepository
                    .GetAuthor(configuringMms.AuthorId.Value);
            }

            return _configuringMmsRepository.CreateConfiguringMms(configuringMms);
        }
        public ConfiguringMms UpdateConfiguringMms(UpdateConfiguringMms updateConfiguringMms)
        {
            if (updateConfiguringMms.AssemblyMmsId != null)
            {
                var assemblyMms = _assemblyMmsRepository.
                    GetAssemblyMms(updateConfiguringMms.AssemblyMmsId);
                if (assemblyMms.ConfiguringMms != null) throw new Exception();
                updateConfiguringMms.AssemblyMms = assemblyMms;
            }
            if (updateConfiguringMms.AuthorId != null)
            {
                updateConfiguringMms.Author = _authorRepository
                    .GetAuthor(updateConfiguringMms.AuthorId.Value);
            }
            return _configuringMmsRepository.
                UpdateConfiguringMms(updateConfiguringMms);
        }
        public List<ConfiguringMms> GetConfiguringMmsByIds(IEnumerable<int> ids)
        {
            return _configuringMmsRepository.GetConfiguringMmsByIds(ids);
        }

        public void DeleteConfiguringMms(int id)
        {
            var configuringMms = GetConfiguringMms(id);

            if (configuringMms is null) throw new ArgumentException
                  ($"ConfiguringMms with id = {id} doesn't exist");

            if (configuringMms.MobileTestingMms != null) 
            { 
                _mobileTestingMmsService.DeleteMobileTestingMms
                    (configuringMms.MobileTestingMms.Id);
            }

            _configuringMmsRepository.DeleteConfiguringMms(id);
        }

        public ConfiguringMms GetConfiguringMms(int id)
        {
            return _configuringMmsRepository.GetConfiguringMms(id);
        }

        
    }
}
