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

                    brewery_dictionary[purchase.Brewery_info.Brewery_Name].number_purchased += 1;
                }
                else
                {
                    List<Litebeer> Beers = new List<Litebeer>();
                    Litebeer firstBeer = new Litebeer{ beer_name = purchase.Beer_info.Beer_name, number_purchased = 1, logo = purchase.Beer_info.Beer_logo}
                    Beers.Add(firstBeer);
                    brewery_dictionary.Add(purchase.Brewery_info.Brewery_Name, new UserPurchaseViewModel { brewery_name = purchase.Brewery_info.Brewery_Name, number_purchased = 1, purchased_beers = Beers});
                }

                //creates beer count dictionary
                if (beer_dictionary.ContainsKey(purchase.Beer_info.Beer_name))
                {
                    beer_dictionary[purchase.Beer_info.Beer_name] += 1;
                }
                else
                {
                    beer_dictionary.Add(purchase.Beer_info.Beer_name, 1);
                }
            }



            foreach (var brewery in brewery_dictionary)
            {
                int purchased_amount;

                UserPurchaseViewModel item = new UserPurchaseViewModel { brewery_name = purchase.Brewery_info.Brewery_Name, number_purchased = purchased_amount, purchased_beers = purchased_beers_info }

            }
            return viewModelPurchases;
        }
    }
}