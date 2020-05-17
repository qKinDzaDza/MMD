using MMD.Domain.Model;
using MMD.Domain.UpdateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.Repositories
{
    public interface IPlateRepository
    {
        Plate CreatePlate(Plate plate);
        Plate GetPlate(string id);
        Plate UpdatePlate(UpdatePlate updatePlateModel);
        void DeletePlate(string id);
    }
}
