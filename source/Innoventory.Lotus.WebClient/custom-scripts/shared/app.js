
(function (inv) {

    inv.emptyGuid = "00000000-0000-0000-0000-000000000000";

    var commonModule = angular.module('common', ['ngRoute', 'ui.bootstrap']);


    commonModule.constant("emptyGuid", "00000000-0000-0000-0000-000000000000");
    commonModule.factory('apiHelper', ['$http', '$q', function ($http, $q) {
        return Innoventory.apiHelper($http, $q);
    }]);

    
    var mainApp = angular.module("mainApp", ['common', 'category-directives']);

    mainApp.controller("productController", ["$scope", "$q", "productService", function ($scope, $q, productService) {

        Innoventory.productController($scope, $q, productService);

    }]);



    mainApp.factory("productService", ['$http', '$q', 'apiHelper', function ($http, $q, apiHelper) {
        return Innoventory.productService($http, $q, apiHelper);
    }]);


    var categoryModule = angular.module("categoryModule", ['common']);

    mainApp.controller("categoryController", ["$scope", "$q", "apiHelper", function ($scope, $q, apiHelper) {
        Innoventory.categoryController($scope, $q, apiHelper);
    }]);

    mainApp.factory("categoryService", ['apiHelper', function (apiHelper) {
        return Innoventory.categoryService(apiHelper);
    }]);

}(window.Innoventory));