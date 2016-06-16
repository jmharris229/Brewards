app.service('authService', function ($http) {
    var self = this;
    self.atBrewery = true;
    self.actualBrewery = {};
    self.getAuth = function () {
       return $http.get('api/user')
            .then(function (response) {
                if (response.data) {
                    return response.data;
                } else {
                    throw new Error("not logged in");
                }
            });
    }


});