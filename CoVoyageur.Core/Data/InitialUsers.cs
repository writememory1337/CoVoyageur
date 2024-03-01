using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoVoyageur.Core.Models;

namespace CoVoyageur.Core.Data
{
    public static class InitialUser
    {
        public static readonly List<User> users = new List<User>()
        {
            new User{ ID =1, FirstName ="Leo", LastName = "Dorat", BirthDate = DateTime.Now, Email = "test1@test.com", Password = "Sup4Str0ngP455W0RD!!1" , DrivingLicense = true, IsAdmin = true },
            new User{ ID =2, FirstName ="Lea", LastName= "Naconda", BirthDate = DateTime.Now, Email = "test2@test.com", Password = "Sup4Str0ngP455W0RD!!2", DrivingLicense = true, IsAdmin = false},
            new User{ ID =3, FirstName ="Leon", LastName = "Sendort", BirthDate = DateTime.Now, Email = "test3@test.com", Password = "Sup4Str0ngP455W0RD!!3", DrivingLicense = true, IsAdmin = false}
        };
    }
}
