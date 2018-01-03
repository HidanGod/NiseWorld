using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NiseWorld.Models
{
    public class UserInitializer : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext db)
        {
            Coment h1 = new Coment { Text="111" };
            Coment h2 = new Coment { Text = "222" };
            Coment h3 = new Coment { Text = "333" };

            db.Coments.Add(h1);
            db.Coments.Add(h2);
            db.Coments.Add(h3);


            Role r1 = new Role { role = "Admin" };
            Role r2 = new Role { role = "User" };

            db.Roles.Add(r1);
            db.Roles.Add(r2);

            Repost f1 = new Repost { };
            Repost f2 = new Repost { };
            Repost f3 = new Repost { };
            Repost f4 = new Repost { };
            Repost f5 = new Repost { };

            db.Reposts.Add(f1);
            db.Reposts.Add(f2);
            db.Reposts.Add(f3);
            db.Reposts.Add(f4);
            db.Reposts.Add(f5);

            Like d1 = new Like { };
            Like d2 = new Like { };
            Like d3 = new Like { };
            Like d4 = new Like { };
            Like d5 = new Like { };
            Like d6 = new Like { };

            db.Likes.Add(d1);
            db.Likes.Add(d2);
            db.Likes.Add(d3);
            db.Likes.Add(d4);
            db.Likes.Add(d5);
            db.Likes.Add(d6);

            Post c1 = new Post { Сaption = "новость 1", Text = "Текст 1", Likes = new List<Like>() { d1, d2, d3 }, Reposts = new List<Repost>() { f1}, Coments = new List<Coment>() { h1, h3 } };
            Post c2 = new Post { Сaption = "новость 2", Text = "Текст 2", Likes = new List<Like>() { d4, d5 }, Reposts = new List<Repost>() { f5, f2 }, Coments = new List<Coment>() { h2 } };
            Post c3 = new Post { Сaption = "новость 3", Text = "Текст 3", Likes = new List<Like>() { d6 }, Reposts = new List<Repost>() { f3, f4 } };
            Post c4 = new Post { Сaption = "новость 4", Text = "Текст 4", };

            db.Posts.Add(c1);
            db.Posts.Add(c2);
            db.Posts.Add(c3);
            db.Posts.Add(c4);

            User s1 = new User { Name = "Коля", Patronymic = "Николаевич", Surname = "Иванов", Age = 21, Address = "Ростов", Posts = new List<Post>() { c1, c4 }, Likes = new List<Like>() { d1, d4 }, Reposts = new List<Repost>() { f2, f3 }, Role=r1, Coments = new List<Coment>() { h1, h2 } };
            User s2 = new User { Name = "Петя", Patronymic = "Иванович", Surname = "Иванов", Age = 24, Address = "Москва", Posts = new List<Post>() { c2 }, Likes = new List<Like>() { d2, d5 }, Reposts = new List<Repost>() { f4, f1 }, Role = r2, Coments = new List<Coment>() { h3 } };
            User s3 = new User { Name = "Вася", Patronymic = "Степанович", Surname = "Иванов", Age = 26, Address = "Магадан", Posts = new List<Post>() { c3 }, Likes = new List<Like>() { d3, d6 }, Reposts = new List<Repost>() { f5 }, Role = r2 };

            db.Users.Add(s1);
            db.Users.Add(s2);
            db.Users.Add(s3);

          


            base.Seed(db);
        }
    }
}