
(function (inv) {

    var commonModule = angular.module('common', ['ngRoute', 'ui.bootstrap']);

    var mainApp = angular.module("mainApp", ['common']);

    mainApp.controller("productController", productController);

    commonModule.factory('viewModelHelper', ['$http', '$q', function ($http, $q) {
        return Innoventory.viewModelHelper($http, $q);
    }]);

    mainApp.factory("productService", productService);

    //mainApp.factory("innoventoryService", innoventoryService);


}(window.Innoventory));