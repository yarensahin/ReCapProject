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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapProjectDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RecapProjectDbContext context = new RecapProjectDbContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new RentalDetailDto{Id=r.Id,BrandName=b.BrandName,FirstName=u.FirstName,LastName=u.LastName,RentDate=r.RentDate,ReturnDate=r.ReturnDate};
                return result.ToList();
            }
        }
    }
}
