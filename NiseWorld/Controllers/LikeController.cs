using NiseWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiseWorld.Controllers
{
    public class LikeController : Controller
    {
        // GET: Like
        // создаем контекст данных
        DBContext db = new DBContext();


        [HttpPost]
        public ActionResult LikePost(int? IdPost)
        {
            int IdUser = 1;
           // int IdPost = 2;
           // Post post = db.Posts.Find(IdPost);
            ForPost forPost = new ForPost();
            foreach (Post l in db.Posts.Where(p => p.IdPost == IdPost & p.IdUser == IdUser))
            {
                forPost.Userliked = true;

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