using NiseWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiseWorld.Controllers
{
    public class testController : Controller
    {
        DBContext db = new DBContext();
        // GET: test
        public ActionResult Index()
        {
            return View(db.Posts);
        }
        [HttpPost]
        public ActionResult Details(int IdPost)
        {
            int IdUser = 2;
            //int IdPost = 2;
           // Post post = db.Posts.Find(IdPost);
            ForPost forPost = new ForPost();
            forPost.Userliked = false;


            foreach (Like l in db.Likes.Where(p => p.IdPost == IdPost & p.IdUser == IdUser))
            {
                forPost.Userliked = l.liked;

            }
            List<Like> like = new List<Like>();

            foreach (Like l in db.Likes.Where(p => p.IdPost == IdPost))
            {
                like.Add(l);
            }
            forPost.Likes = like;


            if (forPost == null)
            {
                return HttpNotFound();
            }
            return PartialView(forPost);

        }
    }
}