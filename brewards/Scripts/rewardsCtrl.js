app.controller('rewardsCtrl', ['$http','$q','$scope','$log','authService', function ($http, $q, $scope, $log, authService) {
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
            BreweryInfo: viewModelData.breweryInfo            
        }
        $http.put('/api/Rewardstatus?=', redemption)
            .error(function () {
            })
            .success(function () {
                $http.get('/api/Userpurchase?filter=true')
                    .then(function (response) {
                        vm.punchcardData = response.data;
                    })
            });
    }

    function toggleQueue() {
        if ($('.punchStack').hasClass('active')) {
            $('.punchStack').removeClass('active');
        } else {
            $('.punchStack').addClass('active');
        }
    }
    
    toggleQueue();

    $('.punchStack').on('click', '.punchcard', function () {
        $('.punchcard').removeClass('viewCard');
        $(this).addClass('viewCard');
    })

    //$('.punchStack').on('click', '.punchcard.exitPunchButton', function () {
    //    $(this).removeClass('viewCard');
    //})



    vm.closePunchcard = function (e) {
        console.log(e)
        $('.punchcard').removeClass('viewCard');
    }
    //$('.punchStack>.punchcard>.exitPunchcardButton').on('click', function () {
    //    console.log("clicked")
    //    $(this).removeClass('viewCard');
    //})

    vm.createPunchArray = function (punchNumber) {
        return new Array(punchNumber);
    }
}]);