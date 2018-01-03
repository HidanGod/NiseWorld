using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NiseWorld.Models;
using System.Data.Entity;

namespace NiseWorld.Controllers
{
    public class HomeController : Controller
    {
        
       // создаем контекст данных
       DBContext db = new DBContext();

       public ActionResult Index()
            {
           
                // возвращаем представление
                return View(db.Posts);
            }
      

        [HttpGet]
        public ActionResult Post(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Post post = db.Posts.Find(id);
         
            User user = db.Users.FirstOrDefault(p => p.IdUser == post.IdUser);
            
            List<Like> like = new List<Like>();
          
            foreach (Like l in db.Likes.Where(p => p.IdPost == post.IdPost))
            {
                like.Add(l);
            }
            List<Repost> repost = new List<Repost>();          
            foreach (Repost l in db.Reposts.Where(p => p.IdPost == post.IdPost))
            {
                repost.Add(l);
            }

            List<Picture> picture = new List<Picture>();
            foreach (Picture l in db.Pictures.Where(p => p.IdPost == post.IdPost))
            {
                picture.Add(l);
            }
            int KolPostUsera = db.Posts.Count(p => p.IdUser == user.IdUser);
            int KolLikeUsera = db.Likes.Count(p => p.IdUser == user.IdUser);

            List<Coment> coment = new List<Coment>();
           

            foreach (Coment l in db.Coments.Where(p => p.IdPost == post.IdPost))
            {
                coment.Add(l);
               
            }
            List<User> userComents = new List<User>();
            foreach (Coment l in coment)
            {
                foreach (User l2 in db.Users.Where(p => p.IdUser == l.IdUser))
                {
                    userComents.Add(l2);
                }
            }
            ForPost forPost = new ForPost();
            forPost.IdPost = post.IdPost;
            forPost.Post = post;
            forPost.KolLikeUsera = KolPostUsera;
            forPost.KolPostUsera = KolLikeUsera;
            forPost.IdUser = user.IdUser;
            forPost.User = user;
            forPost.Reposts = repost;
            forPost.Likes = like;
            forPost.Pictures = picture;
            forPost.Coments = coment;
            forPost.UserComents = userComents;

            if (post != null)
            {
                return View(forPost);
            }
            return HttpNotFound();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}