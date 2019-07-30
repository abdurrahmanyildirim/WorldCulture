using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Business.Abstract;
using WorldCulture.DataAccess.Abstract;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Concrete
{
    public class FamousPlaceManager : IFamousPlaceService
    {
        private IFamousPlaceDal _famousPlaceDal;

        public FamousPlaceManager(IFamousPlaceDal famousPlaceDal)
        {
            _famousPlaceDal = famousPlaceDal;
        }

        public List<FamousPlace> GetPlacesByCity(int cityId)
        {
            return _famousPlaceDal.GetAll(x => x.CityID == cityId);
        }

        public FamousPlace GetPlaceByID(int placeId)
        {
            return _famousPlaceDal.Get(x => x.FamousPlaceID == placeId);
        }
    }
}
