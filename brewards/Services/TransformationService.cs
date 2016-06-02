using brewards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Services
{
    public class TransformationService
    {
        public List<UserPurchaseViewModel> ToUserPurchaseViewModel(List<Userpurchase> purchases)
        {
            List<UserPurchaseViewModel> viewModelPurchases = new List<UserPurchaseViewModel>();

            Dictionary<string, UserPurchaseViewModel> brewery_dictionary = new Dictionary<string, UserPurchaseViewModel>();
            Dictionary<string, int> beer_dictionary = new Dictionary<string, int>();
            //creates brewery count dictionary
            foreach (var purchase in purchases)
            {
                if (brewery_dictionary.ContainsKey(purchase.Brewery_info.Brewery_Name))
                {
                    if(brewery_dictionary[purchase.Brewery_info.Brewery_Name].purchased_beers.FirstOrDefault(x => x.beer_name == purchase.Beer_info.Beer_name) == null)
                    {
                        Litebeer firstBeer = new Litebeer { beer_name = purchase.Beer_info.Beer_name, number_purchased = 1, logo = purchase.Beer_info.Beer_logo };
                        brewery_dictionary[purchase.Brewery_info.Brewery_Name].purchased_beers.Add(firstBeer);
                    }
                    else
                    {
                        brewery_dictionary[purchase.Brewery_info.Brewery_Name].purchased_beers.First(x => x.beer_name == purchase.Beer_info.Beer_name).number_purchased += 1;
                    }
                    
                    brewery_dictionary[purchase.Brewery_info.Brewery_Name].number_purchased += 1;
                }
                else
                {
                    List<Litebeer> Beers = new List<Litebeer>();
                    Litebeer firstBeer = new Litebeer { beer_name = purchase.Beer_info.Beer_name, number_purchased = 1, logo = purchase.Beer_info.Beer_logo };
                    Beers.Add(firstBeer);
                    brewery_dictionary.Add(purchase.Brewery_info.Brewery_Name, new UserPurchaseViewModel { brewery_name = purchase.Brewery_info.Brewery_Name, number_purchased = 1, purchased_beers = Beers  });
                }
            }

            foreach (var brewery in brewery_dictionary)
            {
                viewModelPurchases.Add(brewery.Value);
            }
            return viewModelPurchases;
        }
    }
}