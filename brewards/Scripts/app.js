var app = angular.module("BrewardsApp", ['ngRoute']);

app.config(['$routeProvider',function ($routeProvider) {
    $routeProvider
        .when('/map', {
            templateUrl: '/Templates/map.html',
            controller: 'mapCtrl'
        })
        .when('/rewards', {
            templateUrl: '/Templates/rewards.html',
            controller: 'rewardsCtrl'
        })
        .otherwise({ redirectTo: '/' });
}]);

app.controller('mapCtrl', function ($http, $q) {

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(logCoordinates)
    } else {
        Alert("device does not support geolocation");
    }

    function logCoordinates(position) {
        //creates coordinates from geolocation
        var pos = {
            lat: position.coords.latitude,
            lng: position.coords.longitude
        };
        //api request to google maps to retrieve current city
        /*$http.get('https://maps.googleapis.com/maps/api/geocode/json?latlng='+pos.lat+','+pos.lng+'&key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk')
            .then(function (response) {
                
                //parses google maps object for city
                var commaPos = response.data.results[2].formatted_address.indexOf(',');
                var city = response.data.results[2].formatted_address.substring(0, commaPos);

                //call to retrieve city breweries
                getCityBreweries(city);
        });*/

    };
    //returns a json string of breweries just in current location city
    function getCityBreweries(city) {
        //get request to web api to retrieve current city breweries
        $http.get('/api/brewery?breweryCity='+city)
            .then(function (response) {
                console.log(response);
        });
    }

    getCityBreweries("Nashville");


        /*infoWindow.setPosition(pos);
        infoWindow.setContent('Location found.');
        map.setCenter(pos);*/
});