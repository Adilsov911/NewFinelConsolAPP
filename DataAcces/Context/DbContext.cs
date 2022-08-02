using Core.Entities;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Context
{
    static class DbContext
    {
        static DbContext()
        {
            Druggis = new List<Drug>();
            Druggists = new List<Druggist>();
            Drugstores = new List<DrugStore>();
            Owners = new List<Owner>();
            Admins = new List<Admin>();

            string password1 = "adil123";
            var hashedPassword1 = PasswordHasher.Encrypt(password1);
            Admin admin1 = new Admin("admin1", hashedPassword1);
            Admins.Add(admin1);

            string password2 = "adil1234";
            var hashedPassword2 = PasswordHasher.Encrypt(password2);
            Admin admin2 = new Admin("admin2", hashedPassword2);
            Admins.Add(admin2);

        }
        public static List<Drug> Druggis { get; set; }
        public static List<Druggist> Druggists { get; set; }
        public static List<DrugStore> Drugstores { get; set; }
        public static List<Owner> Owners { get; set; }
        public static List<Admin> Admins { get; set; }
    }
}
