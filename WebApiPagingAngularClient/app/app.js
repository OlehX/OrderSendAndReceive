(function () {
    'use strict';

    var app = angular.module('app', ['ngResource','ngRoute']);

    app.config(['$routeProvider', function ($routeProvider) {        

        $routeProvider.when('/welcome', {
            templateUrl: 'app/welcome.html',
            controller: 'welcomeCtrl',
            caseInsensitiveMatch: true
        });
    
        $routeProvider.when('/order/', {
            templateUrl: 'app/order/order.html',
            controller: 'orderCtrl',
            caseInsensitiveMatch: true
        });
        $routeProvider.otherwise({
            redirectTo: '/welcome'
        });
    }]);

    app.run([function () {        
    }]);
})();