﻿app.controller('nearbyBreweriesCtrl',['$http', 'authService', 'locService', '$location', function ($http, authService, locService, $location) {
    var vm = this;
    vm.breweries;
    vm.city;
        locService.getCity()
            .then(function(city){
                vm.city = city.toUpperCase();
            });

    //add method using google maps api to get current city from github
    vm.listOfBreweries = function () {
        $http.get('api/breweries?breweryCity=Nashville')
            .then(function (response) {
                console.log(response.data);
                vm.breweries = response.data;
            })
    }
    vm.listOfBreweries();

    vm.selectBrewery = function (brewery) {
        authService.atBrewery = false;
        authService.actualBrewery = brewery;
        authService.selectBeer = true;
        $location.url('/addPunch');
    }
}]);