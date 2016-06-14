app.controller('purchasesCtrl', function ($http, $q, $scope, $log) {
    var vm = this;
    vm.purchaseData;
    vm.renderPurchases = function () {
        $http.get('/api/Userpurchase?filter=false')
            .then(function (response) {
                console.log(response.data);
                vm.purchaseData = response.data;
            })
    }
    vm.renderPurchases();
});