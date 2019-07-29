using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Business.Abstract;
using WorldCulture.DataAccess.Abstract;

namespace WorldCulture.Business.Concrete
{
    public class FamousPlaceManager : IFamousPlaceService
    {
        private IFamousPlaceDal _famousPlaceDal;

        public FamousPlaceManager(IFamousPlaceDal famousPlaceDal)
        {
            _famousPlaceDal = famousPlaceDal;
        }
    }
}
