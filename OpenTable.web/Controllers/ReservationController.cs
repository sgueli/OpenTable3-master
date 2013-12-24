using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenTable.bus.Abstract;
using OpenTable.dal.Concrete;
using OpenTable.bus.Entities;
using OpenTable.web.Models.ViewModels;

namespace OpenTable.web.Controllers
{
    public class ReservationController : Controller
    {

        IUserDal dbUsers = new EFUserDal();
        IRestaurantDal dbRestaurants = new EFRestaurantDal();
        IReservationDal dbReservations = new EFReservationDal();
        public ActionResult Create(int user_id)
        {
            var model = new ReservationCreateViewModel { };
            var user = dbUsers.Users.SingleOrDefault(u=>u.Id == user_id);
            var restaurants = dbRestaurants.Restaurants.ToList();
            model.Reservation = new Reservation { 

                UserId = user.Id,
                User = user,
                Date = DateTime.Now
            };
            model.Restaurants = restaurants;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Reservation reservation)
        {
            dbReservations.Set(reservation);
            return RedirectToAction("Details", "User", new { id = reservation.UserId });
        }

        protected override void Dispose(bool disposing)
        {
            dbUsers.Dispose();
            dbRestaurants.Dispose();
            dbReservations.Dispose();
            base.Dispose(disposing);
        }

    }
}
