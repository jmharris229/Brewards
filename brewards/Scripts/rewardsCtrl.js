app.controller('rewardsCtrl', function ($http, $q, $scope, $log) {
    var vm = this;
    vm.punchcardData;
    vm.renderPunchcards = function () {
        $http.get('/api/Userpurchase')
            .then(function (response) {
            //debugger;
                console.log(response.data);

                analyzePurchases(response.data);
            }
        )
    }

    vm.renderPunchcards();
    
    function analyzePurchases(purchases) {
        var userBreweries = [];
        var userBeers = [];
        vm.punchCards = [];
        var brewObjects = [];
        var beerObjects = [];

        console.log(purchases);
        for (var m = 0; m < purchases.length; m++) {
            brewObjects.push(purchases[m].brewery_info);
            beerObjects.push(purchases[m].brewery_info.brewery_beers);
        }
        console.log(brewObjects)
        //_.uniq(brewObjects);
        _.uniq(beerObjects);
        console.log(brewObjects);
        
        for (var i = 0; i < purchases.length; i++)
        {
            userBeers.push(purchases[i].beer_info.beer_name);
            userBreweries.push(purchases[i].brewery_info.brewery_Name);
        }

        var countedVisits = _.countBy(userBreweries, function (ub) {
            return ub;
        });

        var countedBeers = _.countBy(userBeers, function (ub) {
            return ub;
        });

        vm.punchCards = new Object();
        for (var j = 0; j < userBreweries.length ; j++) {
            vm.punchCards[userBreweries[j]] = {
                visits: countedVisits[userBreweries[j]],
                brewery: _.find(brewObjects, function (b) {
                    console.log(b)
                    if (b.brewery_Name == userBreweries[j]) {
                        return b;
                    }
                }),
                beer: getAssociatedBeers(userBreweries[j])

            }
        }

        function getAssociatedBeers(brewery) {
            console.log(brewery);
            var place = _.find(brewObjects, function (b) {
                return b.brewery_Name == brewery;
            })
            console.log(place);
            var beerCount = [];
            for (var l = 0; l < place.brewery_beers.length; l++) {
                beerCount.push(place.brewery_beers[l] = countedBeers[place.brewery_beers[l]]);
            }
            return beerCount;
        }


        console.log(vm.punchCards);

    }

});