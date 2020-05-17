using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Services
{
        public interface IPlateService
        {
            Plate CreatePlate(Plate plate);
            Plate GetPlate(string id);
            Plate UpdatePlate(UpdatePlate updatePlateModel);
            void DeletePlate(string id);
        }
}
