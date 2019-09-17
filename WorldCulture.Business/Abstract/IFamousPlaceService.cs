using System.Collections.Generic;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Abstract
{
    public interface IFamousPlaceService
    {
        List<FamousPlace> GetPlacesByCity(int cityId);
        FamousPlace GetPlaceByID(int placeId);
        void Add(FamousPlace famousPlace);
    }
}