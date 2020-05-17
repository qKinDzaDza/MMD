using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Repositories
{
    public interface ICalibrationProductRepository
    {
        CalibrationProduct CreateCalibrationProduct(CalibrationProduct calibrationProduct);
        List<CalibrationProduct> GetCalibrationProductByIds(IEnumerable<int> ids);
        CalibrationProduct GetCalibrationProduct(int id);
        CalibrationProduct UpdateCalibrationProduct(UpdateCalibrationProduct updateCalibrationProductModel);
        void DeleteCalibrationProduct(int id);
    }
}
