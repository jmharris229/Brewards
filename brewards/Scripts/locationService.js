app.service('locService', function ($http) {
    var self = this;
    self.city;

    self.getCity = function () {
       return $http.get('https://maps.googleapis.com/maps/api/geocode/json?latlng=36.150338,-86.779493&key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk')
        .then(function (response) {
            return response.data.results[4].address_components[0].long_name;
        })
    }

})