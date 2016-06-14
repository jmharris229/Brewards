app.controller('mapCtrl', function ($http, $q, $mdSidenav, $scope, $log, $mdDialog, authService, $animate) {


    var vm = this;
    var pos;
    vm.breweries;
    vm.brewery;
    vm.currentCity;
    vm.punchStatus = 'breweries';

    //once document is ready runs function to add google maps script and gets current location   
    $(document).ready(function () {
        var googleScript = document.createElement('script');
        googleScript.setAttribute('src', "https://maps.googleapis.com/maps/api/js?key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk&callback=CurrentLoc");
        window.CurrentLoc = function () {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(getCity)
            } else {
                Alert("device does not support geolocation");
            }
        }
        $('head').append(googleScript);
    });

    vm.currentLoc = function () {
        window.CurrentLoc();
    };

    //gets city from coordinates
    function getCity(position) {
        //creates coordinates from geolocation
        pos = {
            lat: position.coords.latitude,
            lng: position.coords.longitude
        };

        //api request to google maps to retrieve current city from coordinates
        $http.get('https://maps.googleapis.com/maps/api/geocode/json?latlng=' + pos.lat + ',' + pos.lng + '&key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk')
            .then(function (response) {
                console.log(response.data);
                //parses google maps object for city
                var commaPos = response.data.results[2].formatted_address.indexOf('-');
                var city = response.data.results[2].formatted_address.substring(0, commaPos);
                vm.currentCity = city;

                //call to retrieve city breweries
                getCityBreweries(pos);
            });
    };

    //returns a json string of breweries just in current location city
    function getCityBreweries(pos) {

        //get request to web api to retrieve current city breweries, Nashville will be replaced with vm.currentcity
        $http.get('/api/brewery?breweryCity=Nashville')
            .then(function (response) {
                vm.breweries = response.data;
                console.log(vm.breweries);
                var map;
                //function to instantiate map with center at passed city
                function initMap() {
                    map = new google.maps.Map(document.getElementById('map'), {
                        //eventually change in pos.lng and pos lat for varaibles
                        center: { lat: 36.174465, lng: -86.767960 },
                        zoom: 10,
                        mapTypeControl: false
                    });
                    //for loop to place markers of breweries
                    for (var i = 0; i < response.data.length; i++) {
                        var address = response.data[i].breweryAddress + response.data[i].breweryCity + response.data[i].breweryState + response.data[i].breweryZip;
                        var geocoder = new google.maps.Geocoder();
                        var counter = 0;
                        geocoder.geocode({ 'address': address }, function (results, status, i) {
                            var icon = {
                                url: "http://" + response.data[counter].breweryLogo,
                                scaledSize: new google.maps.Size(25,25)
                            }
                            //creates new marker
                            if (status === google.maps.GeocoderStatus.OK) {
                                var marker = new google.maps.Marker({
                                    map: map,
                                    icon: icon,
                                    position: results[0].geometry.location,
                                    optimized: false
                                });
                                //puts event listener on marker click, opens side nav with clicked brewery info
                                //switch to mousedown for production and demo
                                var brewerymark = counter;
                                marker.addListener('click', function () {
                                    map.setZoom(10);
                                    vm.getSpecificBrewery(brewerymark);
                                })
                            }
                            counter++;
                        })
                        
                    }
                }
                initMap();
            })
    };

    //sets the side nav to the specific brewery info
    vm.getSpecificBrewery = function (brewery) {
        console.log(brewery);
        vm.brewery = vm.breweries[brewery];
        console.log(vm.brewery);
        vm.punchStatus = 'selectBeer';
    };

    vm.goToConfirmation = function (beer) {
        
    };

    //retrieves position and city from entered address
    vm.manualLoc = function () {
        var address = $("#manLocation").val();
        address = address.replace(/ /g, "+");
        $http.get('https://maps.googleapis.com/maps/api/geocode/json?address=' + address + '&key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk')
            .then(function (response) {
                pos.lat = response.data.results[0].geometry.location.lat;
                pos.lng = response.data.results[0].geometry.location.lng;
                vm.currentCity = response.data.results[0].address_components[0].long_name;
                getCityBreweries(pos);
            });
    }

    vm.breweryInfo;
    vm.breweryView = function (index) {
        vm.breweryInfo = vm.breweries[index];
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
        brewery.breweryPin = parseInt(vm.pin);
        vm.pin = "";
        var userpurchase = {
            Beer_info: beer,
            Brewery_info: brewery,
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