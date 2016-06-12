var app = angular.module("BrewardsApp", ['ngRoute', 'ngMaterial', 'ngAnimate']);

app.config(['$routeProvider',function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: '/Templates/home.html',
            controller: 'homeCtrl as HomeCtrl',
            authorize: false
        })
        .when('/map', {
            templateUrl: '/Templates/map.html',
            controller: 'mapCtrl as MapCtrl',
            authorize: true
        })
        .when('/rewards', {
            templateUrl: '/Templates/rewards.html',
            controller: 'rewardsCtrl as RewardsCtrl',
            authorize: true
        })
        .when('/purchases', {
            templateUrl: '/Templates/purchases.html',
            controller: 'purchasesCtrl as PurchasesCtrl',
            authorize: true
        })
        .otherwise({ redirectTo: '/' });
}]);

//authorization feature to determine if logged in or not. prevents redirect if not logged in. 
app.run(function ($rootScope, $location) {
    $rootScope.$on('$routeChangeStart', function (evt, to, from) {
        if (to.authorize === true) {
            to.resolve = to.resolve || {}
            if (!to.resolve.authorizationResolver) {
                to.resolve.authorizationResolver = ['authService', function (authService) {
                    return authService.getAuth();
                }]
            }
        }
    });
    $rootScope.$on('$routeChangeError', function (evt, to, from, error) {
        $location.path('/');
        if (error instanceof AuthorizationError) {
            $location
                .path('/')
        }
    });
});
