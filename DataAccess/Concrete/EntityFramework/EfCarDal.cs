using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, BasicRentalCarContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails()
        {
            using (BasicRentalCarContext context = new BasicRentalCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {
                                 BrandName = b.Name,
                                 CarName = c.Name,
                                 ColorName = cl.Name,
                                 Dailyprice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
