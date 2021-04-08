using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalManager))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfCarAvailableForRent(rental));
            if (result!=null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(RentalManager))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult TransactionalTest(Rental rental)
        {
            Add(rental);
            if (rental.RentDate < DateTime.Today)
            {
                throw new Exception();
            }

            Add(rental);
            return new SuccessResult();
        }

        private IResult CheckIfCarAvailableForRent(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (result.Count>0)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }

}
