(function () {
    'use strict';

    angular
        .module('app')
        .controller('orderCtrl', orderCtrl);

    orderCtrl.$inject = ['$scope', '$http'];

    function orderCtrl($scope, $http) {
        var isErrors = true;
        $scope.composeEmail = {};
      
        $scope.sendEmail = function () {
           
            var order = { "Name": $scope.composeEmail.name, "SName": $scope.composeEmail.sname, "Company": $scope.composeEmail.company, "City": $scope.composeEmail.city, "Address": $scope.composeEmail.address, "Price": $scope.composeEmail.price};
       
            if (order.Name != null && order.SName != null && order.City != null && order.Address != null && order.Price != null) {
                setErrors(order);
                if (!isErrors) {
                  
                    $http({
                        method: 'POST',
                        url: '/api/order',
                        data: JSON.stringify(order), //forms user object
                        headers: { 'Content-Type': 'application/json' }
                    });
                       
                        $http({
                            method: 'POST',
                            url: 'http://localhost:55435/api/transactions/neworder',
                            data: JSON.stringify(order), //forms user object
                            headers: { 'Content-Type': 'application/json' }
                        }).success(function (order) {
                            alert("Data sended");
                            setTimeout('location="#";', 5000);
                        });

                       /* $http({
                            method: 'POST',
                            url: 'http://receiveorder.azurewebsites.net/api/transactions/newOrder/',
                            data: JSON.stringify(order), //forms user object
                            headers: { 'Content-Type': 'application/json' }
                        }).success(function (order) {
                            alert("Data sended");
                            setTimeout('location="#";', 5000);
                         });*/

                   
                };
            }

        };

        function setErrors(order) {
         $scope.error = {};
      
         if ((order.Name + '').length < 3) {
            $scope.error.SName = "Wrong Name";
           
         } else if ((order.SName + '').length < 3) {
             $scope.error.SName = "Wrong Surname";
         }
         else if ((order.City + '').length < 3) {
             $scope.error.City = "Wrong City";
         }
         else if ((order.Address + '').length < 3) {
             $scope.error.Address = "Wrong Address";
         }
         else if (isNaN(order.Price+ '')) {
             $scope.error.Price = "Wrong Price";
         }
         else {
             isErrors = false;
         }
    }
    }

  

})();
