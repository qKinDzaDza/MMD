using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Repositories
{
   public interface ICalibrationMmsRepository
    {
        CalibrationMms CreateCalibrationMms(CalibrationMms calibrationMms);
        List<CalibrationMms> GetCalibrationMmsByIds(IEnumerable<int> ids);
        CalibrationMms GetCalibrationMms(int id);
        CalibrationMms UpdateCalibrationMms(UpdateCalibrationMms updateCalibrationMmsModel);
        void DeleteCalibrationMms(int id);
    }
}
