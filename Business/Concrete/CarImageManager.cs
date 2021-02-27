using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimit(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(ci => ci.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckImageLimit(int carId)
        {
            var count = _carImageDal.GetAll(ci => ci.CarId == carId).Count;
            if (count>=5)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }
            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int carId)
        {
            string path = @"\Images\default.jpg";
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = path } };
            }
            return _carImageDal.GetAll(ci => ci.CarId == carId);
        }
 
    }
}
