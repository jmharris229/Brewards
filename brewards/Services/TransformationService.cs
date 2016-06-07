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
            //set up a list of userpurchaseview models
            List<UserPurchaseViewModel> viewModelPurchases = new List<UserPurchaseViewModel>();

            //set up a dictionary of breweries with user purchase view model as values
            Dictionary<string, UserPurchaseViewModel> brewery_dictionary = new Dictionary<string, UserPurchaseViewModel>();

            //sets the brewery dictionary by going through each purchase
            foreach (var purchase in purchases)
            {
                //if the brewery exists in the dictionary then entes first part to check if the beer has been added, if not goes to else and adds 1 to brewery number purchased.
                if (brewery_dictionary.ContainsKey(purchase.Brewery_info.Brewery_Name))
                {
                    //checks to see if the purchased beer is in the purchased beer list, if it is it adds 1 to the purchase count , if not adds to list
                    if(brewery_dictionary[purchase.Brewery_info.Brewery_Name].purchased_beers.FirstOrDefault(x => x.beer_name == purchase.Beer_info.Beer_name) == null)
                    {
                        //creates a new litebeer object and adds to purchased beers list
                        Litebeer firstBeer = new Litebeer { beer_name = purchase.Beer_info.Beer_name, number_purchased = 1, logo = purchase.Beer_info.Beer_logo };
                        brewery_dictionary[purchase.Brewery_info.Brewery_Name].purchased_beers.Add(firstBeer);
                    }
                    else
                    {
                        //increases a particular beer count since already in purchased list for brewery
                        brewery_dictionary[purchase.Brewery_info.Brewery_Name].purchased_beers.First(x => x.beer_name == purchase.Beer_info.Beer_name).number_purchased += 1;
                    }
                    //adds one to the brewery number purchased
                    brewery_dictionary[purchase.Brewery_info.Brewery_Name].number_purchased += 1;

                }
                else
                {
                    //set up a new list of beers for a new brewery
                    List<Litebeer> Beers = new List<Litebeer>();
                    
                    //set up the lite beer object and add
                    Litebeer firstBeer = new Litebeer { beer_name = purchase.Beer_info.Beer_name, number_purchased = 1, logo = purchase.Beer_info.Beer_logo };
                    Beers.Add(firstBeer);

                    //adds the new userpurchase view model for a brewery to the dictionary
                    brewery_dictionary.Add(purchase.Brewery_info.Brewery_Name, new UserPurchaseViewModel { Brewery_info = purchase.Brewery_info, number_purchased = 1, purchased_beers = Beers  });
                }
            }
            //loop through the dictionary and add each brewery to the original user purchase view model list
            foreach (var brewery in brewery_dictionary)
            {
                viewModelPurchases.Add(brewery.Value);
            }
            //return the list
            return viewModelPurchases;
        }
    }
}