app.controller('rewardsCtrl', function ($http, $q, $scope, $log) {
    var vm = this;
    vm.punchcardData;
    vm.renderPunchcards = function () {
        $http.get('/api/Userpurchase')
            .then(function (response) {
                /*for (var i = 0; i < response.data.length; i++) {
                    if (response.data[i].number_purchased / 8 == 0 || response.data[i].number_purchased / 8 == 1) {
                        response.data[i].number_purchased = 0;
                        response.data[i].redeemable = true;
                    } else {
                        var remainder = (response.data[i].number_purchased / 8) * 8;
                        response.data[i].number_purchased = remainder;
                        response.data[i].redeemable = false;
                    }
                }*/
                vm.punchcardData = response.data;
            }
        )
    }

    vm.renderPunchcards();

    vm.redeem = function (viewModelData) {
        console.log(viewModelData);
        var redemption = {
            Brewery_info: viewModelData.Brewery_info            
        }
        console.log(redemption);
        console.log(redemption);
        $http.put('/api/Rewardstatus?=', redemption)
            .error(function () {
                alert("failure");
            })
            .success(function () {
                alert("success");
            });
    }



});