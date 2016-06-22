app.controller('brewNewsCtrl',['$http', 'locService', function($http, locService){
    var vm = this;

    vm.offers;

    //retrieves offers specific to city, switch out city for locService city once fully implemented for test this is fine. 
    $http.get('api/BreweryNews?breweryCity=Nashville')
        .then(function (response) {
            
            //process to change date to more readible format
            var editedOffers = response.data;
            for (var i = 0; i < editedOffers.length; i++) {
                var tIndex = editedOffers[i].newsDate.indexOf('T');
                var slicedDate = editedOffers[i].newsDate.substring(0, tIndex);
                editedOffers[i].newsDate = new Date(slicedDate).toDateString().toUpperCase();
            }
            console.log(editedOffers);
            vm.offers = editedOffers;
        });
}])