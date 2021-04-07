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

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();

        }
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carid)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carid));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(ci => ci.Id == carImage.Id).ImagePath, formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckImageLimit(int carId)
        {
            var carImageCount = _carImageDal.GetAll(ci => ci.CarId == carId).Count();
            if (carImageCount>=5)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }
            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage
                {
                    CarId = id,
                    ImagePath = path,
                    Date = DateTime.Now
                } };
            }
            return _carImageDal.GetAll(c => c.CarId == id);
        }

    }
}
