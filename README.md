# Brewards

**TL;DR**: A virtual punchcard reward app for regulars to keep track of beers drank and earn rewards for doing so. This is a second semester capstone for Nashville Software School and uses C#, Javascript, Web API, Angular, ASP.Net MVC, Angular Material, Twilio, Google Maps, and Bootstrap.

### Description
Brewards is an app designed to provide incentives to regulars at breweries by keeping track of their virtual "punchcards". Once a user buys a beer from a brewery, a "punchcard" is set up for that user at that specific brewery. As a user continues to visit that brewery, they will eventually have accumulated enough "punches" for a free pint. After the user has completed a "punchcard", they will receive a text notifying them that they have earned a free pint and is then redeemable at the brewery. After redemption, the punchcard is nullified and can no longer be used and removed from the users "Punchcard" section.

### Features
* "Nearby Breweries" section:
 * Google Map that uses current location and pins nearby breweries.
 * Includes a slide out nav menu to display brewery info, beers available, purchase status, and "punchcard" status.
 * Authorization feature for breweries to confirm purchases by users
* "Punchcards" section:
 * Provides a list of active "punchcards" a user currently has.
 * Displays the current progress of the "punchcard".
 * Showcases completed "punchcards" and whether they are redeemable or have been spent.
 * Redeem button:
  * Visual cue to the user that they have an available "punchcard" to redeem.
  * This button is used by the brewery to authorize the redemption.
  * Once confirmed, the punchcard status becomes expired and can no longer be used.
* "Purchases" section:
 * Similar to the "Punchcards" section, this page provides a list of breweries you have made purchases at.
 * Provides a running total of how many of each beer you have bought at each brewery. 
* Notification of completed "punchcard":
 * Once a "punchcard" is completed a text message, through Twilio, will be sent to user to notify them that they have earned a free pint.

### Userflow
1. A user logs in to the app and is automatically directed to the "Nearby Breweries" section.
2. The user will be presented with available breweries and the ability to select one.
3. Once a user has selected a brewery, the aforementioned slide out menu will appear. 
4. A user selects a beer and a popup will appear, asking for the brewery to confirm.
5. After confirmation, the "punch" is added the users "punchcard" and the users profile data is updated. 
6. A user can then check the status of their updated "punchcard" by navigating to the "Punchcards" section.
7. A user can also see the purchase in the "Purchases" section.

### Stretch Goals
* Build portal for new breweries to sign up.
* Offer one new type of reward (besides just the punchcard).