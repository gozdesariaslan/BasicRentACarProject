using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager :ICarImageService
    {
         ICarImageDal _carImageDal;

         public CarImageManager(ICarImageDal carImageDal)
         {
             _carImageDal = carImageDal;
         }

         public IResult Add(CarImage carImage)
        {
            carImage.Date = DateTime.Now;
           _carImageDal.Add(carImage);
           return new SuccessResult();
        }

        public IResult Update(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
