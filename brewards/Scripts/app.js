var app = angular.module("BrewardsApp", ['ngRoute', 'ngMaterial']);

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
    vm.breweries = "";
    vm.currentCity;
    this.toggleRight = buildToggler('right');
    this.isOpenRight = function(){
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

    this.close = function () {
        $mdSidenav('right').close()
        .then(function () {
            $log.debug("close RIGHT is done");
        });
    }

    var pos;
    $(document).ready(function () {
        var googleScript = document.createElement('script');
        googleScript.setAttribute('src', "https://maps.googleapis.com/maps/api/js?key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk&callback=CurrentLoc");
        window.CurrentLoc = function () {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(logCoordinates)
            } else {
                Alert("device does not support geolocation");
            }
        }
        $('head').append(googleScript);
    });

    function logCoordinates(position) {
        //creates coordinates from geolocation
        pos = {
            lat: position.coords.latitude,
            lng: position.coords.longitude
        };
        //api request to google maps to retrieve current city
        $http.get('https://maps.googleapis.com/maps/api/geocode/json?latlng='+pos.lat+','+pos.lng+'&key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk')
            .then(function (response) {
                
                //parses google maps object for city
                var commaPos = response.data.results[2].formatted_address.indexOf(',');
                var city = response.data.results[2].formatted_address.substring(0, commaPos);
                vm.currentCity = city;
                //call to retrieve city breweries
                getCityBreweries(city, pos);
        });
    };

    //returns a json string of breweries just in current location city
    function getCityBreweries(city, pos) {
        //get request to web api to retrieve current city breweries
        $http.get('/api/brewery?breweryCity=Nashville')
            .then(function (response) {
                vm.breweries = response.data;
                console.log(vm.breweries);
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
    
    this.manLoc = function () {
        var address = $("#manLocation").val;
        address = address.replace(/ /g,"+");
        $http.get('https://maps.googleapis.com/maps/api/geocode/json?address=' + address + '&key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk')
            .then(function (response) {
                logcoordinates();
            });
    }
        /*infoWindow.setPosition(pos);
        infoWindow.setContent('Location found.');
        map.setCenter(pos);*/
});