﻿
var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    
    $routeProvider.when("/orders", {
        controller: "ordersController",
        templateUrl: "/app/views/orders.html"
    });

  


    $routeProvider.otherwise({ redirectTo: "/home" });

});

//var serviceBase = 'http://localhost:55435/';
var serviceBase = 'http://receiveorderr.azurewebsites.net/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


