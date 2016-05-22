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
        var pos = {
            lat: position.coords.latitude,
            lng: position.coords.longitude
        };
        $http.get('https://maps.googleapis.com/maps/api/geocode/json?latlng='+pos.lat+','+pos.lng+'&key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk')
        .then(function (response) {
            console.log(response.data.results);
            var commaPos = response.data.results[2].formatted_address.indexOf(',');
            var city = response.data.results[2].formatted_address.substring(0, commaPos);
            console.log(city);
        });

    };

    $http.get('/api/brewery')
        .then(function (response) {
            console.log(response);
        })

        /*infoWindow.setPosition(pos);
        infoWindow.setContent('Location found.');
        map.setCenter(pos);*/
});