app.controller('brewNewsCtrl', function($http){
    var vm = this;

    vm.test = "hello";

    $http.get('api/BreweryNews?breweryCity=Nashville')
        .then(function (response) {
            console.log(response.data);
        })
})