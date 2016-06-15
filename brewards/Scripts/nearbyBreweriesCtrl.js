app.controller('nearbyBreweriesCtrl', function ($http) {
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
});