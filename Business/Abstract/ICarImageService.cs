using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage, IFormFile file, string webRootPath);
        IResult Update(CarImage carImage, IFormFile file, string webRootPath);
        IResult Delete(CarImage carImage);
        IDataResult<CarImage> GetAll();
    }
}
