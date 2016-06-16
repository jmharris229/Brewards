app.controller('rewardsCtrl', function ($http, $q, $scope, $log, authService) {
    var vm = this;
    vm.punchcardData;
    vm.renderPunchcards = function () {
        $http.get('/api/Userpurchase?filter=true')
            .then(function (response) {
                console.log(response.data)
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

    function toggleQueue() {
        if ($('.punchStack').hasClass('active')) {
            $('.punchStack').removeClass('active');
        } else {
            $('.punchStack').addClass('active');
        }

    }
    
    //toggleQueue();
});