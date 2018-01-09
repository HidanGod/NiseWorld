using NiseWorld.Anstract;
using NiseWorld.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiseWorld.Controllers
{
    public class AdminController : Controller
    {

        // создаем контекст данных
        DBContext db = new DBContext();
      //  private IUserRepository repository;

       
    // GET: MyPosts
    public ActionResult Index()
        {
            return View(db.Users);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            SelectList roles = new System.Web.Mvc.SelectList(db.Roles, "IdRole", "Role");
            ViewBag.Rol = roles;

            if (id == null)
            {
                return HttpNotFound();
            }
            User user = db.Users.Find(id);
            if (user != null)
            {
                return View(user);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(User user, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    user.ImageMimeType = image.ContentType;
                    user.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(user.ImageData, 0, image.ContentLength);
                  //  user.Name = "лох";
                }
                else
                {
                    if (user.IdUser != 0)
                    {
                        //User make = db.Users.FirstOrDefault(g => g.IdUser == user.IdUser);
                        //user.ImageData = make.ImageData;
                        //user.ImageMimeType = make.ImageMimeType;
                    }
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
               // repository.SaveUser(user);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(user);
            }
           
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            //User user = db.Users.Find(4);
            SelectList roles = new System.Web.Mvc.SelectList(db.Roles, "IdRole", "Role");
            ViewBag.Rol = roles;
            return View( );
        }
        [HttpPost]
        public ActionResult CreateUser(User user, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    user.ImageMimeType = image.ContentType;
                    user.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(user.ImageData, 0, image.ContentLength);
                   // user.Name = "лох";
                }
                else
                {
                  
                }


                db.Entry(user).State = EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(user);
            }

        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            User b = db.Users.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User b = db.Users.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Users.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UserDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            User user = db.Users.Find(id);
            if (user != null)
            {

                List<Like> like = new List<Like>();
                List<Post> Likespost = new List<Post>();
                foreach (Like l in db.Likes.Where(p => p.IdUser == user.IdUser))
                {
                    like.Add(l);
                }
                foreach (Like l in like)
                {
                    foreach (Post l2 in db.Posts.Where(p => p.IdPost == l.IdPost))
                    {
                        Likespost.Add(l2);
                    }
                }
                List<Repost> Reposts = new List<Repost>();
                List<Post> Repostpost = new List<Post>();
                foreach (Repost l in db.Reposts.Where(p => p.IdUser == user.IdUser))
                {
                    Reposts.Add(l);
                   
                }
                foreach (Repost l in Reposts)
                {
                    foreach (Post l2 in db.Posts.Where(p => p.IdPost == l.IdPost))
                    {
                        Repostpost.Add(l2);
                    }
                }


                List<Post> post = new List<Post>();

                foreach (Post l in db.Posts.Where(p => p.IdUser == user.IdUser))
                {
                    post.Add(l);
                }

               

                Picture pic = new Picture();

                

                Role role = db.Roles.FirstOrDefault(p => p.IdRole == user.IdRole);

                ForUserAdmin forUserAdmin = new ForUserAdmin();
                forUserAdmin.Posts = post;
                forUserAdmin.LikesPost = Likespost;
                forUserAdmin.Reposts = Repostpost;
                forUserAdmin.Roles = role;
                forUserAdmin.ImageData = user.ImageData;
                forUserAdmin.ImageMimeType = user.ImageMimeType;
                forUserAdmin.IdUsers = user.IdUser;
                forUserAdmin.Name = user.Name;
                forUserAdmin.Patronymic = user.Patronymic;
                forUserAdmin.Surname = user.Surname;
                forUserAdmin.Age = user.Age;
                forUserAdmin.Address = user.Address;
                return View(forUserAdmin);
            }
            return HttpNotFound();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public FileContentResult GetImage(int IdUser)
        {
            User user = db.Users
                .FirstOrDefault(g => g.IdUser == IdUser);

            if (user != null)
            {
                return File(user.ImageData, user.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

    }
}