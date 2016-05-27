var app = angular.module("BrewardsApp", ['ngRoute', 'ngMaterial', 'ngAnimate']);

app.config(['$routeProvider',function ($routeProvider) {
    $routeProvider
        .when('/map', {
            templateUrl: '/Templates/map.html',
            controller: 'mapCtrl as MapCtrl'
        })
        .when('/rewards', {
            templateUrl: '/Templates/rewards.html',
            controller: 'rewardsCtrl'
        })
        .otherwise({ redirectTo: '/' });
}]);

app.controller('mapCtrl', function ($http, $q, $mdSidenav, $scope, $log) {


    var vm = this;
    var pos;
    vm.breweries;
    vm.currentCity;
    
    //side nav functionality
    vm.toggleRight = buildToggler('right');
    vm.isOpenRight = function(){
        return $mdSidenav('right').isOpen();
    }
    function buildToggler(navID) {
        return function () {
            $mdSidenav(navID)
      		.toggle()
      		.then(function () {
      		    $log.debug("toggle " + navID + " is done");
      		});
        }
    }

    vm.close = function () {
        $mdSidenav('right').close()
        .then(function () {
            $log.debug("close RIGHT is done");
        });
    }
    //end side nav functionality

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
        $http.get('https://maps.googleapis.com/maps/api/geocode/json?latlng='+pos.lat+','+pos.lng+'&key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk')
            .then(function (response) {
                
                //parses google maps object for city
                var commaPos = response.data.results[2].formatted_address.indexOf(',');
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
                var map;
                //function to instantiate map with center at passed city
                function initMap() {
                    map = new google.maps.Map(document.getElementById('map'), {
                        center: { lat: pos.lat, lng: pos.lng },
                        zoom: 8
                    });
                    //for loop to place markers of breweries
                    for (var i = 0; i < response.data.length; i++) {
                        var address = response.data[i].Brewery_address + response.data[i].Brewery_city + response.data[i].Brewery_state + response.data[i].Brewery_zip;
                        var geocoder = new google.maps.Geocoder();
                        geocoder.geocode({ 'address': address }, function(results, status){
                            if(status === google.maps.GeocoderStatus.OK){
                                var marker = new google.maps.Marker({
                                    map: map,
                                    position: results[0].geometry.location
                                });
                            }
                        })                
                    }
                }
                initMap();
            })
    };
    
    //retrieves position and city from entered address
    vm.manualLoc = function () {
        var address = $("#manLocation").val();
        console.log(address);
        address = address.replace(/ /g,"+");
        $http.get('https://maps.googleapis.com/maps/api/geocode/json?address=' + address + '&key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk')
            .then(function (response) {
                console.log(response.data);
                pos.lat = response.data.results[0].geometry.location.lat;
                pos.lng = response.data.results[0].geometry.location.lng;
                vm.currentCity = response.data.results[0].address_components[0].long_name;
                getCityBreweries(pos);
            });
    }
        /*infoWindow.setPosition(pos);
        infoWindow.setContent('Location found.');
        map.setCenter(pos);*/
    vm.breweryInfo;
    vm.breweryView = function (index) {
        vm.breweryInfo = vm.breweries[index];
    }

    vm.addPunch = function (beer, brewery) {
        console.log(beer, brewery);
        var userpurchase = {
            Beer_info: beer,
            Brewery_info: brewery
        }
        console.log(userpurchase);
        $http.put('/api/Userpurchase?purchase='+userpurchase)
            .error(function () {
                alert('failure');
            })
            .success(function () {
                alert("success");
            });
    }

    vm.purchases = function () {
        console.log("ran iffe");
        $http.get('/api/Userpurchase')
            .then(function (response) {
                console.log(response.data);
            }
        )};

});