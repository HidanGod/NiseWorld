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
        public ActionResult Details(int? id)
        {
            int IdUser = 2;
            int IdPost = 2;
            Post post = db.Posts.Find(IdPost);
            ForPost forPost = new ForPost();
            foreach (Post l in db.Posts.Where(p => p.IdPost == post.IdPost & p.IdUser == IdUser))
            {
                forPost.Userliked = true;

            }
            List<Like> like = new List<Like>();

            foreach (Like l in db.Likes.Where(p => p.IdPost == post.IdPost))
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