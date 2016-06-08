app.controller('rewardsCtrl', function ($http, $q, $scope, $log) {
    var vm = this;
    vm.punchcardData;
    vm.renderPunchcards = function () {
        $http.get('/api/Userpurchase?filter=true')
            .then(function (response) {
                vm.punchcardData = response.data;
            }
        )
    }

    vm.renderPunchcards();

    vm.redeem = function (viewModelData) {
        console.log(viewModelData);
        var redemption = {
            Brewery_info: viewModelData.brewery_info            
        }
        $http.put('/api/Rewardstatus?=', redemption)
            .error(function () {
                alert("failure");
            })
            .success(function () {
                alert("success");
            });
    }
});