app.controller('rewardsCtrl', function ($http, $q, $scope, $log) {
    var vm = this;
    vm.punchcardData;
    vm.renderPunchcards = function () {
        $http.get('/api/Userpurchase')
            .then(function (response) {
                //debugger;

                console.log(response.data);
                vm.punchcardData = response.data;
                //analyzePurchases(response.data);
            }
        )
    }

    vm.renderPunchcards();

});