app.controller('nearbyBreweriesCtrl', function ($http, authService, $location) {
    var vm = this;
    vm.breweries;

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
        $location.url('/addPunch');
    }
});