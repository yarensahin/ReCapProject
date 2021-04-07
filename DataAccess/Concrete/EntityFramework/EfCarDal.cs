using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapProjectDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapProjectDbContext context=new RecapProjectDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             select new CarDetailDto {
                                 Id=c.Id,CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear=c.ModelYear,
                                 DailyPrice = c.DailyPrice, 
                                 Description=c.Description,
                                 ImagePath=ci.ImagePath                                
                             };
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                var result = from p in filter == null ? context.Cars : context.Cars.Where(filter)
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join d in context.Brands
                             on p.BrandId equals d.BrandId
                             join ci in context.CarImages
                             on p.Id equals ci.CarId
                             select new CarDetailDto
                             {
                                 BrandName = d.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description,
                                 ModelYear = p.ModelYear,
                                 Id = p.Id,
                                 CarName=p.CarName,
                                 ImagePath=ci.ImagePath
                             };
                return result.ToList();
            }
        }
    }
}
        


