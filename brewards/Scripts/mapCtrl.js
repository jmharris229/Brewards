app.controller('mapCtrl', function ($http, $q, $mdSidenav, $scope, $log, $mdDialog) {


    var vm = this;
    var pos;
    vm.breweries;
    vm.brewery;
    vm.currentCity;

    //side nav functionality
    vm.toggleRight = buildToggler('right');
    vm.isOpenRight = function () {
        return $mdSidenav('right').isOpen();
    }
    function buildToggler(navID) {
        return function () {
            $mdSidenav(navID)
      		.toggle()
      		.then(function () {
      		    $log.debug("toggle " + navID + " is done");
      		});
        }
    }

    vm.close = function () {
        $mdSidenav('right').close()
        .then(function () {
            $log.debug("close RIGHT is done");
        });
    }
    //end side nav functionality

    //once document is ready runs function to add google maps script and gets current location   
    $(document).ready(function () {
        var googleScript = document.createElement('script');
        googleScript.setAttribute('src', "https://maps.googleapis.com/maps/api/js?key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk&callback=CurrentLoc");
        window.CurrentLoc = function () {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(getCity)
            } else {
                Alert("device does not support geolocation");
            }
        }
        $('head').append(googleScript);
    });

    vm.currentLoc = function () {
        window.CurrentLoc();
    };

    //gets city from coordinates
    function getCity(position) {
        //creates coordinates from geolocation
        pos = {
            lat: position.coords.latitude,
            lng: position.coords.longitude
        };

        //api request to google maps to retrieve current city from coordinates
        $http.get('https://maps.googleapis.com/maps/api/geocode/json?latlng=' + pos.lat + ',' + pos.lng + '&key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk')
            .then(function (response) {

                //parses google maps object for city
                var commaPos = response.data.results[2].formatted_address.indexOf(',');
                var city = response.data.results[2].formatted_address.substring(0, commaPos);
                vm.currentCity = city;

                //call to retrieve city breweries
                getCityBreweries(pos);
            });
    };

    //returns a json string of breweries just in current location city
    function getCityBreweries(pos) {
        //get request to web api to retrieve current city breweries, Nashville will be replaced with vm.currentcity
        $http.get('/api/brewery?breweryCity=Nashville')
            .then(function (response) {
                vm.breweries = response.data;
                var map;
                //function to instantiate map with center at passed city
                function initMap() {
                    map = new google.maps.Map(document.getElementById('map'), {
                        center: { lat: pos.lat, lng: pos.lng },
                        zoom: 8
                    });
                    //for loop to place markers of breweries
                    for (var i = 0; i < response.data.length; i++) {
                        var address = response.data[i].brewery_address + response.data[i].brewery_city + response.data[i].brewery_state + response.data[i].brewery_zip;
                        var geocoder = new google.maps.Geocoder();
                        var counter = 0;
                        geocoder.geocode({ 'address': address }, function (results, status, i) {
                            var icon = {
                                url: "http://" + response.data[counter].brewery_logo,
                                scaledSize: new google.maps.Size(25,25)
                            }
                            //creates new marker
                            if (status === google.maps.GeocoderStatus.OK) {
                                var marker = new google.maps.Marker({
                                    map: map,
                                    icon: icon,
                                    position: results[0].geometry.location,
                                    optimized: false
                                });
                                //puts event listener on marker click, opens side nav with clicked brewery info
                                //switch to mousedown for production and demo
                                var brewerymark = counter;
                                marker.addListener('click', function () {
                                    map.setZoom(8);
                                    getSpecificBrewery(brewerymark);
                                    vm.toggleRight();
                                })
                            }
                            counter++;
                        })
                        
                    }
                }
                initMap();
            })
    };

    //sets the side nav to the specific brewery info
    function getSpecificBrewery(brewery) {
        
        vm.brewery = vm.breweries[brewery];
        console.log(vm.brewery);
    }

    //retrieves position and city from entered address
    vm.manualLoc = function () {
        var address = $("#manLocation").val();
        address = address.replace(/ /g, "+");
        $http.get('https://maps.googleapis.com/maps/api/geocode/json?address=' + address + '&key=AIzaSyCaP1HGGwG3R2OpeRAoIQaZSNkj4LeGLhk')
            .then(function (response) {
                pos.lat = response.data.results[0].geometry.location.lat;
                pos.lng = response.data.results[0].geometry.location.lng;
                vm.currentCity = response.data.results[0].address_components[0].long_name;
                getCityBreweries(pos);
            });
    }
    /*infoWindow.setPosition(pos);
    infoWindow.setContent('Location found.');
    map.setCenter(pos);*/
    vm.breweryInfo;
    vm.breweryView = function (index) {
        vm.breweryInfo = vm.breweries[index];
    }

    //post purchase to database
    vm.addPunch = function (beer, brewery, pin) {
        brewery.Brewery_pin = parseInt(pin);
        var userpurchase = {
            Beer_info: beer,
            Brewery_info: brewery,
        };
        $http.post('/api/Userpurchase?purchase=', userpurchase)
            .error(function () {
                alert('failure');
            })
            .success(function () {
                alert("success");
            });
    }

    /*vm.confirmPunch = function (ev, beer, brewery) {
        // Appending dialog to document.body to cover sidenav in docs app
        var confirm = $mdDialog.prompt()
          .title('Confirm Punch')
          .targetEvent(ev)
          .ok('Add punch')
          .cancel('Cancel');
        $mdDialog.show(confirm).then(function (result) {
            vm.addPunch(beer, brewery, result);
        }, function () {
            $scope.status = 'You didn\'t name your dog.';
        });
    };*/

    vm.confirmPunch = function(ev) {
        $mdDialog.show({
            controller: DialogController,
            contentElement: '#myDialog',
            parent: angular.element(document.body),
            targetEvent: ev,
            clickOutsideToClose: true
        });
    };
});

function DialogController($scope, $mdDialog) {
  $scope.hide = function() {
    $mdDialog.hide();
  };
  $scope.cancel = function() {
    $mdDialog.cancel();
  };
  $scope.answer = function(answer) {
    $mdDialog.hide(answer);
  };
}