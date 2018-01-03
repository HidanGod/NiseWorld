using NiseWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NiseWorld.Anstract;

namespace NiseWorld.Anstract
{
    public class EFUserRepository
    {
        DBContext db = new DBContext();
        public void SaveUser(User user)
        {
            if (user.IdUser == 0)
                db.Users.Add(user);
            else
            {
             

                User dbEntry = db.Users.Find(user.IdUser);
                if (dbEntry != null)
                {
                    dbEntry.Name = user.Name;
                    dbEntry.Patronymic = user.Patronymic;
                    dbEntry.Surname = user.Surname;
                    dbEntry.Age = user.Age;
                    dbEntry.Address = user.Address;
                    dbEntry.ImageData = user.ImageData;
                    dbEntry.ImageMimeType = user.ImageMimeType;
                    dbEntry.IdRole = user.IdRole;
                    dbEntry.Role = user.Role;
                    dbEntry.Posts = user.Posts;
                    dbEntry.Likes = user.Likes;
                    dbEntry.Reposts = user.Reposts;
                }
            }
            db.SaveChanges();
        }
    }
}