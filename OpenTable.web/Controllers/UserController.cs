using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenTable.bus.Entities;
using OpenTable.dal;
using OpenTable.bus.Abstract;
using OpenTable.dal.Concrete;
using OpenTable.web.Models.ViewModels;

namespace OpenTable.web.Controllers
{
    public class UserController : Controller
    {
        private IUserDal db = new EFUserDal();
        private IRestaurantDal dbRestaurants = new EFRestaurantDal();

        private User Find(int id)
        {
            return db.Users.SingleOrDefault(u => u.Id == id);
        }

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            User user = Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            var model = new UserEditViewModel { };
            model.Populate(new User { }, dbRestaurants.Restaurants.ToList());
            return View(model);
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.User.Restaurants = model.SelectedRestaurants.Where(sr => sr.Selected).Select(sr => sr.Restaurant).ToList();
                var user = db.Set(model.User);
                return RedirectToAction("Details", new { id = user.Id });
            }

            return View(model);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = Find(id);
            var model = new UserEditViewModel{};
            model.Populate(user, dbRestaurants.Restaurants.ToList());
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.User.Restaurants = model.SelectedRestaurants.Where(sr => sr.Selected).Select(sr => sr.Restaurant).ToList();
                db.Set(model.User);
                return RedirectToAction("Details", new { id = model.User.Id });
            }
            return View(model.User);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = Find(id);
            db.Destroy(user);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            dbRestaurants.Dispose();
            base.Dispose(disposing);
        }
    }
}