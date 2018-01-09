﻿using NiseWorld.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            forPost.Userliked = false;
            
            Like likeThis = new Like();
            foreach (Like l in db.Likes.Where(p => p.IdPost == IdPost & p.IdUser == IdUser))
            {
                if (l.liked == true) l.liked = false;
                else  l.liked = true;
                likeThis = l;
            }
            if (likeThis.IdLike == 0)
            {

                likeThis.IdPost = IdPost;
                likeThis.IdUser = IdUser;
                likeThis.liked = true;

                Add(likeThis);


            }
            else
            {
                Saver(likeThis);

            }

            forPost.Userliked = likeThis.liked;


            List<Like> like = new List<Like>();

            foreach (Like l in db.Likes.Where(p => p.IdPost == IdPost & p.liked==true))
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

        private void Saver(Like like)
        {
            db.Entry(like).State = EntityState.Modified;
            db.SaveChanges();
        }
        private void Add(Like like)
        {
            db.Entry(like).State = EntityState.Added;
            db.SaveChanges();
        }

    }
}