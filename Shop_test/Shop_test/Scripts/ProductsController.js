shopTest.controller("productsController", function ($scope, $http, $cookies, cfpLoadingBar) {
    $scope.thisProduct = null;
    $scope.lProducts = [];
    $scope.modalShown = false;

    cfpLoadingBar.start();
    $http.get(
        '/Products/AllProductsList',
         {
             params: {
                 'ShopId': $cookies.get('ShopId')
             }
         }).
        then(function (success) {
            $scope.lProducts = success.data;
        }, function (error) {

        })
    cfpLoadingBar.complete();

    $scope.AddProduct = function (Product) {
        Product.ShopId = $cookies.get('ShopId');
        $http.post(
            '/Products/Create',
            JSON.stringify(Product)
        ).then(function (success) {
            alert("Product created sccessfully")
            $scope.lProducts.push(angular.copy(success.data));
            delete $scope.Product;
        }, function (error) {
            alert(error.data)
        });
    }

    $scope.EditProduct = function (thisProduct) {
        $http.post(
            '/Products/Edit',
            JSON.stringify(thisProduct)
        ).then(function (success) {
            alert("Product edit sccessfully")
            $scope.lProducts = success.data;
        }, function (error) {
            alert(error.data)
        });
        $scope.modalShown = !$scope.modalShown;
    }

    $scope.DeleteProduct = function (ProductId) {
        $http.post(
            '/Products/Delete',
            {
                'id': ProductId
            }
        ).then(function (success) {
            alert("Product has bin deleted sccessfully")
            $scope.lProducts = success.data;
        }, function (error) {
            alert(error.data)
        });
    }
    $scope.Popup = function (Product) {
        $scope.thisProduct = Product;
        $scope.modalShown = !$scope.modalShown;
        $("#dialog-form").dialog("open");
    }
})