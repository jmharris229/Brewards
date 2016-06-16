app.controller('brewNewsCtrl', function($http){
    var vm = this;

    vm.test = "hello";
    vm.offers;
    $http.get('api/BreweryNews?breweryCity=Nashville')
        .then(function (response) {
            vm.offers = response.data;
        });
})