using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Services
{
    public interface ICalibrationMmsService
    {
        CalibrationMms CreateCalibrationMms(CalibrationMms calibrationMms);
        List<CalibrationMms> GetCalibrationMmsByIds(IEnumerable<int> ids);
        CalibrationMms GetCalibrationMms(int id);
        CalibrationMms UpdateCalibrationMms(UpdateCalibrationMms updateCalibrationMmsModel);
        void DeleteCalibrationMms(int id);
    }
}

