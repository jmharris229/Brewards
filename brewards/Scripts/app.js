var app = angular.module("BrewardsApp", ['ngRoute', 'ngMaterial', 'ngAnimate']);

app.config(['$routeProvider',function ($routeProvider) {
    $routeProvider
        .when('/map', {
            templateUrl: '/Templates/map.html',
            controller: 'mapCtrl as MapCtrl'
        })
        .when('/rewards', {
            templateUrl: '/Templates/rewards.html',
            controller: 'rewardsCtrl as RewardsCtrl'
        })
        .otherwise({ redirectTo: '/' });
}]);
