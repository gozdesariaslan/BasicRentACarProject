using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile file, string webRootPath)
        {
            BusinessRules.Run(CheckIfTheCountOfCarImagesExceed(carImage.CarId));
            var uploadedFilesPath = FileHelper.Add(file, webRootPath);
            carImage.Date = DateTime.Now;
            carImage.ImagePath = uploadedFilesPath;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Update(CarImage carImage, IFormFile file, string webRootPath)
        {
            var carImageToUpdate = _carImageDal.Get(c => c.Id == carImage.Id);
            carImageToUpdate.Date=DateTime.Now;
            carImageToUpdate.ImagePath = FileHelper.Update(carImageToUpdate.ImagePath, file,webRootPath);
            _carImageDal.Update(carImageToUpdate);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            var carImageToDelete = _carImageDal.Get(c => c.Id == carImage.Id);
            FileHelper.Delete(carImageToDelete.ImagePath);
            _carImageDal.Delete(carImageToDelete);
            return new SuccessResult();
        }

        public IDataResult<CarImage> GetAll()
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfTheCountOfCarImagesExceed(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId ==carId).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.CarImagesReachedMaxNumberOfPhoto);
            }

            return new SuccessResult();
        }

        //private IResult CheckIfCarHasAnyImage(int carId)
        //{
        //    var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
        //    if (!result)
        //    {
        //        SetDefaultImage();
        //    }
        //}

        //private void SetDefaultImage()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
