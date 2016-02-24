'use strict';
app.controller('ordersController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.transactionsHistory = [];

    ordersService.getOrders().then(function (results) {

        $scope.transactionsHistory = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

}]);