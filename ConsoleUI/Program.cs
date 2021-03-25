using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAllCarDetails().Data)
            {
                Console.WriteLine(car.CarName + "-" + car.BrandName);
            }
        }
    }
}
