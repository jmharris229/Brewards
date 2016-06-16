app.controller('addPunchCtrl', function ($http, $q, $scope, authService, $animate, $location) {

    var vm = this;
    vm.breweries;
    vm.brewery;
    vm.beer;
    vm.punchStatus = 'breweries';
    vm.atBrewery = true;
    //once document is ready runs function to add google maps script and gets current location
    console.log(authService.atBrewery);
    if (authService.atBrewery) {

        $(document).ready(function () {
            var googleScript = document.createElement('script');
            googleScript.setAttribute('src', "https://maps.googleapis.com/maps/api/js?key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk&callback=CurrentLoc");
            window.CurrentLoc = function () {
                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(getCurrentBrewery)
                } else {
                    Alert("device does not support geolocation");
                }
            }
            $('head').append(googleScript);
        });
    } else {
        vm.currentBreweryObject = authService.actualBrewery;
    }


    vm.currentLoc = function () {
        window.CurrentLoc();
    };

    //gets city from coordinates
    function getCurrentBrewery(position) {
        //creates coordinates from geolocation
       var pos = {
            BreweryLat: 36.150338,
            BreweryLng: -86.779493
        };
        //call get request to retrieve brewery if at location
        vm.getBreweryObject(pos);
    };

    //retrieves a brewery by coordinates from db
    vm.currentBreweryObject;
    vm.getBreweryObject = function (pos) {
        return $http.get('/api/brewery?breweryCoords=' + pos.BreweryLat + ',' + pos.BreweryLng)
            .then(function (response) {
                if (response.data != null) {
                    vm.currentBreweryObject = response.data;
                } else {
                    vm.atBrewery = false;
                }

            });
    }

    //sets the side nav to the specific brewery info
    vm.getBreweryBeers = function () {
        vm.punchStatus = 'selectBeer';
    };

    vm.breweryInfo;
    vm.breweryView = function (index) {
        vm.breweryInfo = vm.breweries[index];
    }

    vm.goToNearbyBreweries = function () {

        $location.url('/nearbyBreweries');
    }


    vm.pin;
    vm.confirmed = false;
    vm.confirm = true;
    vm.open = false;
    vm.confirmPunch = function (beer, brewery) {
        vm.punchStatus = 'confirmation';
        vm.punchInfo = {
            beer: beer,
            brewery: brewery
        }
    };


    //post purchase to database
    vm.addPunch = function (beer, brewery) {
        console.log(beer, brewery);
        brewery.breweryPin = parseInt(vm.pin);
        vm.pin = "";
        var userpurchase = {
            BeerInfo: beer,
            BreweryInfo: brewery,
        };
        $http.post('/api/Userpurchase?purchase=', userpurchase)
            .error(function () {
                vm.confirmDeclined = true;
            })
            .success(function () {
                vm.confirm = false;
                vm.confirmed = true;
            });
    }
    //switches back to brewery list

    vm.CloseConfirm = function () {
        vm.punchStatus = 'breweries';
        vm.confirm = true;
        vm.confirmed = false;
        vm.confirmDeclined = false;
    }
});