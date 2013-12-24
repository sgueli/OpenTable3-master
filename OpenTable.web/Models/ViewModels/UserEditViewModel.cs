using OpenTable.bus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenTable.web.Models.ViewModels
{
    public class UserEditViewModel
    {
        public User User { get; set; }
        //public List<Restaurant> Restaurants { get; set; }
        public List<SelectedRestaurant> SelectedRestaurants { get; set; }


        public void Populate(User user, List<Restaurant> restaurants)
        {
            User = user;
            //Restaurants = restaurants;
            var userRestaurants = user.Restaurants;
            var userRestaurantIds = userRestaurants.Select(r => r.Id).ToList();
            SelectedRestaurants = restaurants.Select(r => new SelectedRestaurant { Restaurant = r, Selected = userRestaurantIds.Contains(r.Id)}).ToList();

        }


    }
}