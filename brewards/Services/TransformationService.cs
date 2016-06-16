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
            Dictionary<string, UserPurchaseViewModel> breweryDictionary = new Dictionary<string, UserPurchaseViewModel>();

            //sets the brewery dictionary by going through each purchase
            foreach (var purchase in purchases)
            {
                //if the brewery exists in the dictionary then entes first part to check if the beer has been added, if not goes to else and adds 1 to brewery number purchased.
                if (breweryDictionary.ContainsKey(purchase.BreweryInfo.BreweryName))
                {
                    //checks to see if the purchased beer is in the purchased beer list, if it is it adds 1 to the purchase count , if not adds to list
                    if(breweryDictionary[purchase.BreweryInfo.BreweryName].PurchasedBeers.FirstOrDefault(x => x.BeerName == purchase.BeerInfo.BeerName) == null)
                    {
                        //creates a new litebeer object and adds to purchased beers list
                        Litebeer firstBeer = new Litebeer { BeerName = purchase.BeerInfo.BeerName, NumberPurchased = 1, Logo = purchase.BeerInfo.BeerLogo };
                        breweryDictionary[purchase.BreweryInfo.BreweryName].PurchasedBeers.Add(firstBeer);
                    }
                    else
                    {
                        //increases a particular beer count since already in purchased list for brewery
                        breweryDictionary[purchase.BreweryInfo.BreweryName].PurchasedBeers.First(x => x.BeerName == purchase.BeerInfo.BeerName).NumberPurchased += 1;
                    }
                    //adds one to the brewery number purchased
                    breweryDictionary[purchase.BreweryInfo.BreweryName].NumberPurchased += 1;

                }
                else
                {
                    //set up a new list of beers for a new brewery
                    List<Litebeer> Beers = new List<Litebeer>();
                    
                    //set up the lite beer object and add
                    Litebeer firstBeer = new Litebeer { BeerName = purchase.BeerInfo.BeerName, NumberPurchased = 1, Logo = purchase.BeerInfo.BeerLogo };
                    Beers.Add(firstBeer);

                    //adds the new userpurchase view model for a brewery to the dictionary
                    breweryDictionary.Add(purchase.BreweryInfo.BreweryName, new UserPurchaseViewModel { BreweryInfo = purchase.BreweryInfo, NumberPurchased = 1, PurchasedBeers = Beers  });
                }
            }
            //loop through the dictionary and add each brewery to the original user purchase view model list
            foreach (var brewery in breweryDictionary)
            {
                viewModelPurchases.Add(brewery.Value);
            }
            //return the list
            return viewModelPurchases;
        }

        public List<BreweryNewsViewModel> ToBreweryNewsViewModel(List<BreweryNews> news)
        {
            Dictionary<DateTime, BreweryNewsViewModel> offersByDate = new Dictionary<DateTime, BreweryNewsViewModel>();
            foreach(var offer in news)
            {
                if(offersByDate.ContainsKey(offer.NewsDate))
                {
                    DateFeed newOffer = new DateFeed { BreweryLogo = offer.BreweryInfo.BreweryLogo, BreweryName = offer.BreweryInfo.BreweryName, BreweryNews = offer.NewsMessage };

                    offersByDate[offer.NewsDate].NewsFeed.Add(newOffer);
                }
                else
                {
                    List<DateFeed> newDateFeed = new List<DateFeed>();

                    DateFeed newDate = new DateFeed { BreweryName = offer.BreweryInfo.BreweryName, BreweryLogo = offer.BreweryInfo.BreweryLogo, BreweryNews = offer.NewsMessage };

                    newDateFeed.Add(newDate);

                    BreweryNewsViewModel newOffer = new BreweryNewsViewModel { NewsDate = offer.NewsDate, NewsFeed = newDateFeed };
                    offersByDate.Add(offer.NewsDate, newOffer);
                }
            }
            List<BreweryNewsViewModel> OffersGroupedByDate = new List<BreweryNewsViewModel>();
            foreach(var date in offersByDate)
            {
                OffersGroupedByDate.Add(date.Value);
            }
            return OffersGroupedByDate;
        }
    }
}