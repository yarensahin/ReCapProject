using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Performance;

namespace Business.Concrete
{
  
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {            
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);           
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            _carDal.Add(car);
            if (car.ColorId==52)
            {
                throw new Exception("");
            }
            car.Description += "TransactionalTest" ;
            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        [SecuredOperation("product.getall,car")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
           return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.Listed);
        }

        [CacheAspect]
        [PerformanceAspect(20)]
        public IDataResult<Car> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.BrandId == brandId));
        }

        [CacheAspect]
        public IDataResult<Car> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.ColorId == colorId));
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
