# Brewards

**TL;DR**: A virtual punchcard reward app for regulars to keep track of beers drank and earn rewards for doing so.

### Description
Brewards is an app designed to provide incentives to regulars at breweries by keeping track of their virtual "punchcards". Once a user buys a beer from a brewery, a "punchcard" is set up for that user at that specific brewery. As a user continues to visit that brewery, they will eventually have accumulated enough "punches" for a free pint. After the user has completed a "punchcard", they will recieve a text notifying them that they have earned a free pint and is then redeemable at the brewery and a new "punchcard" is created. 

### Features
* "Nearby Breweries" section
 * Google Map that uses current location and pins nearby breweries
 * Includes a slide out nav menu to display brewery info, beers available, purchase status, and "punchcard" status.
* "Punchcards" section
 * Provides a list of active "punchcards" a user currently has.
 * Displays the current progress of the "punchcard".
 * Showcases completed "punchcards" and whether they are redeemable or have been spent.
 * Redeem button
  * Visual cue to the user that they have an available "punchcard" to redeem.
  * This button is used by the brewery to authorize the redemption.
  * Once confirmed, the punchcard status becomes expired and can no longer be used.
* Notification of completed "punchcard"
 * Once a "punchcard" is completed a text message will be sent to user to notify them that they have earned a free pint.
 * A user will also get a in app notification through a pop up with a congratulations message, with a link to the rewards section
