using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Successfully added!";
        public static string CarNameInvalid = "Car name must be greater than 2!";
        public static string CarDailyPriceInvalid = "Daily Price must be greater than zero!";
        public static string Deleted = "Successfully deleted!";
        public static string Updated = "Successfully updated!";
        public static string Listed = "Listed!";
        public static string CantRent = "Car can not be rented!";
        public static string RentAdded = "Successfully rented!";
        public static string CantAdded = "Can not added!";
        public static string ImageLimitExceeded = "You can not add more than 5 images";
        public static string UserRegistered = "Successfully Registered";
        public static string SuccessfulLogin = "Successfully logged in";
        public static string UserNotFound = "User can not found";
        public static string PasswordError = "PasswordError";
        public static string AccessTokenCreated = "Access Token Created";
        public static string UserAlreadyExists = "User is already exist";
        public static string AuthorizationDenied = "AuthorizationDenied";
    }
}
