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


    $http.jsonp('//maps.googleapis.com/maps/api/geocode/json?latlng=40.714224,-73.961452&key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk')
    .then(function (response) {
        console.log(response.data);
    });
});