using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using WatchCart.Models;
using WatchCart.Repository.Data;
using WatchCart.Repository.User;

namespace WatchCart.Repository
{
    public class UserService : IUserService
    {
        public bool CreateNewUser(UserDetails userDetails)
        {
            using (var db = new WatchCartDbContext())
            {
                if (!string.IsNullOrWhiteSpace(userDetails.Name))
                {
                    var chkAlreadyExists = db.UserTable.Where(x => x.UserName == userDetails.Name).ToList();
                    if (chkAlreadyExists.Count() > 0)
                    {
                        return false;
                    }
                    else
                    {
                        UserTable userTable = new UserTable();
                        userTable.UserName = userDetails.Name;
                        db.UserTable.Add(userTable);
                        db.SaveChanges();
                    }
                }
            }
            return true;
        }

        public bool ValidateUser(UserDetails userDetails)
        {
            using (var db = new WatchCartDbContext())
            {
                if (!string.IsNullOrWhiteSpace(userDetails.Name))
                {
                    var chkAlreadyExists = db.UserTable.Where(x => x.UserName == userDetails.Name).ToList();
                    if (chkAlreadyExists.Count() > 0)
                    {
                        return true;
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            return false;
        }
    }
}
