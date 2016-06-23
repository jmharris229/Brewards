# Brewards

**TL;DR**: A virtual punchcard reward app for regulars to keep track of beers drank and earn rewards for doing so. This is a second semester capstone for Nashville Software School and uses C#, Javascript, Web API, Angular, ASP.Net MVC, Angular Material, Twilio, Google Maps, and Bootstrap.

### Description
At the core, Brewards is an app designed to provide incentives to regulars at breweries by keeping track of their virtual "punchcards". Once a user buys a beer from a brewery, a "punchcard" is set up for that user at that specific brewery. As a user continues to visit that brewery, they will eventually have accumulated enough "punches" for a free pint. Brewards also offers the ability to see purchase history, other available offers, and all breweries within the locale city.

### Features
* "Nearby Breweries" section:
 * Using Google Maps and JS Geolocation, this section retrieves the locale city. 
 * A list of breweries within that city are called from the database and displayed to the user.
 * A user is able to select a brewery, which takes them to the "Add a Punch" section.
* "Add Punch" section:
 * By default, when a user opens the app, the "Add Punch" page is loaded and uses Geolocation and Google Maps to determine if you are at a particular brewery.
 * If a user is at a particular brewery in the locale city, the page will populate with the information and steps to add a punch for that particular brewery.
 * A user will then confirm that they are at the brewery, select a beer that they wish to add as a punch, and then confirm it with the brewery.
 * In order for a user to get a punch confirmed, they will have to get the brewery to enter the brewery pin number.
 * If the pin is entered correctly, the punch is added. 
* "Punchcards" section:
 * Provides a list of active "punchcards" a user currently has.
 * Displays the current progress of the "punchcard".
 * Showcases active "punchcards" and whether they are redeemable.
 * Redeem button:
  * Visual cue to the user that they have an available "punchcard" to redeem.
  * This button is used by the brewery to authorize the redemption.
  * Once confirmed, the punchcard status becomes expired and can no longer be used. It is removed from the active punchcard list.
* "Brew Log" section:
 * The "Brew Log" is a simple beer tracking list. 
 * Keeps count of the amount of purchases you have made at a brewery.
 * From the running total, it breaks down how many of each specific beer you have purchased at that brewery.
 * Provides a filtering functionality on the breweries, so that a user can quickly and easily find their purchase history for a particular brewery.
* "Brews News" section:
 * A simple list of special promotions and offers given out by breweries up to 1 week in advance.
 * This feature allows for breweries to engage and promote the brewery beyond just the punchcard, as well as getting drinkers involved in checking for promotions and engaging with the breweries.
 * The "Brews News" also features the Google Maps API and geolocation feature by only displaying offers within the locale city.
* Notification of completed "punchcard":
 * A user must recieve 8 punches to redeem a "punchcard".
 * Once a "punchcard" is completed, Twilio sends a text message, to notify the user that they have earned a free pint.

### Userflow
1. A user logs into the app and is automatically directed to the "Add a Punch" section, which populates with the brewery that they are currenly at, if applicable.
2. A user then goes through the process of a adding a punch, by selecting a beer and confirming it with the brewery.
3. After the punch is confirmed it will then appear in the "punchcards" section.
4. If a user selects the "Punchcard" section, they will be presented with a stack of active "punchcards" and their current status. If a user has 8 punches on a card, they then have the option to redeem it.
4. If a user selects the "Brews News" section, they will be able to scroll through a list of offers within their current city up through the next 7 days.
5. If a user selects the "Purchases" section, they will be able to see their purchase history and filter by particular breweries.
6. If a user selects the "Nearby Breweries" section, they will be able to see a list of breweries within their current city and choose one to add a punch to.

### Stretch Goals
* Expanding the "Brew Log" section to include a rating and notes feature for each beer that you've purchased.
* Build the portal for new breweries to sign up and add "Brews News" offers.
* Offer one new type of reward (besides just the punchcard) that is tracked within the database.
