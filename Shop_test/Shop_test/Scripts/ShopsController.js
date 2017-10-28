shopTest.controller("shopController", function ($scope, $http,cfpLoadingBar,
            $cookies) {
    $scope.thisShop = null;
    $scope.lShops = [];
    $scope.modalShown = false;
    cfpLoadingBar.start();
    $http.get('/Shops/AllShopsList').
        then(function (success) {
            $scope.lShops = success.data;
        }, function (error) {

        })
    cfpLoadingBar.complete();
    $scope.AddShop = function (Shop) {
        $http.post(
            '/Shops/Create',
            JSON.stringify(Shop)
        ).then(function (success) {
            alert("Shop created sccessfully")
            $scope.lShops.push(angular.copy(success.data));
            delete $scope.Shop;
        }, function (error) {
            alert(error.data)
        });
    }

    $scope.EditShop = function (thisShop) {
        $http.post(
            '/Shops/Edit',
            JSON.stringify(thisShop)
        ).then(function (success) {
            alert("Shop edit sccessfully")
            $scope.lShops = success.data;
        }, function (error) {
            alert(error.data)
        });
        $scope.modalShown = !$scope.modalShown;
    }

    $scope.DeleteShop = function (ShopId) {
        $http.post(
            '/Shops/Delete',
            {
                'id': ShopId
            }
        ).then(function (success) {
            alert("Shop has bin deleted sccessfully")
            $scope.lShops = success.data;
        }, function (error) {
            alert(error.data)
        });
    }

    $scope.Popup = function (Shop) {
        $scope.thisShop = Shop;
        $scope.modalShown = !$scope.modalShown;
    }

    $scope.GetShopId = function (ShopId) {
        $cookies.put('ShopId', ShopId);
    }
})