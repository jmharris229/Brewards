app.controller('rewardsCtrl', function ($http, $q, $scope, $log) {
    var vm = this;

    vm.renderPunchcards = function () {
        $http.get('/api/Userpurchase')
            .then(function (response) {
                console.log(response);
            }
        )
    }
});