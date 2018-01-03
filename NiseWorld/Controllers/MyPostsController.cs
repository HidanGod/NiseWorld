using NiseWorld.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiseWorld.Controllers
{
    public class MyPostsController : Controller
    {
        // создаем контекст данных
        DBContext db = new DBContext();
        // GET: MyPosts
        public ActionResult Index()
        {
            return View(db.Posts);
        }
       
        [HttpGet]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Post post = db.Posts.Find(id);
            List<Picture> picture = new List<Picture>();
            foreach (Picture l in db.Pictures.Where(p => p.IdPost == post.IdPost))
            {
                picture.Add(l);
            }
            if (post != null)
            {
                return View(post);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditPost(Post post, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    Picture picture = new Picture();
                    picture.IdPost = post.IdPost;
                    picture.ImageMimeType = image.ContentType;
                    picture.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(picture.ImageData, 0, image.ContentLength);
                    post.IdUser = 2;
                    db.Entry(picture).State = EntityState.Added;

                }
                else
                {

                }



                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(post);
            }
           
        }
        [HttpGet]
        public ActionResult CreatePost()
        {
            SelectList Users = new System.Web.Mvc.SelectList(db.Users, "IdUser", "Name");
            ViewBag.Us = Users;
            return View();
        }
        [HttpPost]
        public ActionResult CreatePost(Post post, HttpPostedFileBase image = null)
        {
            //post.IdUser = 1;
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    Picture picture = new Picture();
                    picture.IdPost = post.IdPost;
                    picture.ImageMimeType = image.ContentType;
                    picture.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(picture.ImageData, 0, image.ContentLength);
                    post.IdUser = 2;
                    db.Entry(picture).State = EntityState.Added;

                }
                else
                {

                }


               

                db.Entry(post).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(post);
            }

            
          
           
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Post b = db.Posts.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Post b = db.Posts.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Posts.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
       
    }
}