﻿app.controller('homeCtrl', ['authService','$location', function(authService, $location){
    var vm = this;

    authService.getAuth().then(function(loginStatus){
        if (loginStatus) {
            $location.url('/addpunch');
        } else {
            $location.url('/');          
        }
    })

    vm.goToLogin = function () {
        window.location.href = '/Account/Login';
    }
    vm.goToSignup = function () {
        window.location.href = '/Account/Register';
    }

}]);