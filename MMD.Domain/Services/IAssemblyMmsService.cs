using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Services
{
    public interface IAssemblyMmsService
    {
        AssemblyMms CreateAssemblyMms(AssemblyMms assemblyMms);
        AssemblyMms GetAssemblyMms(string id);
        List<AssemblyMms> GetAssemblyMmsByIds(IEnumerable<string> ids);
        AssemblyMms UpdateAssemblyMms(UpdateAssemblyMms updateAssemblyMmsModel);
        void DeleteAssemblyMms(string id);
    }
}
